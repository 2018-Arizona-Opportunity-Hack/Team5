namespace FormProcessorApi.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public APoint RegionTopLeft { get; set; }
        public APoint RegionBottomLeft { get; set; }
        public APoint RegionTopRight { get; set; }
        public APoint RegionBottomRight { get; set; }

        public Answer[] Answers { get; set; }
    }
}
