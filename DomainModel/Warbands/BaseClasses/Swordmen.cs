using DomainModel.RacialAdvantages;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class Swordmen : WarriorBase, IHenchMen
    {
        public Swordmen()
        {
            WeaponSkill.BaseValue = 4;
            Movement.MaximumValue = 4;

            Advantages = new ExpertSwordMenAdvantage();

            _AllowedWeapons.AddRange(MercenaryCaptain.MercenaryEquipmentList);
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = 5;
    }
}