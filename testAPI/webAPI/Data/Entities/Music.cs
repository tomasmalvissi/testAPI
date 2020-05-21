using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Data.Entities
{
    public class Music
    {
        public int Id { get; set; }
        [Required]
        public string NameSong { get; set; }
        [Required]
        public string Artist { get; set; }

    }
}
