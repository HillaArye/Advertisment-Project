using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.Services
{
    public interface IAdverService
    {
        public Task<List<Adver>> GetAdversAsync();
        public Task<Adver> GetAdverByIdAsync(int id);
        public Task AddAdverAsync(Adver adver);
        public Task<Adver> UpdateAdverAsync(int id, Adver adver);

    }
}
