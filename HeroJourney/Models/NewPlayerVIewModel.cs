using HeroJourney.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Models
{
    public class NewPlayerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Level { get; set; }

        public int XP { get; set; }

        public int Coins { get; set; }

        public int Health { get; set; }
        public int Armor { get; set; }
        public int Attack { get; set; }

        public int Defence { get; set; }

        public Class Class { get; set; }
        public int ClassId { get; set; }

        public string ClassName{ get; set; }
 

    }
}
