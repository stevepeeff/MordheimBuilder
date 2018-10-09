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

        [Description("TODO TEST on Ld")]
        Fear,

        [Description("On a failed Ld test => In combat does not strike blows or cast any spell")]
        Stupidity,

        [Description("Automatically Pass All Leadership Tests")]
        AutomaticallyPassAllLeadershipTests,

        [Description("Never gain experience")]
        NeverGainExperience,

        MayNotRun,

        [Description("Any model may shoot at the create, even if it is not the closest target")]
        LargeTarget,

        [Description("May use the Leadership of this model for all psychology tests")]
        Leader,

        ImmuneToPsychology,
        ImmuneToPoison,
        ImmuneToPain,

        [Description("Re-roll any failed characteristic tests(climbing, resisting spells or any other reason), and any rolls to hit in close combat or shooting.You must accept the second result.")]
        ReRollAnyFailedCharasteristicAndToHit
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

        string Name { get; }

        string Description { get; }
    }
}