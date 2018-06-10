using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebApp.Pages.Extensions;
using WebApp.Shared.Model;

namespace WebApp.Pages.Clients
{
    public class NewsClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<NewsClient> _logger;

        public NewsClient(HttpClient client, ILogger<NewsClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IEnumerable<NewsItem>> GetAll()
        {
            var response = await _client.GetAsync("");
            Log(response);
            return response.ContentAsType<IEnumerable<NewsItem>>();
        }

        public async Task<NewsItem> Get(int id)
        {
            var response = await _client.GetAsync($"{id}");
            Log(response);
            return response.ContentAsType<NewsItem>();
        }

        public async Task Like(int id)
        {
            var response = await _client.PostAsync($"{id}/like", null);
            Log(response);
            return;
        }

        private void Log(HttpResponseMessage response)
        {
            _logger.LogInformation($"Call to {response.RequestMessage.RequestUri} ended with status code {response.StatusCode}");
        }
    }
}