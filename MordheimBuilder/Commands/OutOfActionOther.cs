using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.Commands
{
    internal class OutOfActionOther : WariorViewCommandBase
    {
        public OutOfActionOther(WarriorViewModel warriorViewModel) : base(warriorViewModel)
        {
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}