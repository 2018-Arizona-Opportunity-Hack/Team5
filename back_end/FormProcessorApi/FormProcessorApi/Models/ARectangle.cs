using System.Runtime.Serialization;

namespace FormProcessorApi.Models
{
    public class ARectangle
    {
        [IgnoreDataMember]
        public int ARectangleId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
