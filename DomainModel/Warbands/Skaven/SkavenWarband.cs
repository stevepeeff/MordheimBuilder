using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Skaven
{
    public class SkavenWarband : WarbandBase
    {
        public SkavenWarband()
        {
            HeroList.Add(new AssassinAdept());
            HeroList.Add(new BlackSkaven());
            HeroList.Add(new EshinSorcerer());
            HeroList.Add(new NightRunner());
            HenchMenList.Add(new Verminkin());
            HenchMenList.Add(new GaintRat());
            HenchMenList.Add(new RatOgre());
        }

        public override int MaximumNumberOfWarriors { get; } = 20;
    }
}