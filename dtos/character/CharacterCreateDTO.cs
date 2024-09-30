using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.character
{
    public class CharacterCreateDTO
    {
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
    }
}