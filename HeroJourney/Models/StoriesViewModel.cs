using HeroJourney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Models
{
    public class StoriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; } = new HashSet<Story>();
    }
}
