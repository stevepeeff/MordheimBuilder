namespace DomainModel.Injuries
{
    public class NervousCondition : InjuryBase
    {
        public override int RollFrom { get; } = 33;

        public override int RollTill { get; } = 33;

        public override string Description { get; } = "Oooeeh very nervous";

        public override Statistic Result { get; }

        public NervousCondition()
        {
            Result = new Statistic(Characteristics.Initiative, -1, $" Injury: {Description}");
        }
    }
}