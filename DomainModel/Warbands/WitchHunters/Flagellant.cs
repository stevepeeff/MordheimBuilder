using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class Flagellant : WarriorBase, IHenchMen
    {
        public Flagellant()
        {
            Strength.BaseValue = 4;
            Strength.MaximumValue = 4;
            Movement.MaximumValue = 4;
            LeaderShip.BaseValue = 10;
            LeaderShip.MaximumValue = 10;

            AddAffliction(new Fanatical());

            _AllowedWeapons.Add(new Flail());
            _AllowedWeapons.Add(new MorningStar());
            _AllowedWeapons.Add(new DoubleHandedWeapon());
        }

        public override int HireFee { get; } = 40;

        public override int MaximumAllowedInWarBand { get; } = 5;

        public override IWarrior GetANewInstance()
        {
            return new Flagellant();
        }
    }
}