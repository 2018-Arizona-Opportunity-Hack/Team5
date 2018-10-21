using System.Runtime.Serialization;

namespace FormProcessorApi.Models
{
    public class Question
    {
        [IgnoreDataMember]
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public ARectangle Region { get; set; }

        public Answer[] Answers { get; set; }
    }
}
