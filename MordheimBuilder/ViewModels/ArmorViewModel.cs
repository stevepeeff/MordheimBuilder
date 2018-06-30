using DomainModel.Equipment.Armour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class ArmorViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArmorViewModel"/> class.
        /// </summary>
        /// <param name="armour">The armour.</param>
        /// <exception cref="ArgumentNullException">IArmour is null</exception>
        public ArmorViewModel(IArmour armour)
        {
            if (armour == null) { throw new ArgumentNullException("IArmour is null"); }
            Armour = armour;
        }

        /// <summary>
        /// Gets the armour.
        /// </summary>
        /// <value>
        /// The armour.
        /// </value>
        internal IArmour Armour { get; private set; }

        #region DO NOT reorganize this ViewModel

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return FormattingTools.SplitCamelCasing(Armour.Name); }
        }

        public int Costs { get { return Armour.Cost; } }

        public string Effects
        {
            get
            {
                string result = String.Empty;

                foreach (var item in Armour.ArmourSpecialRules)
                {
                    result += $"{item} ";
                    EffectsDescription += item.GetDescription();
                }
                return result.SplitCamelCasing();
            }
        }

        /// <summary>
        /// Gets the save modifier.
        /// </summary>
        /// <value>
        /// The save modifier.
        /// </value>
        public string SaveModifier
        {
            get
            {
                return FormatSaveModifier(Armour);
            }
        }

        /// <summary>
        /// Formats the save modifier.
        /// E.g. Light Armour gives a save of 6+, but is stored as a 1
        /// Thus (7-1) = 6+
        /// A Shield  gives a save of +1, but is stored as a 1
        /// Thus represent as  +1
        /// </summary>
        /// <param name="armour">The armour.</param>
        /// <returns></returns>
        internal static string FormatSaveModifier(IArmour armour)
        {
            if (armour.Save != 0)
            {
                return FormatSaveValue(armour.Save);
            }

            return "None";
        }

        /// <summary>
        /// Formats the save value.
        /// E.g
        /// Save of 2 => "5+"
        /// </summary>
        /// <param name="armourValue">The armour value.</param>
        /// <returns></returns>
        internal static string FormatSaveValue(int armourValue)
        {
            return $"{7 - armourValue}+";
        }

        /// <summary>
        /// Gets the effects description.
        /// </summary>
        /// <value>
        /// The effects description.
        /// </value>
        internal string EffectsDescription { get; private set; }

        #endregion DO NOT reorganize this ViewModel
    }
}