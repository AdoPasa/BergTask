using Infrastructure.ExternalClients.Dictionary.Models;
using Refit;

namespace Infrastructure.ExternalClients.Dictionary
{
    public interface IDictionaryApiService
    {

        [Get("/v2/entries/en/{word}")]
        Task<List<WordData>> GetWordData([Query] string word);
    }
}
