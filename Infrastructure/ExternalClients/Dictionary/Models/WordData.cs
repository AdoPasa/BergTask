namespace Infrastructure.ExternalClients.Dictionary.Models
{
    public class WordData
    {
        public string Word { get; set; } = string.Empty;
        public string Phonetic { get; set; } = string.Empty;
        public List<WordPhonetic> Phonetics { get; set; } = new List<WordPhonetic>();
        public string Origin { get; set; } = string.Empty;
        public List<WordMeaning> Meanings { get; set; } = new List<WordMeaning>();
    }
}
