﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public class GromhilArmour : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 150;

        public int Save { get; } = 3;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_11);

        public override string Description { get; } = "Gromhil Armour 4+ Save";
    }
}