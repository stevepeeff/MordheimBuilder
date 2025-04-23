namespace DomainModel.Warbands.BaseClasses
{
    public abstract class YoungBlood : HumanHeroBase
    {
        public YoungBlood()
        {
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;
            LeaderShip.BaseValue = 6;

            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee { get; } = 15;

        public override int MaximumAllowedInWarBand { get; } = 2;
    }
}