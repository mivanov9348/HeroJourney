namespace HeroJourney.Services
{
    using HeroJourney.Data;
    using HeroJourney.Models;

    public interface IEnemyService
    {

        EnemyRecords Create(
                        bool IsDead,
                        Data.Hero hero
                            );

        ArenaViewModel Details(int enemyId);

        EnemyRecords GetArenaEnemy(int currEnemy);



    }
}
