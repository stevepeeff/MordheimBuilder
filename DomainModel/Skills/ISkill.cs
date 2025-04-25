using System.Collections.Generic;

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

        string SkillName { get; }

        string SkillTypeName { get; }
    }
}