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
    public class AdverService : IAdverService
    {
        private readonly IAdverRepository _adverRepository;
        public AdverService(IAdverRepository adverRepository)
        {
            _adverRepository = adverRepository;
        }
        public async Task<List<Adver>> GetAdversAsync()
        {
            return await _adverRepository.GetAllAsync();
        }

        public async Task<Adver> GetAdverByIdAsync(int id)
        {
            return await _adverRepository.GetByIdAsync(id);
        }
        public async Task AddAdverAsync(Adver adver)
        {
            await _adverRepository.AddAdverAsync(adver);
        }
        public async Task<Adver> UpdateAdverAsync(int id,Adver adver)
        {
            await _adverRepository.UpdateAdverAsync(id, adver);
            return adver;
        }
    }
}
