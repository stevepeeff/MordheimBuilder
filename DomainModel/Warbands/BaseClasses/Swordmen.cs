using DomainModel.RacialAdvantages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class Swordmen : WarriorBase, IHenchMen
    {
        public Swordmen()
        {
            WeaponSkill.BaseValue = 4;
            Movement.MaximumValue = 4;

            Advantages = new ExpertSwordMenAdvantage();
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 5;
    }
}