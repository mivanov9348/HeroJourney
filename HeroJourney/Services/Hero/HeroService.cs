namespace HeroJourney.Services.Hero
{
    using HeroJourney.Data;
    using HeroJourney.Models;
    using System.Linq;

    public class HeroService : IHeroService
    {
        private readonly HeroJourneyDbContext data;

        public HeroService(HeroJourneyDbContext data)
        {
            this.data = data;
        }

        public void ChangeUserName(Hero hero, string name)
        {
            hero.Name = name;
            this.data.SaveChanges();
        }

        public void checkLevel(int experience, Hero hero)
        {
            var level = this.data.Levels.FirstOrDefault(x => x.MaximumExperience >= experience && x.MinimumExperience <= experience).Lvl;
            hero.Level = level;

            var currentSubClass = this.data.SubHeroClasses.Where(x => x.ClassId == hero.ClassId).ToList();

            if (hero.Level >= 1 && hero.Level < 8)
            {
                hero.SubHeroClassId = currentSubClass.FirstOrDefault(x => x.SubClassLevel == 1).Id;
            }
            if (hero.Level >= 9 && hero.Level < 16)
            {
                hero.SubHeroClassId = currentSubClass.FirstOrDefault(x => x.SubClassLevel == 2).Id;
            }
            if (hero.Level >= 16 && hero.Level <= 18)
            {
                hero.SubHeroClassId = currentSubClass.FirstOrDefault(x => x.SubClassLevel == 3).Id;
            }

            this.data.SaveChanges();
        }

        public Hero Create(string name, Class classType, int classId, SubHeroClass SubHeroClass, int SubHeroClassId, string UserID, int Health, int Attack, int Defense, int XP, int Coins, int Level, bool IsDead)
        {

            var newHero = new Hero
            {
                Name = name,
                Class = classType,
                ClassId = classId,
                SubHeroClass = SubHeroClass,
                SubHeroClassId = SubHeroClassId,
                UserId = UserID,
                Health = Health,
                Attack = Attack,
                Defense = Defense,
                XP = XP,
                Coins = Coins,
                Level = Level,
                IsDead = false
            };

            this.data.Heroes.Add(newHero);
            this.data.SaveChanges();

            return newHero;
        }

        public void Delete(Hero hero)
        {
            var enemyDefeated = this.data.EnemyRecords.Where(x => x.HeroId == hero.Id).ToList();
            foreach (var item in enemyDefeated)
            {
                this.data.EnemyRecords.Remove(item);
            }
            this.data.Heroes.Remove(hero);
            this.data.SaveChanges();
        }

        public void Revive(Hero hero)
        {
            hero.Coins -= (50 * hero.Coins) / 100; //50% from coinst
            hero.XP -= (50 * hero.XP) / 100; //50% from XP
            hero.Attack -= (50 * hero.Attack) / 100;//50% from Attack
            hero.Defense -= (50 * hero.Defense) / 100;//50% from Attack
            hero.Health = 100;
            hero.Level = this.data.Levels.FirstOrDefault(x => x.MinimumExperience <= hero.XP && x.MaximumExperience >= hero.XP).Lvl;
            hero.IsDead = false;
            this.data.SaveChanges();
        }

        public void Buying(int id, Hero hero)
        {
            var currItem = this.data.Items.FirstOrDefault(x => x.Id == id);

            if (currItem.IsSpecial == true)
            {
                switch (currItem.ClassId)
                {
                    case 1:
                        hero.Attack += currItem.AttackPoints;
                        hero.Defense += currItem.DefensePoints;
                        break;
                    case 2:
                        hero.Attack += currItem.AttackPoints;
                        hero.Defense += currItem.DefensePoints;
                        break;
                    case 3:
                        hero.Health += currItem.HealthPoints;
                        break;
                    case 4:
                        hero.Attack += currItem.AttackPoints;
                        hero.Defense += currItem.DefensePoints;
                        break;
                    default:
                        break;
                }
                hero.Coins -= 1000;
                hero.UseSpecialItem = true;
            }
            else
            {
                switch (currItem.Name)
                {

                    case "Health Potion":
                        hero.Coins -= currItem.Price;
                        hero.Health += currItem.HealthPoints;
                        break;
                    case "Defense":
                        hero.Coins -= currItem.Price;
                        hero.Defense += currItem.DefensePoints;
                        break;
                    case "Attack":
                        hero.Coins -= currItem.Price;
                        hero.Attack += currItem.AttackPoints;
                        break;
                    default:
                        break;
                }
            }

            this.data.SaveChanges();
        }

    }
}
