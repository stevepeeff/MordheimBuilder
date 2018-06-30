using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public enum Afflictions
    {
        [Description("Re-roll to hit")]
        Hate,

        Fear,
        Stupidity,

        [Description("Automatically Pass All Leadership Tests")]
        AutomaticallyPassAllLeadershipTests,

        NeverGainExperience
    }

    public interface IPsychology
    {
        /* Eg
         * Fear
         * Hate
         * Stupidity
         *
         */

        Afflictions Affliction { get; }

        string Description { get; }
    }
}