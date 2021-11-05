namespace HeroJourney.Services.Logical
{
    using HeroJourney.Data;
    using HeroJourney.Models;
    using System;

    public interface ILogicalService
    {

        void CheckHealth(Hero hero, EnemyRecords currEnemy, int turn);

        void CreateArena(EnemyRecords enemy, Hero hero);

        ArenaStat GetCurrArena(Hero hero, EnemyRecords enemy);

        int ChangeTurn(int turn);

        bool EnoughCoins(int coins, int price);

        void  CalculateAfterFight(Hero hero, EnemyRecords currEnemy, ArenaStat arena);

        void CalculateAttack(Hero hero, EnemyRecords enemy, ArenaStat arena);

    }
}
