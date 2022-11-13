using GeradorURL.Data;
using GeradorURL.Model;
using GeradorURL.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GeradorURL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly DataContext _context;
        public UrlController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Url>>> AddUrl(string urlLonga)
        {
            if (Util.IsUrlValid(urlLonga))
            {
                return BadRequest("This Url is not Valid!");
            }
            var url = await _context.Urls.FirstOrDefaultAsync(x => x.UrlLonga == urlLonga);

            if (url != null)
            {
                return BadRequest("This Url is alread converted: " + url.UrlCurta);
            }

            var urlCurta = Util.generateUrlCurta();

            var urlObj = new Url(urlLonga, urlCurta);

            _context.Urls.Add(urlObj);
            await _context.SaveChangesAsync();

            return Ok("Link: " + urlObj.UrlCurta);
        }

        [HttpGet]
        public async Task<ActionResult<List<Url>>> GetAllUrls() 
        {
            return Ok(await _context.Urls.ToListAsync());

        }
        [HttpGet("{urlCurta}")]
        public async Task<ActionResult<List<Url>>> GetByUrlLonga(string urlCurta)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(x => x.UrlCurta == urlCurta); 
            if (url == null)
            {
                return BadRequest("Url not found");
            } 

            return Ok( url.UrlLonga);

        }


    }
}
