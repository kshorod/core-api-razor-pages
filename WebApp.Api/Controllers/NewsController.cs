using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Shared.Model;

namespace WebApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/News")]
    public class NewsController : Controller
    {
        private static readonly NewsItem[] _news = new[]
        {
            new NewsItem(1, "Fake News", "Mauris vel convallis massa, at luctus dolor. Nulla feugiat felis sed eros tincidunt, in condimentum nibh interdum. Vestibulum euismod felis eu sem consequat, quis volutpat lorem porta. Nunc aliquam eleifend tincidunt. Praesent nec turpis ultricies, facilisis diam et, faucibus dui. Curabitur sem est, sagittis a dolor ut, faucibus mollis lacus. Praesent volutpat vestibulum rutrum. Nam tempus at ipsum non tempor. "),
            new NewsItem(2, "Almost True News", "Pellentesque egestas mollis pharetra. Vivamus commodo, urna in accumsan aliquet, justo metus porta sem, at porta metus velit ut sem. Curabitur facilisis, turpis ullamcorper imperdiet feugiat, risus metus dapibus libero, semper elementum lorem diam eu nibh. In hac habitasse platea dictumst. Nam a quam eu ligula lacinia tincidunt non ut magna. In sodales justo ipsum, sed vulputate purus gravida at. Fusce fermentum scelerisque metus quis accumsan. Nulla a rutrum felis, ut euismod dui. Proin risus elit, pharetra non ante eu, dapibus maximus magna. Nullam ac purus ante. "),
            new NewsItem(3, "Irrelevant stuff", "Morbi vel tempus mi. In eu lectus ante. Nullam volutpat odio neque, quis viverra lorem lobortis id. In hac habitasse platea dictumst. Aenean sem lacus, imperdiet ac congue eget, elementum non tortor. Praesent aliquet pretium lobortis. Maecenas hendrerit neque vitae ante imperdiet, a maximus diam placerat. Donec sed consequat orci. Quisque tempor arcu sit amet mi fringilla, eget porttitor odio tempus. Fusce et dui sed nisi tempor tristique vitae aliquam eros. Phasellus porttitor euismod mi sed facilisis. Nunc sed sagittis erat, sed faucibus nisi. Suspendisse tempor finibus tincidunt. ")
        };

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(NewsItem[]))]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            return Ok(_news);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(NewsItem))]
        [ProducesResponseType(204)]
        public IActionResult Get(int id)
        {
            var news = _news.FirstOrDefault(x => x.Id == id);
            if (news != null)
            {
                return Ok(news);
            }

            return NoContent();
        }

        [HttpPost("{id}/like")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Like(int id)
        {
            var news = _news.FirstOrDefault(x => x.Id == id);
            if (news == null)
            {
                return BadRequest();
            }

            news.Likes++;
            return Ok();
        }
    }
}