using DomainModel.Warbands.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public class Brethren : WarriorBase, IHenchMen
    {
        public Brethren()
        {
            _AllowedWeapons.AddRange(CultOfThePossessedWarband.PossessedEquipmentList);
        }

        public override int HireFee { get; } = 25;

        public override int MaximumAllowedInWarBand { get; } = INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Brethren();
        }
    }
}