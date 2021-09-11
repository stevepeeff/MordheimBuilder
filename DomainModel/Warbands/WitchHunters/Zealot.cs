using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.WitchHunters
{
    public class Zealot : WarriorBase, IHenchMen
    {
        public Zealot()
        {
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 2;

            _AllowedWeapons.Add(new Dagger());
            _AllowedWeapons.Add(new ClubMaceHammer());
            _AllowedWeapons.Add(new Axe());
            _AllowedWeapons.Add(new Sword());
            _AllowedWeapons.Add(new DoubleHandedWeapon());
            _AllowedWeapons.Add(new Spear());

            _AllowedWeapons.Add(new Bow());
            _AllowedWeapons.Add(new ShortBow());

            _AllowedWeapons.Add(new LightArmour());
            _AllowedWeapons.Add(new Shield());
            _AllowedWeapons.Add(new Helmet());
        }

        public override int HireFee { get; } = 20;

        public override int MaximumAllowedInWarBand { get; } = INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Zealot();
        }
    }
}