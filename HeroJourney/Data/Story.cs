using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class Story
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; } = new HashSet<Hero>();

    }
}
