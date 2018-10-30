using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    public class Pistol : EquipmentBase, IMisseleWeapon
    {
        public override int Range { get; } = 6;

        public override int ArmorSaveModifier { get; } = -2;

        public override int Strength { get; } = 4;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_8);

        public override int Cost { get; } = 15;

        public Pistol()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.PrepareShot);
        }
    }
}