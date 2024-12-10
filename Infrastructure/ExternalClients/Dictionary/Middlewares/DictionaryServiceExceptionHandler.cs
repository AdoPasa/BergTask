using Infrastructure.ExternalClients.Dictionary.Models;
using Refit;
using System.Net.Http.Json;

namespace Infrastructure.ExternalClients.Dictionary.Middlewares
{
    public class DictionaryServiceExceptionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                // If a word is not found it will return 404 status code, in that case owerride the response with an empty body
                if (!response.IsSuccessStatusCode)
                {
                    var emptyObject = new List<WordData>();
                    var newResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                    {
                        Content = JsonContent.Create(emptyObject),
                        ReasonPhrase = response.ReasonPhrase,
                        RequestMessage = response.RequestMessage,
                    };
                    return newResponse;
                }

                return response;
            }
            catch (ApiException ex)
            {
                return new HttpResponseMessage();
            }
            catch (HttpRequestException ex)
            {
                // Handle network-related errors
                throw new Exception("A network error occurred while calling the API.", ex);
            }
            catch (Exception ex)
            {
                // Log and rethrow other exceptions
                throw new Exception("An unexpected error occurred.", ex);
            }
        }
    }
}
