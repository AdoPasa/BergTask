namespace Infrastructure.ExternalClients.Dictionary.Models
{
    public class WordDefinition
    {
        public string Definition { get; set; } = string.Empty;
        public string Example { get; set; } = string.Empty;
        public List<string> Synonyms { get; set; } = new List<string>();
        public List<string> Antonyms { get; set; } = new List<string>();
    }
}
