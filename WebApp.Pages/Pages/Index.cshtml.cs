using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Pages.Clients;
using WebApp.Shared.Model;

namespace WebApp.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NewsClient _client;

        public IndexModel(NewsClient client)
        {
            _client = client;
        }

        public List<NewsItem> NewsList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var news = await _client.GetAll();
            NewsList = news.ToList();

            return Page();
        }
    }
}
