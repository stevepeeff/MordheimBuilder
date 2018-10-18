using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.RacialAdvantages;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.WitchHunters
{
    public class WitchHuntersWarband : WarbandBase
    {
        public WitchHuntersWarband()
        {
            HeroList.Add(new WitchHunterCaptain());
            HeroList.Add(new WarriorPriest());
            HeroList.Add(new WitchHunter());

            HenchMenList.Add(new Flagellant());
            HenchMenList.Add(new Zealot());
            HenchMenList.Add(new Warhound());
        }

        static public List<IEquipment> HeroEquipmentList { get; } = new List<IEquipment>()
            {
                new Axe(), new Dagger(), new ClubMaceHammer(), new Sword(), new DoubleHandedWeapon(),
                new CrossBow(), new Pistol(), new BraceOfPistols(), new CrossbowPistol(),
                new LightArmour(), new HeavyArmour(), new Shield(), new Buckler(), new Helmet(),

                //TESTCODE
                new LongBow(), new WarplockPistol(), new Sling()
            };

        public override int MaximumNumberOfWarriors { get; } = 12;
    }
}