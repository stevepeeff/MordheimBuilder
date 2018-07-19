using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Armour
{
    public enum ArmourRules
    {
        [Description("Heavy Armor and Shield combined result in a -1 movement penalty")]
        Movement,

        [Description("When opponent rolls to hit, roll a D6 roll, if the result > then opponent the blow is parried and the attack is discarded")]
        Parry,

        [Description("D6 Special 4+ Save against being stunned, if successful become knocked down")]
        AvoidStun,
    }

    public interface IArmour : IEquipment

    {
        string Description { get; }

        int Save { get; }

        IReadOnlyCollection<ArmourRules> ArmourSpecialRules { get; }
    }
}