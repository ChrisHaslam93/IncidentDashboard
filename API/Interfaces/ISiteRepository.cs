using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ISiteRepository
    {
        public Task<IEnumerable<Site>> GetSites();
        public Task<Site> AddSite(SiteDto newSite);
        public Task<Site> UpdateSite(SiteDto updatedSite, int siteId);
        public Task RemoveSite(int id);
    }
}