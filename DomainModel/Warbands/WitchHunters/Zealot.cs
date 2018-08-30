using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class Zealot : WarriorBase, IHenchMen
    {
        public Zealot()
        {
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;

            _AllowedWeapons.Add(new Sword());
            _AllowedWeapons.Add(new Bow());
        }

        public override int HireFee { get; } = 20;

        public override int MaximumAllowedInWarBand { get; } = int.MaxValue;

        public override IWarrior GetANewInstance()
        {
            return new Zealot();
        }
    }
}