using Domain.Base;

namespace Domain.Entities
{
    public class Meaning
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
        public string Example { get; set; } = string.Empty;
        public string Phonetics { get; set; } = string.Empty;
        public string PhoneticsAudio { get; set; } = string.Empty;
    }
}
