using DomainModel.Equipment.Armour;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    internal abstract class EquipmentViewModel : ViewModelBase
    {
        public virtual string Save { get; } = "-";
        public abstract string Name { get; }

        public abstract int Costs { get; }

        public abstract string Description { get; }

        public virtual string StrengthModifier { get; } = "-";
        public virtual string ArmourSaveModifier { get; } = "-";

        public virtual int ToHitModifier { get; }

        public virtual int Range { get; }

        public virtual int Strength { get; }
    }
}