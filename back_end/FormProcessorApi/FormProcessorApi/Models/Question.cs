
namespace FormProcessorApi.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public int RegionTopLeft { get; set; }
        public int RegionBottomLeft { get; set; }
        public int RegionTopRight { get; set; }
        public int RegionBottomRight { get; set; }

        public Answer[] Answers { get; set; }
    }
}
