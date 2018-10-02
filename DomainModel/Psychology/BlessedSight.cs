using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class BlessedSight : PsychologyBase
    {
        public override Afflictions Affliction { get; } = Afflictions.ReRollAnyFailedCharasteristicAndToHit;

        public override string Description { get; } = "In addition, an Augur can use her Blessed Sight to help the Sisterhood when they are searching the city for wyrdstone.If the Augur is not put out of action in the battle, you may roll two dice for her in the exploration phase and pick either dice as the result.";
    }
}