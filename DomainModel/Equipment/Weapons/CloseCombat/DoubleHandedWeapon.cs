namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class DoubleHandedWeapon : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 15;

        public override int StrengthModifier { get; } = 2;

        public DoubleHandedWeapon()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.TwoHandend);
            _CloseCombatRules.Add(CloseCombatWeaponRules.StrikeLast);
        }
    }
}