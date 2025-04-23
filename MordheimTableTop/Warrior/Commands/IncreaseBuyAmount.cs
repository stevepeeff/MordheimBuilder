using DomainModel.Warbands;
using MordheimBuilderLogic;

namespace MordheimTableTop.Warrior.Commands
{
    internal class IncreaseBuyAmount : CommandBase
    {
        private IHenchMen _HenchMen;

        public IncreaseBuyAmount(IWarrior warrior)
        {
            _HenchMen = warrior as IHenchMen;
        }

        public override void Execute(object parameter)
        {
            if (_HenchMen != null)
            {
                BuilderLogicFactory.Instance.WarbandRoster.IncreaseHenchmenInGroup(_HenchMen);
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (_HenchMen != null)
            {
                return
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorReached(_HenchMen) == false &&
                BuilderLogicFactory.Instance.WarbandRoster.MaximumAllowedAmountOfWarriorsReached() == false;
            }

            return false;
        }
    }
}