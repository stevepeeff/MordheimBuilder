using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class IncreaseBuyAmount : WariorViewCommandBase
    {
        public IncreaseBuyAmount(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            if (WarriorView.Warrior is IHenchMen)
            {
                BuilderLogicFactory.Instance.WarbandRoster.IncreaseHenchmenInGroup(WarriorView.Warrior as IHenchMen);
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (WarriorView.Warrior is IHenchMen)
            {
                return
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorReached(WarriorView.Warrior) == false &&
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorsReached() == false;
            }

            return false;
        }
    }
}