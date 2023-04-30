using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteRepository;

        public SiteController(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSites()
        {
            var sites = await _siteRepository.GetSites();
            return Ok(sites);
        }

        [HttpPost]
        public async Task<ActionResult<Site>> AddSite(SiteDto newSite)
        {
            var site = await _siteRepository.AddSite(newSite);
            return Ok(site);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Site>> UpdateSite(int id, [FromBody] SiteDto updatedSite)
        {
            var site = await _siteRepository.UpdateSite(updatedSite, id);
            return Ok(site);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveSite(int id)
        {
            await _siteRepository.RemoveSite(id);
            return Ok("Site successfully removed.");
        }
    }
}