using Advertisment.Core.DTOs;
using Advertisment.Core.Entities;
using Advertisment.Core.Repositories;
using Advertisment.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Service
{
    public class AdvertiserService: IAdvertiserService
    {

        private readonly IAdvertiserRepository _advertiserRepository;
        public AdvertiserService(IAdvertiserRepository advertiserRepository)
        {
            _advertiserRepository = advertiserRepository;
        }
        public async Task<List<Advertiser>> GetAllAsync()
        {
            return await _advertiserRepository.GetAllAsync();
        }

        public async Task<Advertiser> GetByIdAsync(int id)
        {
            return await _advertiserRepository.GetByIdAsync(id);
        }

        public async Task<Advertiser> AddAdverAsync(Advertiser advertiser)
        {
            await _advertiserRepository.AddAdverAsync(advertiser);
            return advertiser;
        }
        public async Task<Advertiser> UpdateAdvertiserAsync(int id,Advertiser advertiser)
        {
            await _advertiserRepository.UpdateAdvertiserAsync(id,advertiser);
            return advertiser;
        }

        public async Task<Advertiser> DeleteAdvertiserAsync(Advertiser advertiser)
        {
            await _advertiserRepository.DeleteAdvertiserAsync(advertiser);
            return advertiser;
        }

    }
}

