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

        /// <summary>
        /// Adds the mutation.
        /// </summary>
        /// <param name="mutation">The mutation.</param>
        /// <returns>true if allowed</returns>
        bool AddMutation(IMutation mutation);

        void RemoveMutation(IMutation mutation);
    }
}