using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.dtos.episode
{
    public class EpisodeCreateDto
    {
        public string episode { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string air_date { get; set; } = string.Empty;
    }
}