using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class BraceOfPistols : Pistol
    {
        public override int AttackModifier { get; } = 2;

        public override int Cost { get; } = 30;

        public BraceOfPistols()
        {
            _MisseleWeaponRules.Clear();
        }
    }
}