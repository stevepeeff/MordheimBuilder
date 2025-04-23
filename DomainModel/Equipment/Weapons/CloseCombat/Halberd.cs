namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Halberd : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 10;

        public override int StrengthModifier { get; } = 1;

        public Halberd()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.TwoHandend);
        }
    }
}