using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class DecreaseBuyAmount : WariorViewCommandBase
    {
        public DecreaseBuyAmount(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            if (WarriorView.Warrior is IHenchMan)
            {
                BuilderLogicFactory.Instance.WarbandRoster.DecreaseHenchmenInGroup(WarriorView.Warrior as IHenchMan);
            }
        }
    }
}