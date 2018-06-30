using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills
{
    public interface ISkill
    {
        /* Eg
         * Sprint triple movement when running/charging
         * Dodge 5+ save on ballistic weapons after a hit is scored
         * Expert swordsman re-roll all missed attacks when using sword
         *
         */

        IReadOnlyCollection<Statistic> Statistics { get; }

        string Description { get; }

        string Name { get; }
    }
}