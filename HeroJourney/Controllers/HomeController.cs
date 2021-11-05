﻿namespace HeroJourney.Controllers
{
    using static Controllers.DataConstant.HeroStats;
    using HeroJourney.Data;
    using HeroJourney.Models;
    using HeroJourney.Services.Hero;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HeroJourneyDbContext data;
        private readonly IHeroService heroService;
        private string UserID;
        private Hero hero;
        public HomeController(ILogger<HomeController> logger, HeroJourneyDbContext data, IHeroService heroService)
        {
            _logger = logger;
            this.data = data;
            this.heroService = heroService;
        }

        public IActionResult LoginPage(NewPlayerViewModel npvm)
        {
            return View();
        }

        public IActionResult MainMenu(NewPlayerViewModel npvm)
        {

            if (User.Identity.Name == null)
            {
                return View();
            }

            CurrentUser();
            if (hero != null)
            {
                if (hero.IsDead == true)
                {
                    return RedirectToAction("DeadView", "Home");
                }
            }

            if (hero == null && User.Identity.Name != null)
            {
                return PartialView("_CreatePlayer");
            }
            else
            {
                CurrentUser();
                var classType = this.data.Classes.FirstOrDefault(x => x.Id == hero.ClassId);
                return View(new NewPlayerViewModel
                {
                    Name = hero.Name,
                    Class = classType,
                    ClassId = classType.Id,
                    ClassName = classType.Name,
                    Health = hero.Health,
                    Attack = hero.Attack,
                    Defence = hero.Defense,
                    XP = hero.XP,
                    Coins = hero.Coins,
                    Level = hero.Level

                });
            }
        }

        public IActionResult CreatePlayer(NewPlayerViewModel vpvm)
        {
            CurrentUser();
            var classT = this.data.Classes.FirstOrDefault(x => x.Name == vpvm.ClassName);
            var className = classT.Name;
            var subClass = this.data.SubHeroClasses.FirstOrDefault(x => x.ClassId == classT.Id && x.SubClassLevel == 1);

            int XP = DataConstant.HeroStats.startingXP;
            int Coins = DataConstant.HeroStats.startingCoins;
            int Level = DataConstant.HeroStats.startingLevel;

            var hero = this.heroService.Create(classT.Name, classT, classT.Id, subClass, subClass.Id, UserID, classT.Health, classT.Attack, classT.Defence, XP, Coins, Level, false);

            return View("MainMenu", new NewPlayerViewModel
            {
                Class = classT,
                ClassName = className
            });
        }

        public IActionResult DeadView()
        {
            CurrentUser();
            return View(new HeroListingModel
            {
                Enemies = this.data.EnemyRecords.Where(x => x.HeroId == hero.Id).ToList()
            });
        }

        public IActionResult Revive(NewPlayerViewModel npvm)
        {
            CurrentUser();
            this.heroService.Revive(hero);
            return RedirectToAction("MainMenu", "Home");
        }

        public IActionResult Delete()
        {
            CurrentUser();
            this.heroService.Delete(hero);
            return RedirectToAction("MainMenu", "Home");
        }

        private void CurrentUser()
        {
            UserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            hero = this.data.Heroes.FirstOrDefault(x => x.UserId == UserID);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
