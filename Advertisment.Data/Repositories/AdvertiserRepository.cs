using Advertisment.Core.DTOs;
using Advertisment.Core.Entities;
using Advertisment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Data.Repositories
{
    public class AdvertiserRepository : IAdvertiserRepository
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
            return await _context.advertisers.FirstAsync(a => a.id == id);
        }
        public async Task<Advertiser> AddAdverAsync(Advertiser advertiser)
        {
            await _context.advertisers.AddAsync(advertiser);
            await SaveAsync();
            return advertiser;
        }

        public async Task<Advertiser> UpdateAdvertiserAsync(int id, Advertiser advertiser)
        {
            var a = await GetByIdAsync(id);
            a.id = advertiser.id;
            a.email = advertiser.email;
            a.sumGeneralLikes = advertiser.sumGeneralLikes;
            a.name = advertiser.name;
            a.Route = advertiser.Route;
            await SaveAsync();
            return a;
        }
        public async Task<Advertiser> DeleteAdvertiser(Advertiser advertiser)
        {
            _context.advertisers.Remove(advertiser);
            await SaveAsync();
            return advertiser;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
