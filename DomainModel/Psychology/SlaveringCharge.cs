namespace DomainModel.Psychology
{
    internal class SlaveringCharge : PsychologyBase
    {
        public override Afflictions Affliction => Afflictions.ExtraAttackOnCharge;

        public override string Description => "Has a +1 attack on Charge";
    }
}