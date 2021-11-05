using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class SubHeroClass
    {

        public int Id { get; set; }

        public string SubClassName { get; set; }

        public int SubClassLevel { get; set; }

        public int SubClassBonusAttack { get; set; }

        public int SubClassBonusDefense { get; set; }

        public int SubClassBonusHealth { get; set; }

        public int SubClassBonusCoins { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; } = new HashSet<Hero>();
    }
}
