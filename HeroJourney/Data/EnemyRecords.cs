using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class EnemyRecords
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public string TypeName { get; set; }

        public int Level { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Health { get; set; }

        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public bool IsDead { get; set; }

        public virtual ICollection<ArenaStat> ArenaStats { get; set; } = new HashSet<ArenaStat>();
    }
}
