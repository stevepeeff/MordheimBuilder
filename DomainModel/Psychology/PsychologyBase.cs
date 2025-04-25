namespace DomainModel.Psychology
{
    public abstract class PsychologyBase : IPsychology
    {
        public abstract Afflictions Affliction { get; }
        public string Name => this.GetType().Name;
        public abstract string Description { get; }
    }
}