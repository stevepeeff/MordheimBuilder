using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class MayNotRun : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.MayNotRun;

        public override string Description => "Zombies are slow Undead creatures and may not run(but may charge normally).";
    }
}