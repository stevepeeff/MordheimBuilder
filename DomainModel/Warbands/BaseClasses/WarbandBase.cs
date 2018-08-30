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

        protected List<IHenchMen> HenchMenList = new List<IHenchMen>();

        public IReadOnlyCollection<IHero> Heroes { get { return HeroList; } }

        public IReadOnlyCollection<IHenchMen> HenchMen { get { return HenchMenList; } }

        public IWarrior GetWarrior(string typeName)
        {
            foreach (IHero hero in Heroes)
            {
                if (hero.TypeName.Equals(typeName))
                {
                    return hero;
                }
            }
            foreach (IHenchMen henchMen in HenchMen)
            {
                if (henchMen.TypeName.Equals(typeName))
                {
                    return henchMen;
                }
            }
            return null;
        }

        public IRacialAdvantage Advantages { get; protected set; }

        public string Description { get; } = "TODO";

        public virtual int StartingCash { get; } = 500;

        public string WarBandName { get { return this.GetType().Name.Replace("Warband", String.Empty); } }
    }
}