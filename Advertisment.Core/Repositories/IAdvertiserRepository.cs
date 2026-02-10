using Advertisment.Core.DTOs;
using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.Repositories
{
    public interface IAdvertiserRepository
    {
        public Task<List<Advertiser>> GetAllAsync();
        public Task<Advertiser> GetByIdAsync(int id);
        public Task<Advertiser> AddAdverAsync(Advertiser advertiser);
        public Task<Advertiser> UpdateAdvertiserAsync(int id,Advertiser advertiser);
        public Task<Advertiser> DeleteAdvertiser(Advertiser advertiser);
        public Task SaveAsync();

    }
}
