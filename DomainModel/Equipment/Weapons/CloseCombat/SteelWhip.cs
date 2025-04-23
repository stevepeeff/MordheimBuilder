namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class SteelWhip : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public SteelWhip()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.CannotBeParried);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Reach);
        }
    }
}