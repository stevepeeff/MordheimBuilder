using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheimers
{
    public class MiddenheimMarksmen : WarriorBase, IHenchMan
    {
        public MiddenheimMarksmen()
        {
            Movement.MaximumValue = 4;
            Advantages = new MiddenheimAdvantage();
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 7;

        public override IWarrior GetANewInstance()
        {
            return new MiddenheimMarksmen();
        }
    }
}