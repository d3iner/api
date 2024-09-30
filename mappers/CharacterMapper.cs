using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos;
using api.dtos.character;
using api.models;

namespace api.mappers
{
    public static class CharacterMapper
    {
        public static CharacterDto ToCharacterDTO(this Character characterModel)
        {
            return new CharacterDto
            {
                id = characterModel.id,
                name = characterModel.name,
                status = characterModel.status,
                gender = characterModel.gender,
                type = characterModel.type
            };
        }

        public static Character ToCharacterFromCreateDTO(this CharacterCreateDTO characterModel)

        {
            return new Character
            {
                name = characterModel.name,
                type = characterModel.type,
                status = characterModel.status,
                gender = characterModel.gender
            };
        }
    }
    
}