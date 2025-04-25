namespace DomainModel.Equipment.Armour
{
    public class LightArmour : EquipmentBase, IArmour
    {
        public int Save { get; } = 1;

        public override int Cost { get; } = 20;

        public override string Description { get; } = "Light Armour 6+ Save";
    }
}