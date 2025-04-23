namespace DomainModel.Equipment.Armour
{
    public class Buckler : EquipmentBase, IArmour
    {
        public override int Cost { get; } = 5;

        public int Save { get; } = NONE;

        public override string Description { get; } = "Buckler, no save. Parry";

        public Buckler()
        {
            _ArmourRules.Add(ArmourRules.Parry);
        }
    }
}