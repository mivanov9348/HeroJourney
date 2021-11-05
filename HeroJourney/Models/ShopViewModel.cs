using HeroJourney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroJourney.Models
{
    public class ShopViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string HeroName { get; set; }

        public int HeroCoins { get; set; }

        public int HeroArmor { get; set; }

        public int HeroHealth { get; set; }

        public int HeroAttack { get; set; }

        public int HeroDefense { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }     

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
