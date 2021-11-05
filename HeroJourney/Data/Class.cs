using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class Class
    {


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Health { get; set; }

        public int Attack { get; set; }

        public int Defence { get; set; }       
     
        public virtual ICollection<Hero> Heroes { get; set; } = new HashSet<Hero>();

        public virtual ICollection<Item> Items  { get; set; } = new HashSet<Item>();

        public virtual ICollection<SubHeroClass> SubHeroClasses { get; set; } = new HashSet<SubHeroClass>();


    }
}
