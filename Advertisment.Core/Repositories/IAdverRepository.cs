using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.Repositories
{
    public interface IAdverRepository
    {
        public Task<List<Adver>> GetAllAsync();
        public Task<Adver> GetByIdAsync(int id);
        public Task<Adver> AddAdverAsync(Adver adver);
        public Task<int> GetByIndexAsync(int index);
        public Task<Adver> UpdateAdverAsync(int id,Adver adver);
        public Task SaveAsync();
    }
}
