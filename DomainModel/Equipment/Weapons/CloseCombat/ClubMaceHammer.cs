namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class ClubMaceHammer : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 3;

        public ClubMaceHammer()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Concussion);
        }
    }
}