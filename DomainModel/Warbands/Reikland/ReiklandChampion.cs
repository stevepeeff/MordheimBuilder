﻿using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Reikland
{
    public class ReiklandChampion : Champion
    {
        public override IWarrior GetANewInstance()
        {
            return new ReiklandChampion();
        }
    }
}