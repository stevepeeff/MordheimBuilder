using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Warbands;

namespace MordheimBuilderLogic
{
    public class BuilderLogicFactory
    {
        public static IMordheimBuilderLogic Instance { get; } = new BuilderLogic();

        private BuilderLogicFactory()
        {
        }
    }
}