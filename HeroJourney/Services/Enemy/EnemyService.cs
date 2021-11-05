namespace HeroJourney.Services
{
    using System;
    using System.Linq;
    using HeroJourney.Data;
    using HeroJourney.Models;

    public class EnemyService : IEnemyService
    {
        private readonly HeroJourneyDbContext data;
        private Random rnd;

        public EnemyService(HeroJourneyDbContext data)
        {
            this.data = data;
            rnd = new Random();
        }
        public EnemyRecords Create(bool IsDead, Data.Hero hero)
        {
            var enemyClasses = this.data.EnemyClasses.ToList();
            var enemyTypes = this.data.EnemyTypes.ToList();

            var enemyClass = enemyClasses[rnd.Next(0, enemyClasses.Count())];
            var enemyType = enemyTypes[rnd.Next(0, enemyTypes.Count())];

            var enemyLevel = hero.Level;
            var enemyName = enemyClass.Name + " " + enemyType.Name;

            var enemyAttack = enemyType.Attack + (enemyLevel * enemyClass.BonusAttack);
            var enemyDefense = enemyType.Defense + (enemyLevel * enemyClass.BonusDefense);
            var enemyHealth = enemyType.Health + (enemyLevel * enemyClass.BonusHealth);

            var enemy = new EnemyRecords
            {
                ClassName = enemyClass.Name,
                TypeName = enemyType.Name,
                Attack = enemyAttack,
                Defense = enemyDefense,
                Health = enemyHealth,
                Level = enemyLevel,
                IsDead = false,
                HeroId = hero.Id
            };

            this.data.EnemyRecords.Add(enemy);
            this.data.SaveChanges();

            return enemy;
        }


        public ArenaViewModel Details(int enemyId)
        {
            var currEnemy = this.data.EnemyRecords.FirstOrDefault(x => x.Id == enemyId);
            return this.data.EnemyRecords.Select(x => new ArenaViewModel
            {
                EnemyName = currEnemy.ClassName + " " + currEnemy.TypeName,
                EnemyAttack = currEnemy.Attack,
                EnemyDefense = currEnemy.Defense,
                EnemyHealth = currEnemy.Health,
                EnemyId = currEnemy.Id

            }).FirstOrDefault();
        }

        public EnemyRecords GetArenaEnemy(int currEnemy) => this.data.EnemyRecords.FirstOrDefault(x => x.Id == currEnemy);
    }
}
