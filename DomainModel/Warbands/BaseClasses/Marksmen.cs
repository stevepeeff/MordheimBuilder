using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class Marksmen : WarriorBase, IHenchMen
    {
        public Marksmen()
        {
            Movement.MaximumValue = 4;
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 7;
    }
}