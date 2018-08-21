using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    public class SkavenWarband : WarbandBase
    {
        public SkavenWarband()
        {
            HeroList.Add(new AssassinAdept());
            HeroList.Add(new BlackSkaven());
            HeroList.Add(new EshinSorcerer());
            HenchMenList.Add(new Verminkin());
        }

        public override int MaximumNumberOfWarriors { get; } = 20;
    }
}