using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
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

            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 5;
    }
}