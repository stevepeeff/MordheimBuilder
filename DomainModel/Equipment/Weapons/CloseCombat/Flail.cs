namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Flail : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 15;

        public override int StrengthModifier { get; } = 2;

        public Flail()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.TwoHandend);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Heavy);
        }
    }
}