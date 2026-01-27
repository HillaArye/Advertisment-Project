using Advertisment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Core.Repositories
{
    public interface IRouteRepository
    {
        public Task<List<Route>> GetAllAsync();
        public Task<Route> GetByIdAsync(int id);
        public Task<Route> AddRouteAsync(Route route);
        public Task<Route> UpdateRouteAsync(Route route);
        public Task<Route> DeleteRouteAsync(Route route);
        public Task SaveAsync();


    }
}
