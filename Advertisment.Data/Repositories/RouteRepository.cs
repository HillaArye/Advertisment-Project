using Advertisment.Core.Entities;
using Advertisment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment.Data.Repositories
{
    public class RouteRepository: IRouteRepository
    {
        private readonly DataContext _context;
        public RouteRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Route>> GetAllAsync()
        {
            return await _context.routes.ToListAsync();
        }
        public async Task<Route> GetByIdAsync(int id)
        {
            return await _context.routes.ToList().FindAsync(a => a.id == id);
        }
        public async Task<Route> AddRouteAsync(Route route)
        {
            await _context.routes.AddAsync(route);
            return route;
        }
        public async Task<Route> UpdateRouteAsync(Route route)
        {
            await _context.routes.UpdateAsync(route);
            return route;
        }
        public async Task<Route> DeleteRoute(Route route)
        {
            await _context.routes.RemoveAsync(route);
            return route;
        }
        public  async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); 
        }

    }
}
