using DomainModel;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MordheimTableTop.Warrior
{
    public class StatisticViewModel : ViewModelBase
    {
        private Characteristic _characteristic;

        public StatisticViewModel(Characteristic characteristic)
        {
            _characteristic = characteristic;
            _characteristic.CharacteristicChanged += Characteristic_CharacteristicChanged;
        }

        /// <summary>
        /// Gets the color of the text.
        /// </summary>
        /// <value>
        /// The color of the text.
        /// </value>
        public Brush TextColor
        {
            get
            {
                switch (_characteristic.OverallResult)
                {
                    case OverallResults.Normal:
                    default:
                        return Brushes.Black;

                    case OverallResults.Positive:
                        return Brushes.Green;

                    case OverallResults.Negative:
                        return Brushes.Red;
                }
            }
        }

        /// <summary>
        /// Gets the content value.
        /// </summary>
        /// <value>
        /// The content value.
        /// </value>
        public string ContentValue
        {
            get
            {
                if (_characteristic.CharacteristicValue == Characteristics.Save)
                {
                    return FormatSaveModifier(_characteristic.CalculatedValue);
                }
                return _characteristic.CalculatedValue.ToString();
            }
        }

        /// <summary>
        /// Gets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText { get { return _characteristic.LabelName; } }

        /// <summary>
        /// Gets the tool tip text.
        /// </summary>
        /// <value>
        /// The tool tip text.
        /// </value>
        public string ToolTipText
        {
            get
            {
                if (String.IsNullOrEmpty(_characteristic.ModifierSummary))
                {
                    return "No modifications on this characteristic";
                }
                return _characteristic.ModifierSummary;
            }
        }

        /// <summary>
        /// Formats the save modifier.
        /// Light Armour (Sv 1) and a Shield (Sv 1) result in calculatedValue of 2.
        /// This give a save of (7-2) = 5+
        /// </summary>
        /// <param name="calculatedValue">The calculated value.</param>
        /// <returns></returns>
        internal static string FormatSaveModifier(int calculatedValue)
        {
            if (calculatedValue == Characteristic.ARMOUR_SAVE_NONE) { return String.Empty; }

            return $"{7 - calculatedValue}+";
        }

        private void Characteristic_CharacteristicChanged(object sender, EventArgs e)
        {
            NotifiyPropertyChangedEvent(nameof(TextColor));
            NotifiyPropertyChangedEvent(nameof(ContentValue));
        }
    }
}