namespace FormProcessorApi.Models
{
    public class Answer
    {
        public string AnswerId { get; set; } //1, a, etc.
        public string Text { get; set; }
        public int PixelCount { get; set; }
        public bool Selected { get; set; }

        public int RegionTopLeft { get; set; }
        public int RegionBottomLeft { get; set; }
        public int RegionTopRight { get; set; }
        public int RegionBottomRight { get; set; }
    }
}