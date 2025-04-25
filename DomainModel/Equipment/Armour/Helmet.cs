namespace DomainModel.Equipment.Armour
{
    internal class Helmet : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 10;

        public int Save { get; } = NONE;

        public override string Description { get; } = "Helmet, no save. Avoid Stun";

        public Helmet()
        {
            _ArmourRules.Add(ArmourRules.AvoidStun);
        }
    }
}