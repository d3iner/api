using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos;
using api.dtos.character;
using api.mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;

namespace api.controllers
{
    [Route("api/v1/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CharacterController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CharacterDto>> GetAll()
        {
            var characters = _context.Characters.ToList().Select(s => s.ToCharacterDTO());
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public ActionResult<CharacterDto> GetById([FromRoute] int id)
        {
            var character = _context.Characters.Find(id);
            if (character == null)
                return NotFound();
            return Ok(character.ToCharacterDTO());
        }

        [HttpPost]
        public ActionResult<CharacterDto> Create([FromBody] CharacterCreateDTO characterCreateDto)
        {
            var characterModel = characterCreateDto.ToCharacterFromCreateDTO();
            _context.Characters.Add(characterModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = characterModel.id }, characterModel.ToCharacterDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CharacterDto> Update([FromRoute] int id, [FromBody] CharacterCreateDTO characterCreateDto)
        {
            var character = _context.Characters.FirstOrDefault(x => x.id == id);

            if (character == null) {
                return NotFound();
            }
            
            character.name = characterCreateDto.name;
            character.status = characterCreateDto.status;
            character.gender = characterCreateDto.gender;
            character.type = characterCreateDto.type;

            _context.SaveChanges();
            return Ok(character.ToCharacterDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CharacterDto> Delete([FromRoute] int id)
        {
            var character = _context.Characters.FirstOrDefault(x => x.id == id);

            if (character == null) {
                return NotFound();
            }

            _context.Characters.Remove(character);
            _context.SaveChanges();
            return NoContent();
        }
    }
}