using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Warrior.Commands
{
    internal class DecreaseBuyAmount : CommandBase
    {
        private IWarrior _Warrior;

        public DecreaseBuyAmount(IWarrior warrior)
        {
            _Warrior = warrior;
        }

        public override void Execute(object parameter)
        {
            if (_Warrior is IHenchMen)
            {
                BuilderLogicFactory.Instance.WarbandRoster.DecreaseHenchmenInGroup(_Warrior as IHenchMen);
            }
        }
    }
}