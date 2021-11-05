using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class ArenaStat
    {
        public int Id { get; set; }

        public int EnemyId { get; set; }
        public EnemyRecords Enemy { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
        public int Turn { get; set; }

        public int HeroDamage { get; set; }

        public int EnemyDamage { get; set; }

        public int HeroWinsXp { get; set; }

        public int HeroWinsCoins { get; set; }
    }
}
