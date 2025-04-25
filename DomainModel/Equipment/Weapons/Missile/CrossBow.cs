namespace DomainModel.Equipment.Weapons.Missile
{
    public class CrossBow : EquipmentBase, IMisseleWeapon
    {
        public override int Cost { get; } = 25;

        public override int ArmorSaveModifier { get; } = -1;

        public override int Strength { get; } = 4;

        public override int Range { get; } = 30;

        public CrossBow()
        {
            _MisseleWeaponRules.Add(MisseleWeaponRules.MoveOrFire);
        }
    }
}