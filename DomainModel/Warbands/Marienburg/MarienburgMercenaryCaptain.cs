using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Marienburg
{
    public class MarienburgMercenaryCaptain : MercenaryCaptain
    {
        public override IWarrior GetANewInstance()
        {
            return new MarienburgMercenaryCaptain();
        }
    }
}