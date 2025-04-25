namespace DomainModel.Warbands
{
    public class CharacteristicModifier
    {
        public Characteristics Characteristic { get; }
        public int Modifier { get; }
        public string Description { get; }

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