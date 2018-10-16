using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public class CharacteristicModifier
    {
        public Characteristics Characteristic { get; }
        public int Modifier { get; }
        public string Description { get; }

        //public CharacteristicModifier(Characteristics characteristic, int modifier)
        //{
        //    Characteristic = characteristic;
        //    Modifier = modifier;
        //}

        public CharacteristicModifier(Statistic statistic, string description)
        {
            Characteristic = statistic.Characteristic;
            Modifier = statistic.AppliedValue;
            Description = description;
        }

        public CharacteristicModifier(Statistic statistic) : this(statistic, statistic.Description)
        {
        }
    }
}