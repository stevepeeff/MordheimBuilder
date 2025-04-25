using System;

namespace DomainModel.Psychology
{
    internal class Stupid : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Stupidity;

        public override string Description =>
            $"Subject to stupidity unless a hero is within 6\" of this warrior." + Environment.NewLine +
            "On a failed Ld test => roll a D6. " + Environment.NewLine +
            "1-3 The warrior moves directly forward at half speed in a shambling manner." + Environment.NewLine +
            "He will not charge an enemy(stop his movement 1\" away from any enemy he would have come into contact with)." + Environment.NewLine +
            "He can fall down from the edge of a sheer drop(see the Falling rules) or hit an  obstacle, in which case he stops." + Environment.NewLine +
            "The model will not shoot this turn. " + Environment.NewLine +
            "4-6 The warrior stands inactive and drools a bit during this turn.He may do nothing else, as drooling is so demanding";
    }
}