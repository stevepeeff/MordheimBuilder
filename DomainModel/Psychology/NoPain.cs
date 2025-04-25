namespace DomainModel.Psychology
{
    internal class NoPain : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ImmuneToPain;

        public override string Description => "Treat 'Stunned' as 'Knocked down'";
    }
}