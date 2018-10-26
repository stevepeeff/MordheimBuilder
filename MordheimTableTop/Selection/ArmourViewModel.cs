using DomainModel.Equipment.Armour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    internal class ArmourViewModel : ViewModelBase
    {
        public ArmourViewModel(IArmour armour)
        {
            Armour = armour;
        }

        public IArmour Armour { get; set; }

        public int Costs => Armour.Cost;

        public string Description
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

        public string Name => Armour.Name.SplitCamelCasing();
        public int Save => Armour.Save;
    }
}