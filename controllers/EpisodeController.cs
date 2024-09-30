using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.episode;
using api.mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/v1/episode")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EpisodeController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EpisodeDto>> GetAll()
        {
            var episodes = _context.Episode.ToList().Select(s => s.ToEpisodeDTO());
            return Ok(episodes);
        }
        [HttpGet("{id}")]
        public ActionResult<EpisodeDto> GetById([FromRoute] int id)
        {
            var episodes = _context.Episode.Find(id);
            if (episodes == null)
                return NotFound();
            return Ok(episodes.ToEpisodeDTO());
        }

        [HttpPost]
        public ActionResult<EpisodeDto> Create([FromBody] EpisodeCreateDto episodeCreateDto)
        {
            var episodeModel = episodeCreateDto.ToEpisodeFromCreateDto();
            _context.Episode.Add(episodeModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = episodeModel.id }, episodeModel.ToEpisodeDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<EpisodeDto> Update([FromRoute] int id, [FromBody] EpisodeCreateDto episodeCreateDto)
        {
            var episode = _context.Episode.FirstOrDefault(x => x.id == id);

            if (episode == null) {
                return NotFound();
            }
            
            episode.name = episodeCreateDto.name;
            episode.air_date = episodeCreateDto.air_date;

            _context.SaveChanges();
            return Ok(episode.ToEpisodeDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<EpisodeDto> Delete([FromRoute] int id)
        {
            var episode = _context.Episode.FirstOrDefault(x => x.id == id);

            if (episode == null) {
                return NotFound();
            }

            _context.Episode.Remove(episode);
            _context.SaveChanges();
            return NoContent();
        }
    }
}