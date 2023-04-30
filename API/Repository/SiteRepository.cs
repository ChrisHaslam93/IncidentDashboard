using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Dapper;

namespace API.Repository
{
    public class SiteRepository : ISiteRepository
    {
        private readonly DapperContext _context;

        public SiteRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<Site> AddSite(SiteDto newSite)
        {
            var query = @"insert into Site output inserted.* values(@Address1, @Address2, @City)";
            
            using var connection = _context.CreateConnection();
            Site site = await connection.QuerySingleAsync<Site>(query, new
            {
                Address1 = newSite.Address1,
                Address2 = newSite.Address2,
                City = newSite.City
            });

            return site;
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            var query = "select * from Site";
            
            using var connection = _context.CreateConnection();
            var sites = await connection.QueryAsync<Site>(query);
            return sites;
        }

        public async Task RemoveSite(int id)
        {
            var query = "delete from Site where SiteId = @SiteId";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new{ SiteId = id });
        }

        public async Task<Site> UpdateSite(SiteDto updatedSite, int siteId)
        {
            var query = "update Site set address1 = @Address1, address2 = @Address2, city = @City output inserted.* where SiteId = @SiteId";
            using var connection = _context.CreateConnection();
            Site site = await connection.QuerySingleAsync<Site>(query, new
            {
                Address1 = updatedSite.Address1,
                Address2 = updatedSite.Address2,
                City = updatedSite.City,
                SiteId = siteId
            });

            return site;
        }
    }
}