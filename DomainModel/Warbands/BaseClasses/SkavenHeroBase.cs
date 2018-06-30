using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Injuries;
using DomainModel.Skills;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class SkavenHeroBase : HeroBase, IHero
    {
        public SkavenHeroBase()
        {
            Movement.BaseValue = 6;
            Movement.MaximumValue = 6;
            WeaponSkill.MaximumValue = 6;
            BallisticSkill.MaximumValue = 6;
            Strength.MaximumValue = 4;
            Toughness.MaximumValue = 4;
            Wounds.MaximumValue = 3;
            Initiative.MaximumValue = 7;
            Attacks.MaximumValue = 4;
            LeaderShip.MaximumValue = 7;
        }
    }
}