namespace DomainModel.Equipment.Weapons.CloseCombat
{
    /// <summary>
    /// Applies to warriors who lost their weapons.
    /// Zombies, animals, etc, ignore these rules
    /// </summary>
    public class Fists : EquipmentBase, ICloseCombatWeapon
    {
        public Fists()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.LostWeaponsInCombat);
        }

        public override int StrengthModifier { get; } = -1;

        public override int ArmorSaveModifier { get; } = 1;

        public override int Cost { get; }
    }
}