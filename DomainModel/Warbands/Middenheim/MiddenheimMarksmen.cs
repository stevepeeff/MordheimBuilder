using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.Middenheim
{
    public class MiddenheimMarksmen : Marksmen
    {
        public MiddenheimMarksmen()
        {
        }

        public override IWarrior GetANewInstance()
        {
            return new MiddenheimMarksmen();
        }
    }
}