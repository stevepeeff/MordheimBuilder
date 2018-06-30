using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic
{
    public interface ISpell
    {
        int Difficulty { get; }

        /// <summary>
        /// Gets the gain required roll.
        /// </summary>
        /// <value>
        /// The gain required roll.
        /// </value>
        int GainRequiredRoll { get; }
    }
}