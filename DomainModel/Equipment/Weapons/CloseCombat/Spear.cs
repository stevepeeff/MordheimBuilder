namespace DomainModel.Equipment.Weapons.CloseCombat
{
    internal class Spear : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public Spear()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.StrikeFirst);
        }
    }
}