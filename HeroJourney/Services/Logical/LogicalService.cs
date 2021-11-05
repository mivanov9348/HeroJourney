namespace HeroJourney.Services.Logical
{
    using HeroJourney.Controllers;
    using HeroJourney.Data;
    using System;
    using System.Linq;

    public class LogicalService : ILogicalService
    {
        private readonly HeroJourneyDbContext data;
        private Random rnd;
        public LogicalService(HeroJourneyDbContext data)
        {
            this.data = data;
            rnd = new Random();
        }

        public static int XpReward(int level)
        {
            var xp = 0;

            if (level >= 1 && level <= 3)
            {
                xp = 40;
            }
            if (level > 3 && level <= 7)
            {
                xp = 70;
            }
            if (level > 7 && level <= 9)
            {
                xp = 90;
            }
            if (level >= 10)
            {
                xp = 140;
            }

            return xp;

        }

        public static int CoinsReward(int level)
        {
            var coins = 0;

            if (level >= 1 && level <= 3)
            {
                coins = 200;
            }
            if (level > 3 && level <= 7)
            {
                coins = 300;
            }
            if (level > 7 && level <= 9)
            {
                coins = 400;
            }
            if (level >= 10)
            {
                coins = 600;
            }

            return coins;
        }

        public int ChangeTurn(int turn)
        {
            var returnNum = 0;
            if (turn == 1)
            {
                returnNum = 2;
            }
            else
            {
                returnNum = 1;
            }
            return returnNum;
        }

        public void CheckHealth(Data.Hero hero, EnemyRecords currEnemy, int turn)
        {
            if (turn == 1)
            {
                if (currEnemy.Health <= 0)
                {
                    currEnemy.Health = 0;
                    currEnemy.IsDead = true;
                }
            }
            if (turn == 2)
            {
                if (hero.Health <= 0)
                {
                    hero.Health = 0;
                    hero.IsDead = true;
                }
            }
            this.data.SaveChanges();
        }

        public bool EnoughCoins(int coins, int price)
        {
            if (coins >= price)
            {
                return true;
            }
            if (coins < price)
            {
                return false;
            }
            return false;
        }

        public void CalculateAfterFight(Hero hero, EnemyRecords currEnemy, ArenaStat arena)
        {

            if (hero.Health > 0)
            {
                currEnemy.IsDead = true;
                hero.Kills++;
                var minXp = DataConstant.HeroWinBonus.minXp;
                var minCoins = DataConstant.HeroWinBonus.minCoins;
                var maxXp = XpReward(hero.Level);
                var maxCoins = CoinsReward(hero.Level);

                arena.HeroWinsCoins = rnd.Next(minCoins, maxCoins);
                arena.HeroWinsXp = rnd.Next(minXp, maxXp);

                hero.Coins += arena.HeroWinsCoins;
                hero.XP += arena.HeroWinsXp;
            }
            if (currEnemy.Health > 0)
            {
                hero.IsDead = true;
            }

            this.data.SaveChanges();

        }

        public void CreateArena(EnemyRecords enemy, Hero hero)
        {
            var newArena = new ArenaStat
            {
                Hero = hero,
                HeroId = hero.Id,
                Enemy = enemy,
                EnemyId = enemy.Id,
                EnemyDamage = 0,
                HeroDamage = 0,
                HeroWinsCoins = 0,
                HeroWinsXp = 0
            };
            this.data.ArenaStats.Add(newArena);
            this.data.SaveChanges();
        }

        public ArenaStat GetCurrArena(Hero hero, EnemyRecords enemy) => this.data.ArenaStats.FirstOrDefault(x => x.HeroId == hero.Id && x.EnemyId == enemy.Id);

        public void CalculateAttack(Hero hero, EnemyRecords enemy, ArenaStat arena)
        {
           if (arena.Turn == 1)
           {
               var attackDamage = rnd.Next(1, hero.Attack);
               attackDamage += attackDamage / hero.Level;
               if (enemy.Defense > 0)
               {
                   enemy.Defense -= attackDamage;
                   if (enemy.Defense < 0)
                   {
                       var diff = Math.Abs(0 - enemy.Defense);
                       enemy.Health -= diff;
                       enemy.Defense = 0;
                   }
               }
               else
               {
                   enemy.Health -= attackDamage;
               }
          
               arena.EnemyDamage = attackDamage;
          
           }
           if (arena.Turn == 2)
           {
               var attackDamage = rnd.Next(1, enemy.Attack);
               attackDamage += attackDamage / enemy.Level;
               if (hero.Defense > 0)
               {
                   hero.Defense -= attackDamage;
                   if (hero.Defense < 0)
                   {
                       var diff = Math.Abs(0 - hero.Defense);
                       hero.Health -= diff;
                       hero.Defense = 0;
                   }
               }
               else
               {
                   hero.Health -= attackDamage;
               }
          
               arena.HeroDamage = attackDamage;          
           }
          
           this.data.SaveChanges();
        }
    }
}
