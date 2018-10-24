using MordheimBuilder.Commands;
using MordheimBuilder.ViewModels;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class RemoveWarrior : WariorViewCommandBase
    {
        public RemoveWarrior(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            BuilderLogicFactory.Instance.WarbandRoster.RemoveWarrior(WarriorView.Warrior);
        }
    }
}