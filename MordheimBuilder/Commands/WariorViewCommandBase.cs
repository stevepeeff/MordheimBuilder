using MordheimBuilder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal abstract class WariorViewCommandBase : CommandBase
    {
        public WarriorViewModel WarriorView { get; private set; }

        public WariorViewCommandBase(WarriorViewModel warriorViewModel) : base()
        {
            WarriorView = warriorViewModel;
        }
    }
}