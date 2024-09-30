using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.episode
{
    public class EpisodeDto
    {
        public int id { get; set; }
        public string episode { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;
        public string air_date { get; set; }  = string.Empty;
    }
}