using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic.Prayers_of_Sigmar
{
    public class HeartsOfSteel : ISpell
    {
        public int Difficulty { get; } = 7;

        public int GainRequiredRoll { get; } = 1;
    }
}