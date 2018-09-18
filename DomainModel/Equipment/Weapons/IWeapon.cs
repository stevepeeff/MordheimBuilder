using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons
{
    public interface IWeapon : IEquipment
    {
        int ArmorSaveModifier { get; }

        /// <summary>
        /// Gets a value indicating whether [counts as pair].
        /// E.i. two identical weapons
        /// </summary>
        /// <value>
        ///   <c>true</c> if [counts as pair]; otherwise, <c>false</c>.
        /// </value>
        bool CountsAsPair { get; }
    }
}