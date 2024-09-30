using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        // [Column(TypeName = "dicemail/18,2")]
        public string status { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;

    }
}