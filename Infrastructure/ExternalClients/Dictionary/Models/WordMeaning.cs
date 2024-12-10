namespace Infrastructure.ExternalClients.Dictionary.Models
{
    public class WordMeaning
    {
        public string PartOfSpeech { get; set; } = string.Empty;
        public List<WordDefinition> Definitions { get; set; } = new List<WordDefinition>();
    }
}
