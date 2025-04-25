using DomainModel.Equipment.Armour;
using System;

namespace MordheimTableTop.Selection
{
    public class ArmourViewModel : EquipmentViewModel
    {
        public ArmourViewModel(IArmour armour)
        {
            Armour = armour;
        }

        internal IArmour Armour { get; set; }

        public override string Name => Armour.Name.SplitCamelCasing();

        public override int Costs => Armour.Cost;

        public override string Description
        {
            get
            {
                string description = String.Empty;
                foreach (var item in Armour.ArmourSpecialRules)
                {
                    if (!String.IsNullOrEmpty(description))
                    {
                        description += ",";
                    }
                    description += item.GetDescription();
                }

                return description;
            }
        }

        public override string Save
        {
            get
            {
                if (Armour is Shield)
                {
                    return $"+{Armour.Save}";
                }
                if (Armour.Save > 0)
                {
                    return $"{6 - Armour.Save}+";
                }

                return "None";
            }
        }
    }
}