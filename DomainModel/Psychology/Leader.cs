namespace DomainModel.Psychology
{
    internal class Leader : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Leader;

        public override string Description => "Any warband member within 6\" may use the leadership of the leader";
    }
}