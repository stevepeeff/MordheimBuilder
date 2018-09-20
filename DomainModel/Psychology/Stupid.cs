using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    internal class Stupid : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Stupidity;

        public override string Description =>
            $"Subject to stupidity unless a hero is within 6\" of this warrior" + Environment.NewLine +
            "TO DO COMPLETE";

        //            "If a model who fails a Stupidity test is not in hand-to hand /*

        //combat, roll a D6.
        //1-3 The warrior moves directly forward at half
        //speed in a shambling manner.He will not
        //charge an enemy(stop his movement 1" away
        //from any enemy he would have come into
        //contact with). He can fall down from the edge
        //of a sheer drop(see the Falling rules) or hit an
        //obstacle, in which case he stops.The model
        //will not shoot this turn.
        //4-6 The warrior stands inactive and drools a bit
        //during this turn.He may do nothing else, as
        //drooling is so demanding.";*/
    }
}