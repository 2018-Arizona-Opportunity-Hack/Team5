using System.Runtime.Serialization;

namespace FormProcessorApi.Models
{
    public class Answer
    {
        [IgnoreDataMember]
        public string AnswerId { get; set; } //1, a, etc.

        public string Text { get; set; }
        public int PixelCount { get; set; }
        public bool Selected { get; set; }

        public ARectangle Region { get; set; }
    }
}