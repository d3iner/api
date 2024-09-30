using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.episode;
using api.dtos.location;
using api.mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/v1/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LocationController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocationDto>> GetAll()
        {
            var episodes = _context.Location.ToList().Select(s => s.ToLocationDto());
            return Ok(episodes);
        }
        [HttpGet("{id}")]
        public ActionResult<LocationDto> GetById([FromRoute] int id)
        {
            var episodes = _context.Location.Find(id);
            if (episodes == null)
                return NotFound();
            return Ok(episodes.ToLocationDto());
        }

        [HttpPost]
        public ActionResult<LocationDto> Create([FromBody] LocationCreateDto episodeCreateDto)
        {
            var locationModel = episodeCreateDto.ToLocationFromCreateDto();
            _context.Location.Add(locationModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = locationModel.id }, locationModel.ToLocationDto());
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<LocationDto> Update([FromRoute] int id, [FromBody] LocationCreateDto episodeCreateDto)
        {
            var episode = _context.Location.FirstOrDefault(x => x.id == id);

            if (episode == null) {
                return NotFound();
            }
            
            episode.name = episodeCreateDto.name;

            _context.SaveChanges();
            return Ok(episode.ToLocationDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<LocationDto> Delete([FromRoute] int id)
        {
            var location = _context.Location.FirstOrDefault(x => x.id == id);

            if (location == null) {
                return NotFound();
            }

            _context.Location.Remove(location);
            _context.SaveChanges();
            return NoContent();
        }
    }
}