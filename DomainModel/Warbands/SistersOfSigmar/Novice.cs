using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.SistersOfSigmar
{
    public class Novice : WarriorBase, IHenchMen
    {
        public Novice()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            Strength.BaseValue = 3;
            Toughness.BaseValue = 3;
            Wounds.BaseValue = 1;
            Initiative.BaseValue = 3;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 6;

            _AllowedWeapons.AddRange(SistersOfSigmarWarband.WeaponList);
            _AllowedWeapons.AddRange(SistersOfSigmarWarband.ArmourList);
        }

        public override int HireFee => 15;

        public override int MaximumAllowedInWarBand => 10;

        public override IWarrior GetANewInstance()
        {
            return new Novice();
        }
    }
}