namespace DomainModel.Psychology
{
    internal class ImmuneToPoison : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ImmuneToPoison;

        public override string Description => "No affected by any poison.";
    }
}