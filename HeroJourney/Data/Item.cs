using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class Item
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int AttackPoints { get; set; }
        [Required]
        public int DefensePoints { get; set; }
        [Required]
        public int HealthPoints { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsSpecial { get; set; }
        public int? ClassId { get; set; }
        public Class Class { get; set; }    
      

    }
}
