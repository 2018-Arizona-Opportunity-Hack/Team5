
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

namespace FormOcrFunction
{
    public static class RegionProcessor
    {
        [FunctionName("RegionProcessor")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Image data received.");
            
            string requestBody = new StreamReader(req.Body).ReadToEnd();
            byte[] data = (byte[])JsonConvert.DeserializeObject(requestBody);

            log.Info("Starting crop");
            using (Image<Rgba32> image = Image.Load(data))
            {
                var clone = image.Clone();
                clone.Mutate(x => x.Crop(100, 100));

                log.Info("Requesting OCR");

            }

            string name = null;
            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
