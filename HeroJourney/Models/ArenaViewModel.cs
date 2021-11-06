using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Models
{
    public class ArenaViewModel
    {

        public int Id{ get; set; }

        public string HeroName { get; set; }

        public int HeroAttack { get; set; }

        public int HeroDefense { get; set; }

        public int HeroHealth { get; set; }

        public int HeroCoins { get; set; }

        public int HeroXP { get; set; }

        public int HeroLevel { get; set; }
        public int HeroDamage { get; set; }

        public int HeroXpWin { get; set; }

        public int HeroCoinsWin { get; set; }

        public string EnemyName { get; set; }

        public int EnemyAttack { get; set; }

        public int EnemyDamage { get; set; }

        public int EnemyDefense { get; set; }

        public int EnemyHealth { get; set; }

        public int EnemyId { get; set; }

        public string HeroImageUrl { get; set; }
        public int Turn { get; set; }
    }
}
