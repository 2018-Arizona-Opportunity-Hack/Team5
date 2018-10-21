using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;

namespace FormOcrFunction
{
    public static class RegionProcessor
    {
        [FunctionName("RegionProcessor")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Image data received.");

            var kvp = req.GetQueryParameterDictionary();
            int x = Convert.ToInt32(kvp["x"]);
            int y = Convert.ToInt32(kvp["y"]);
            int height = Convert.ToInt32(kvp["height"]);
            int width = Convert.ToInt32(kvp["width"]);
            var cropRectangle = new SixLabors.Primitives.Rectangle(x, y, width, height);

            byte[] data;
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            if (requestBody.StartsWith("\\"))
                data = File.ReadAllBytes(requestBody);
            else
                data = (byte[])JsonConvert.DeserializeObject(requestBody);

            log.Info("Starting crop.");
            using (Image<Rgba32> image = Image.Load(data))
            {
                var clone = image.Clone();
                clone.Mutate(c => c.Crop(cropRectangle));

                // Run pixel detection
                log.Info("Determining black pixel count.");
                var blackPixelCount = CountPixels(clone, new Rgba32(255, 0, 0, 0));

                log.Info("Requesting OCR.");
                var text = await GetOcrText(data);

                return new OkObjectResult(new { pixelCount = blackPixelCount, capturedText = text });
            }
        }

        private static int CountPixels(Image<Rgba32> img, Rgba32 target_color)
        {
            // Loop through the pixels.
            int matches = 0;
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    if (img[x, y] == target_color) matches++;
                }
            }
            return matches;
        }

        private static async Task<string> GetOcrText(byte[] imageBytes)
        {
            var client = new HttpClient();

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "52d9ef26419c441d9a1d7652c5b98208");

            // Request parameters
            queryString["language"] = "en";
            queryString["detectOrientation "] = "false";
            var uri = "https://westus.api.cognitive.microsoft.com/vision/v1.0/ocr?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }

            response.EnsureSuccessStatusCode();
            var ocrResponse = await response.Content.ReadAsAsync<OcrResponse>();

            // Convert the objects to sentences
            string output = string.Join(" ", ocrResponse.regions.Select(r => r.lines).FirstOrDefault()
                .Select(l => l.words).FirstOrDefault()
                .Select(w => w.text));

            return output;
        }
    }
}
