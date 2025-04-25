using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System.Collections.Generic;

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

        void AddMutations(List<string> mutations);

        void RemoveMutation(IMutation mutation);
    }
}