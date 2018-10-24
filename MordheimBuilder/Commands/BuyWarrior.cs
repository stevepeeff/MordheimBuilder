using DomainModel.Warbands;
using MordheimBuilder.ViewModels;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class BuyWarrior : WariorViewCommandBase
    {
        public BuyWarrior(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(WarriorView.Warrior);
        }

        public override bool CanExecute(object parameter)
        {
            return
                (
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorReached(WarriorView.Warrior) == false &&
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorsReached() == false
                );
        }
    }
}