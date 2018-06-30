﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.Missile
{
    internal class DuellingPistol : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 30;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public override int Range { get; } = 10;

        public override int ArmorSaveModifier { get; } = -2;

        public override int Strength { get; } = 4;

        public override Availabilities Availability { get; } = Availabilities.RARE_10;

        public DuellingPistol()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.Accuracy);
            _MisseleWeaponRules.Add(MisseleWeaponRules.Prepare);
            _MisseleWeaponRules.Add(MisseleWeaponRules.HandToHand);
        }
    }
}