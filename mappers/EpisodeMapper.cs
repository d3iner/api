using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.episode;
using api.models;

namespace api.mappers
{
    public static class EpisodeMapper
    {
        public static EpisodeDto ToEpisodeDTO(this Episode episode){
            return new EpisodeDto{
                id = episode.id,
                name = episode.name,
                episode = episode.episode,
                air_date = episode.air_date,
            };
        }

        public static Episode ToEpisodeFromCreateDto(this EpisodeCreateDto episodes){
            return new Episode{
                name = episodes.name,
                air_date = episodes.air_date,
                episode = episodes.episode,
            };
        }
    }
}