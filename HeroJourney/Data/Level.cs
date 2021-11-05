using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class Level
    {
        public int Id { get; set; }

        public int Lvl { get; set; }

        public int MinimumExperience { get; set; }

        public int MaximumExperience { get; set; }
    }
}
