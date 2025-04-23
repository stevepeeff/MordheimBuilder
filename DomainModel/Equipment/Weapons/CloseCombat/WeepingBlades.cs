namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public class WeepingBlades : EquipmentBase, ICloseCombatWeapon
    {
        public override int Cost { get; } = 50;

        public override Availability TradeAvailability { get; } = new Availability(Availabilities.RARE_9);

        public WeepingBlades()
        {
            _CloseCombatRules.Add(CloseCombatWeaponRules.Pair);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Venomous);
            _CloseCombatRules.Add(CloseCombatWeaponRules.Parry);
        }
    }
}