using Microsoft.AspNetCore.Mvc;
using Advertisment.Core.Entities;
using Advertisment.Core.Services;
using Advertisment.Service;
using Advertisment.Core.DTOs;
using Advertisment.Models;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advertisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;   
        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _routeService = routeService;
            _mapper = mapper;
        }

        // GET: api/<RouteController>
        [HttpGet]
        public async Task<List<RouteDTO>> Get()
        {
            var aList= _routeService.GetAllAsync();
            var aDTOlist = new List<RouteDTO>();
            aDTOlist= _mapper.Map<List<RouteDTO>>(aList);
            return aDTOlist;
        }

        // GET api/<RouteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var r = _routeService.GetByIdAsync(id);
            var rot =_mapper.Map<RouteDTO>(r);
            if (r == null)
            {
                return NotFound();
            }
            return Ok(rot);
        }
        // POST api/<RouteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoutePostPutModel newRoute)
        {
            var route = new Core.Entities.Route { id = newRoute.id, name = newRoute.name, price = newRoute.price };
            var ro = _routeService.GetByIdAsync(newRoute.id);
            if (ro == null)
            {
                var r = _routeService.AddRouteAsync(route);
                return Ok(r);
            }

            return Conflict();
        }

        // PUT api/<RouteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RoutePostPutModel updateRoute)
        {
            var route = new Core.Entities.Route { id = updateRoute.id, name = updateRoute.name, price = updateRoute.price };
            var exitingRoute = _routeService.GetByIdAsync(updateRoute.id);  
            if(exitingRoute == null)
            {
                return NotFound();
            }
            if (id != updateRoute.id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
             _routeService.UpdateRouteAsync(route);
       
            return Ok(exitingRoute);

        }

        // DELETE api/<RouteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removeRoute = await _routeService.GetByIdAsync(id);
            if (removeRoute == null)
            {
                return NotFound();
            }
            _routeService.DeleteRouteAsync(removeRoute);   
            return NoContent();
        }
    }
}
