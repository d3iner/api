using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace api.models
{
    public class Episode
    {
        public int id { get; set; }
        public string episode { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;
        public string air_date { get; set; } = string.Empty;
        // public List<Character> characters { get; set; } = new List<Character>;
    }
}