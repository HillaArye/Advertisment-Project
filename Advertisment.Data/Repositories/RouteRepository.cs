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
    public class RouteRepository : IRouteRepository
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
            return await _context.routes.FirstAsync(a => a.id == id);
        }
        public async Task<Route> AddRouteAsync(Route route)
        {
            await _context.routes.AddAsync(route);
            await SaveAsync();
            return route;
        }
        public async Task<Route> UpdateRouteAsync(Route route)
        {
          
            var a = await GetByIdAsync(route.id);
            a.id = route.id;
            a.name=route.name;
            a.price=route.price;
            await SaveAsync();
            return route;
        }
        public  async Task<Route> DeleteRoute(Route route)
        {
            _context.routes.Remove(route);
           await SaveAsync();
            return route;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
