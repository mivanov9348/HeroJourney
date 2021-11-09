namespace HeroJourney.Services.Hero
{
    using HeroJourney.Data;
    using HeroJourney.Models;

    public interface IHeroService
    {

        Hero Create(NewPlayerViewModel npvm, Hero hero, string UserId);

        void Revive(Hero hero);

        void Delete(Hero hero);

        void ChangeUserName(Hero hero, string name);

        void checkLevel(int experience, Hero hero);

        void Buying(int id, Hero hero);

        void SavePlayerRecord(Hero hero);

        Class GetClass(Hero hero);

        Item GetSpecialItem(Hero hero);

        SubHeroClass GetSubClass(Hero hero);
       

    }
}
