using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Skaven
{
    public class Verminkin : WarriorBase, IHenchMen
    {
        public Verminkin()
        {
            Movement.BaseValue = 5;
            Initiative.BaseValue = 4;
            LeaderShip.BaseValue = 5;

            _AllowedWeapons.Add(new Dagger());
            _AllowedWeapons.Add(new ClubMaceHammer());
            _AllowedWeapons.Add(new Spear());
            _AllowedWeapons.Add(new Sword());
            _AllowedWeapons.Add(new Sling());
            _AllowedWeapons.Add(new LightArmour());
            _AllowedWeapons.Add(new Shield());
            _AllowedWeapons.Add(new Helmet());
        }

        public override int HireFee { get; } = 20;

        public override int MaximumAllowedInWarBand { get; } = INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Verminkin();
        }
    }
}