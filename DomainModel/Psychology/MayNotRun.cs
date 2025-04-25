namespace DomainModel.Psychology
{
    internal class MayNotRun : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.MayNotRun;

        public override string Description => "Undead creatures are slow to react and may not run(but may charge normally).";
    }
}