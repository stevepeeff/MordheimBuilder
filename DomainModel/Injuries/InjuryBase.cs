namespace DomainModel.Injuries
{
    public abstract class InjuryBase : Injury
    {
        public abstract int RollFrom { get; }

        public abstract int RollTill { get; }

        public abstract string Description { get; }

        public abstract Statistic Result { get; }

        public Durations Duration { get; protected set; }

        public string Name
        { get { return GetType().Name; } }
    }
}