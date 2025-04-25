namespace DomainModel.Equipment.Weapons.Missile
{
    public class Bow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 10;

        public override int Range { get; } = 30;
    }
}