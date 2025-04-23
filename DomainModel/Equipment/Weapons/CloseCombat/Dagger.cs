namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class Dagger : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 1;

        public override int ArmorSaveModifier { get; } = 1;

        public Dagger()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.FirstOneFree);
        }
    }
}