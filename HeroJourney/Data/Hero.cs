using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Data
{
    public class Hero
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Level { get; set; }

        public int XP { get; set; }

        public int Coins { get; set; }

        public int Health { get; set; }
        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Kills { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class Class { get; set; }

        public int SubHeroClassId { get; set; }

        public SubHeroClass SubHeroClass { get; set; }

        [Required]
        public IdentityUser User { get; set; }

        public string UserId { get; set; }

        public bool IsDead { get; set; }

        public bool UseSpecialItem { get; set; }        
        public int? StoryId { get; set; }
        public Story Story { get; set; }
        public virtual ICollection<EnemyRecords> EnemyRecords { get; set; } = new HashSet<EnemyRecords>();

        public virtual ICollection<ArenaStat> ArenaStats { get; set; } = new HashSet<ArenaStat>();

    }
}
