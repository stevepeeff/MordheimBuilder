namespace DomainModel.Psychology
{
    public class Fanatical : PsychologyBase
    {
        public override Afflictions Affliction { get; } = Afflictions.AutomaticallyPassAllLeadershipTests;

        public override string Description { get; } = "Self, can never become a warband leader";
    }
}