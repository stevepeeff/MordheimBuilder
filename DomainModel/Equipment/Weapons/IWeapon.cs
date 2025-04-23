namespace DomainModel.Equipment.Weapons
{
    public interface IWeapon : IEquipment
    {
        int ArmorSaveModifier { get; }
    }
}