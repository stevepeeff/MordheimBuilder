using DomainModel.Injuries;
using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class HumanHeroBase : HeroBase, IHero

    {
        public HumanHeroBase()
        {
            Movement.MaximumValue = 4;
            WeaponSkill.MaximumValue = 6;
            BallisticSkill.MaximumValue = 6;
            Strength.MaximumValue = 4;
            Toughness.MaximumValue = 4;
            Wounds.MaximumValue = 3;
            Initiative.MaximumValue = 6;
            Attacks.MaximumValue = 4;
            LeaderShip.MaximumValue = 9;
        }
    }
}