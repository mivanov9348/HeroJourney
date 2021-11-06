namespace HeroJourney.Controllers
{
    using HeroJourney.Data;
    using HeroJourney.Models;
    using HeroJourney.Services;
    using HeroJourney.Services.Hero;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using System.Security.Claims;
    using HeroJourney.Services.Logical;

    public class OptionsController : Controller
    {
        private readonly HeroJourneyDbContext data;
        private readonly IEnemyService enemyService;
        private readonly IHeroService heroService;
        private readonly ILogicalService logicalService;
        private string UserID;
        private Hero hero;
        private Random rnd;

        public OptionsController(IEnemyService enemyService, HeroJourneyDbContext data, IHeroService heroService, ILogicalService logicalService)
        {
            this.enemyService = enemyService;
            this.heroService = heroService;
            this.logicalService = logicalService;
            this.data = data;
            rnd = new Random();
        }

        public IActionResult PlayerStats()
        {
            CurrentUser();
            var heroClass = this.data.Classes.FirstOrDefault(x => x.Id == hero.ClassId);
            var specialItemName = this.data.Items.FirstOrDefault(x => x.IsSpecial == true && x.ClassId == hero.ClassId).Name;
            var subClassName = this.data.SubHeroClasses.FirstOrDefault(x => x.Id == hero.SubHeroClassId).SubClassName;

            return View(new HeroListingModel
            {
                Name = hero.Name,
                ClassName = heroClass.Name,
                Health = hero.Health,
                Coins = hero.Coins,
                Attack = hero.Attack,
                Defense = hero.Defense,
                Level = hero.Level,
                XP = hero.XP,
                Id = hero.Id,
                ClassId = hero.ClassId,
                SpecialItemName = specialItemName,
                SubClassName = subClassName
            });

        }

        public IActionResult ChangeUsername(HeroListingModel hlm)
        {
            CurrentUser();
            if (hlm.Name == null)
            {
                return View(new HeroListingModel
                {
                    Id = hero.Id,
                    Name = hero.Name
                });
            }
            else
            {
                this.heroService.ChangeUserName(hero, hlm.Name);
                return RedirectToAction("MainMenu", "Home");
            }
        }

        public IActionResult Shop(ShopViewModel slv)
        {
            CurrentUser();
            var items = this.data.Items.Where(x => x.ClassId == hero.ClassId || x.ClassId == null).ToList();
            var itemForHero = items.FirstOrDefault(x => x.IsSpecial == true);
            if (hero.UseSpecialItem)
            {
                items.Remove(itemForHero);
            }
            if (slv.Id == 0)
            {
                return View(new ShopViewModel
                {
                    HeroName = hero.Name,
                    HeroAttack = hero.Attack,
                    HeroHealth = hero.Health,
                    HeroDefense = hero.Defense,
                    HeroCoins = hero.Coins,
                    Items = items
                });
            }
            else
            {
                var currItem = this.data.Items.FirstOrDefault(x => x.Id == slv.Id);
                bool IsCoinEnough = this.logicalService.EnoughCoins(hero.Coins, currItem.Price);

                if (IsCoinEnough)
                {
                    this.heroService.Buying(slv.Id, hero);
                }
                if (hero.UseSpecialItem)
                {
                    items.Remove(itemForHero);
                }
                return View(new ShopViewModel
                {
                    HeroName = hero.Name,
                    HeroAttack = hero.Attack,
                    HeroHealth = hero.Health,
                    HeroDefense = hero.Defense,
                    HeroCoins = hero.Coins,
                    Items = items
                });
            }

        }

        public IActionResult Arena(ArenaViewModel avm)
        {
            CurrentUser();
            var enemy = this.enemyService.Create(false, hero);
            this.logicalService.CreateArena(enemy, hero);
            var currArena = this.logicalService.GetCurrArena(hero, enemy);
            currArena.Turn = 1;

            return View(new ArenaViewModel
            {
                HeroAttack = hero.Attack,
                HeroDefense = hero.Defense,
                HeroHealth = hero.Health,
                HeroLevel = hero.Level,
                HeroName = hero.Name,
                HeroXP = hero.XP,
                EnemyAttack = enemy.Attack,
                EnemyDefense = enemy.Defense,
                EnemyName = enemy.ClassName + " " + enemy.TypeName,
                EnemyHealth = enemy.Health,
                EnemyId = enemy.Id,
                Turn = currArena.Turn
            });
        }

        public IActionResult HeroAttack(ArenaViewModel avm)
        {
            CurrentUser();
            var currEnemy = this.enemyService.GetArenaEnemy(avm.EnemyId);
            var currArena = this.logicalService.GetCurrArena(hero, currEnemy);
            currArena.Turn = avm.Turn;

            this.logicalService.CalculateAttack(hero, currEnemy, currArena);
            this.logicalService.CheckHealth(hero, currEnemy, currArena.Turn);

            currArena.Turn = this.logicalService.ChangeTurn(currArena.Turn);

            if (hero.IsDead || currEnemy.IsDead)
            {
                this.logicalService.CalculateAfterFight(hero, currEnemy, currArena);
                this.heroService.checkLevel(hero.XP, hero);
                this.heroService.SavePlayerRecord(hero);
                currArena.Turn = 3;
            }

            return View("Arena", new ArenaViewModel
            {
                HeroAttack = hero.Attack,
                HeroDefense = hero.Defense,
                HeroHealth = hero.Health,
                HeroLevel = hero.Level,
                HeroName = hero.Name,
                HeroCoins = hero.Coins,
                HeroXP = hero.XP,
                EnemyAttack = currEnemy.Attack,
                EnemyDefense = currEnemy.Defense,
                EnemyName = currEnemy.ClassName + " " + currEnemy.TypeName,
                EnemyHealth = currEnemy.Health,
                EnemyId = currEnemy.Id,
                Turn = currArena.Turn,
                HeroXpWin = currArena.HeroWinsXp,
                HeroCoinsWin = currArena.HeroWinsCoins,
                EnemyDamage = currArena.EnemyDamage,
                HeroDamage = currArena.HeroDamage
            });
        }

        public IActionResult EnemyAttack(ArenaViewModel avm)
        {
            CurrentUser();
            var currEnemy = this.data.EnemyRecords.FirstOrDefault(x => x.Id == avm.EnemyId);
            var currArena = this.logicalService.GetCurrArena(hero, currEnemy);
            currArena.Turn = avm.Turn;

            this.logicalService.CalculateAttack(hero, currEnemy, currArena);
            this.logicalService.CheckHealth(hero, currEnemy, currArena.Turn);

            currArena.Turn = this.logicalService.ChangeTurn(currArena.Turn);

            if (hero.IsDead || currEnemy.IsDead)
            {
                this.logicalService.CalculateAfterFight(hero, currEnemy, currArena);
                this.heroService.checkLevel(hero.XP, hero);
                this.heroService.SavePlayerRecord(hero);
                currArena.Turn = 3;
            }
            return View("Arena", new ArenaViewModel
            {
                HeroAttack = hero.Attack,
                HeroDefense = hero.Defense,
                HeroHealth = hero.Health,
                HeroLevel = hero.Level,
                HeroName = hero.Name,
                HeroCoins = hero.Coins,
                HeroXP = hero.XP,
                EnemyAttack = currEnemy.Attack,
                EnemyDefense = currEnemy.Defense,
                EnemyName = currEnemy.ClassName + " " + currEnemy.TypeName,
                EnemyHealth = currEnemy.Health,
                EnemyId = currEnemy.Id,
                Turn = currArena.Turn,
                HeroCoinsWin = currArena.HeroWinsCoins,
                HeroXpWin = currArena.HeroWinsXp,
                EnemyDamage = currArena.EnemyDamage,
                HeroDamage = currArena.HeroDamage
            });

        }

        public IActionResult HeroStatistic()
        {
            CurrentUser();
            var killedMonster = this.data.EnemyRecords.Where(x => x.HeroId == hero.Id && x.IsDead == true).ToList();
            var currClass = this.data.Classes.FirstOrDefault(x => x.Id == hero.ClassId);

            return View(new HeroListingModel
            {
                ClassName = currClass.Name,
                Name = hero.Name,
                Enemies = killedMonster,
                Kills = hero.Kills
            });

        }

        public IActionResult StoryTale()
        {
            return View(new StoriesViewModel
            {
                Stories = this.data.Stories.ToList()
            });

        }
               
        private void CurrentUser()
        {
            UserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            hero = this.data.Heroes.FirstOrDefault(x => x.UserId == UserID);
        }
    }
}
