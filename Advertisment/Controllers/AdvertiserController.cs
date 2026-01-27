using Microsoft.AspNetCore.Mvc;
using Advertisment.Core.Services;
using Advertisment.Core.Entities;
using Advertisment.Service;
using Advertisment.Models;
using AutoMapper;
using Advertisment.Core.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advertisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertiserController : ControllerBase
    {
        private readonly IAdvertiserService _advertiserService;
        private readonly IMapper _mapper;

        public AdvertiserController(IAdvertiserService advertiserSrvice, IMapper mapper)
        {
            _advertiserService = advertiserSrvice;
            _mapper = mapper;
        }

        // GET: api/<AdvertiserController>
        [HttpGet]
        public async Task<List<AdvertiserDTO>> Get()
        {
            var aList = await _advertiserService.GetAllAsync();
            var aDTOlist = new List<AdvertiserDTO>();
            aDTOlist = _mapper.Map<List<AdvertiserDTO>>(aList);
            return aDTOlist;
        }

        // GET api/<AdvertiserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var adv =  _advertiserService.GetByIdAsync(id);
            var a = _mapper.Map<AdvertiserDTO>(adv);
            if (adv == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        // POST api/<AdvertiserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdvertiserPostPutModel newAdvertiser)
        {
            var advertiser = new Advertiser { id = newAdvertiser.id, name = newAdvertiser.name, email = newAdvertiser.email, sumGeneralLikes = newAdvertiser.sumGeneralLikes };
            var adv = _advertiserService.GetByIdAsync(newAdvertiser.id);
            if (adv == null)
            {
                var a = _advertiserService.AddAdverAsync(advertiser);
                return Ok(a);
            }

            return Conflict();
        }

        // PUT api/<AdvertiserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AdvertiserPostPutModel updateAdvertiser)
        {
            var advertiser = new Advertiser { id = updateAdvertiser.id, name = updateAdvertiser.name, email = updateAdvertiser.email, sumGeneralLikes = updateAdvertiser.sumGeneralLikes };

            var exitingAdver = _advertiserService.GetByIdAsync(id);
            if (exitingAdver == null)
            {
                return NotFound();
            }
            if (id != updateAdvertiser.id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
            _advertiserService.UpdateAdvertiserAsync(id,advertiser);
            return Ok(exitingAdver);
        }
        
        // DELETE api/<AdvertiserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removeAdvertiser = await _advertiserService.GetByIdAsync(id);
            if (removeAdvertiser == null)
            {
                return NotFound();
            }
            _advertiserService.DeleteAdvertiserAsync(removeAdvertiser);
            return NoContent();
        }
    }
}
