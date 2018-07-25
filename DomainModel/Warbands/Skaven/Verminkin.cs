using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Skaven
{
    public class Verminkin : WarriorBase, IHenchMan
    {
        public Verminkin()
        {
            LeaderShip.BaseValue = 5;
        }

        public override int HireFee { get; } = 20;

        public override int MaximumAllowedInWarBand { get; } = int.MaxValue;

        public override IWarrior GetANewInstance()
        {
            return new Verminkin();
        }
    }
}