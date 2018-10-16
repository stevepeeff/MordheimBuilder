using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public interface IMutant
    {
        IReadOnlyCollection<IMutation> Mutations { get; }

        void AddMutation(IMutation mutation);

        void RemoveMutation(IMutation mutation);
    }
}