﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class SteelWhip : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public SteelWhip()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.CannotBeParried);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Reach);
        }
    }
}