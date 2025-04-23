namespace DomainModel.Equipment.Weapons.Missile
{
    public class BraceOfPistols : Pistol
    {
        //TODO work out, close combat = 2 attacks. Strength 4 with -2 save

        public override int Cost { get; } = 30;

        public BraceOfPistols()
        {
            _MisseleWeaponRules.Clear();

            _MisseleWeaponRules.Add(MisseleWeaponRules.Brace);
        }
    }
}