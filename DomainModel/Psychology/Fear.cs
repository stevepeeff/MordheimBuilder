namespace DomainModel.Psychology
{
    internal class Fear : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.Fear;

        public override string Description => "Causes Fear";
    }
}