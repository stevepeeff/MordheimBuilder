using DomainModel;

namespace MordheimDal.Interface
{
    public interface IDAL
    {
        /// <summary>Saves the specified roster.</summary>
        /// <param name="roster">The roster.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        string Save(IWarbandRoster roster);

        string Save(IWarbandRoster roster, string specificFileName);

        string DefaultStorageDirectory { get; }

        void Load(string file);
    }
}