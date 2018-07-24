using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.RacialAdvantages;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class WarbandBase : IWarBand
    {
        public abstract int MaximumNumberOfWarriors { get; }

        protected List<IHero> HeroList = new List<IHero>();

        protected List<IHenchMan> HenchMenList = new List<IHenchMan>();

        public IReadOnlyCollection<IHero> Heroes { get { return HeroList; } }

        public IReadOnlyCollection<IHenchMan> HenchMen { get { return HenchMenList; } }

        public IRacialAdvantage Advantages { get; protected set; }

        public string Description { get; } = "TODO";

        public virtual int StartingCash { get; } = 500;

        public string WarBandName { get { return this.GetType().Name.Replace("Warband", String.Empty); } }
    }
}