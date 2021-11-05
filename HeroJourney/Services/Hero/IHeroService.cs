namespace HeroJourney.Services.Hero
{
    using HeroJourney.Data;
    using HeroJourney.Models;

    public interface IHeroService
    {

        Hero Create(          
            string name,
            Class classType,
            int classId,
            SubHeroClass SubHeroClass,
            int SubHeroClassId,
            string UserID,
            int Health,
            int Attack,
            int Defense,
            int XP,
            int Coins,
            int Level,
            bool IsDead           
            );

        void Revive(Hero hero);

        void Delete(Hero hero);

        void ChangeUserName(Hero hero,string name);

        void checkLevel(int experience,Hero hero);

        void Buying(int id, Hero hero);


    }
}
