using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic.Prayers_of_Sigmar
{
    public class HeartsOfSteel : ISpell, IPrayerOfSigmar
    {
        public int Difficulty { get; } = 7;

        public int GainRequiredRoll { get; } = 1;

        public string Description { get; } = "Any allied warriors within 8 of the warrior become immune to Fear and All Alone tests.In addition, the whole warband gains +1 to any Rout tests they have to make.The effects of this spell last until the caster is knocked down, stunned or put out of action. If cast again the effects are not cumulative, ie, the maximum bonus to Rout tests remains +1.";
    }
}