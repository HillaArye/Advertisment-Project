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
    public class RouteService:IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public async Task<List<Route>> GetAllAsync()
        {
            return  await _routeRepository.GetAllAsync();
        }

        public async Task<Route> GetByIdAsync(int id)
        {
            return await _routeRepository.GetByIdAsync(id);
        }

        public async Task<Route> AddRouteAsync(Route route)
        {
            await _routeRepository.AddRouteAsync(route);
            return route;
        }
        public async Task<Route> UpdateRouteAsync(Route route)
        {
            await _routeRepository.UpdateRouteAsync(route);
            return route;
        }

        public async Task<Route> DeleteRouteAsync(Route route)
        {
            await _routeRepository.DeleteRouteAsync(route);
            return route;
        }

    }
}
