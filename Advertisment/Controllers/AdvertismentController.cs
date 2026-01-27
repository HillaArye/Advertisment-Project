using Microsoft.AspNetCore.Mvc;
using Advertisment.Core.Services;
using Advertisment.Core.Entities;
using Advertisment.Core.DTOs;
using Advertisment.Service;
using Advertisment.Models;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Advertisment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdvertismentController : ControllerBase
    {

        private readonly IAdverService _adverService;
        private readonly IMapper _mapper;
        public AdvertismentController(IAdverService adverService, IMapper mapper)
        {
            _adverService = adverService;
            _mapper = mapper;
        }


        // GET: api/<AdvertismentController>
        [HttpGet]
        public async Task<List<AdverDTO>> Get()
        {
            var aList = await  _adverService.GetAdversAsync(); 
            var aDTOlist = new List<AdverDTO>();
            aDTOlist = _mapper.Map<List<AdverDTO>>(aList);
            return aDTOlist;
        }

        // GET api/<AdvertismentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var adv = _adverService.GetAdverByIdAsync(id);
            var a= _mapper.Map<AdvertiserDTO>( adv);
            if (adv == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        // POST api/<AdvertismentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AdverPostPutModel newAdver)
        {
            var adver = new Adver { id=newAdver.id,date=newAdver.date,start=newAdver.start,end=newAdver.end,desc=newAdver.desc,sumLikes=newAdver.sumLikes};
            var adv = _adverService.GetAdverByIdAsync(newAdver.id);
            if (adv == null)
            {
                var a=_adverService.AddAdverAsync(adver);
                return Ok(a);
            }

            return Conflict();
 
        }

        // PUT api/<AdvertismentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AdverPostPutModel updateAdver)
        {
            var adver = new Adver { id = updateAdver.id, date = updateAdver.date, start = updateAdver.start, end = updateAdver.end, desc = updateAdver.desc, sumLikes = updateAdver.sumLikes };
            var exitingAdver = _adverService.GetAdverByIdAsync(updateAdver.id);
            if (exitingAdver == null)
            {
                return NotFound();
            }
            if (id != updateAdver.id)
            {
                return BadRequest("ID in URL does not match ID in body");
            }
            _adverService.UpdateAdverAsync(id,adver) ;
            return Ok(exitingAdver);
        }

       
    }
}
