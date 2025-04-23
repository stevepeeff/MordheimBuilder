namespace DomainModel.Equipment.Weapons.Missile
{
    public class BraceOfDuellingPistols : DuellingPistol
    {
        public BraceOfDuellingPistols()
        {
            _MisseleWeaponRules.Clear();
            _MisseleWeaponRules.Add(MisseleWeaponRules.Accuracy);
            _MisseleWeaponRules.Add(MisseleWeaponRules.HandToHand);
            _MisseleWeaponRules.Add(MisseleWeaponRules.Brace);
        }

        public override int Cost => 50;
    }
}