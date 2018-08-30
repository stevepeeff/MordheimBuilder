using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.RacialAdvantages
{
    public class ExpertSwordMenAdvantage : AdvantagesBase
    {
        public override string Description { get; } = "May re-roll any failed hits when charging (only when armed normal sword)";
    }
}