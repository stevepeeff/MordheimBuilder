using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Selection
{
    internal class CloseCombatWeaponViewModel : ViewModelBase
    {
        public CloseCombatWeaponViewModel(ICloseCombatWeapon closeCombatWeapon)
        {
            CloseCombatWeapon = closeCombatWeapon;
        }

        public int Costs => CloseCombatWeapon.Cost;
        public string Description => CloseCombatWeapon.Description;
        public string Name => CloseCombatWeapon.Name.SplitCamelCasing();
        public int StrengthModifier => CloseCombatWeapon.StrengthModifier;
        public int ToHitModifier => CloseCombatWeapon.ToHitModifier;
        internal ICloseCombatWeapon CloseCombatWeapon { get; }
    }
}