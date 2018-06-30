﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class SigmariteWarhammer : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 15;

        public override int StrengthModifier { get; } = 1;

        public SigmariteWarhammer()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Concussion);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Holy);
        }
    }
}