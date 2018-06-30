using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    internal class WarBandInformationViewModel
    {
        public int MaximumWarriorOfNumbers
        {
            get { return BuilderLogicFactory.Instance.CurrentWarband.MaximumNumberOfWarriors; }
        }

        public string Name
        {
            get
            {
                return BuilderLogicFactory.Instance.CurrentWarband.WarBandName.SplitCamelCasing();
            }
        }
    }
}