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
    public class NewsPageModel : PageModel
    {
        private readonly NewsClient _client;

        public NewsPageModel(NewsClient client)
        {
            _client = client;
        }

        public NewsItem Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _client.Get(id);

            return Page();
        }

        public async Task<IActionResult> OnPostLikeAsync(int id)
        {
            await _client.Like(id);
            return RedirectToPage(new {id = id});
        }
    }
}
