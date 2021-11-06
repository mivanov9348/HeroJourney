using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class HeroRecords
    {

        public int Id { get; set; }

        public int HeroId { get; set; }

        public string Name{ get; set; }

        public string ClassName { get; set; }

        public string SubClassName { get; set; }        

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Xp { get; set; }

        public int Level { get; set; }

        public int Kills { get; set; }
    }
}
