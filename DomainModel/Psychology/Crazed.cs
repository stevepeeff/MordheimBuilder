﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class Crazed : PsychologyBase
    {
        public override Afflictions Affliction { get; } = Afflictions.AutomaticallyPassAllLeadershipTests;

        public override string Description { get; } = "Darksouls have been driven insane by daemonic possession and know no fear";
    }
}