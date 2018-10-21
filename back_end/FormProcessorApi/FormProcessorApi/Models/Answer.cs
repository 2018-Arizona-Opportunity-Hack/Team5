namespace FormProcessorApi.Models
{
    public class Answer
    {
        public string AnswerId { get; set; } //1, a, etc.
        public string Text { get; set; }
        public int PixelCount { get; set; }
        public bool Selected { get; set; }

        public APoint RegionTopLeft { get; set; }
        public APoint RegionBottomLeft { get; set; }
        public APoint RegionTopRight { get; set; }
        public APoint RegionBottomRight { get; set; }
    }
}