using Advertisment.Core.DTOs;
using Advertisment.Core.Entities;
using Advertisment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Data.Repositories
{
    public class AdvertiserRepository: IAdvertiserRepository
    {
        private readonly DataContext _context;
        public AdvertiserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Advertiser>> GetAllAsync()
        {
            return await _context.advertisers.ToListAsync();
        }
        public async Task<Advertiser> GetByIdAsync(int id)
        {
            return await _context.advertisers.ToList().FindAsync(a => a.id == id);
        }
        public async Task<Advertiser> AddAdverAsync(Advertiser advertiser)
        {
            await _context.advertisers.AddAsync(advertiser);
            return advertiser;
        }

        public async Task<Advertiser> UpdateAdvertiser(int id,Advertiser advertiser)
        {
            var a = await GetByIdAsync(id);
            a.id = advertiser.id;
            a.email = advertiser.email;
            a.sumGeneralLikes = advertiser.sumGeneralLikes;
            a.name = advertiser.name;
            a.Route = advertiser.Route;
         
            return a;
        }
        public async Task<Advertiser> DeleteAdvertiserAsync(Advertiser advertiser)
        {
             await _context.advertisers.RemoveAsync(advertiser);
            return advertiser;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
