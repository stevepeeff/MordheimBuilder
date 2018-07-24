﻿using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheimers
{
    public class MiddenheimerWarband : WarbandBase
    {
        public MiddenheimerWarband()
        {
            HenchMenList.Add(new MiddenheimMarksmen());

            Advantages = new MiddenheimAdvantage();
        }

        public override int MaximumNumberOfWarriors { get; } = 15;
    }
}