using HeroJourney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Models
{
    public class HeroListingModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public string SubClassName { get; set; }
        public string SpecialItemName { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public int Kills { get; set; }

        public int XP { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public int Coins { get; set; }

        public ICollection<HeroRecords> HeroRecords { get; set; } = new HashSet<HeroRecords>();
        public virtual ICollection<EnemyRecords> Enemies { get; set; } = new HashSet<EnemyRecords>();

    }

}
