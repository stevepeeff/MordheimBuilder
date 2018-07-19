﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class IthilmarArmour : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 90;

        public int Save { get; } = 2;

        public override Availabilities Availability { get; } = Availabilities.RARE_11;

        public string Description { get; } = "Ithilmar Armour 5+ Save";
    }
}