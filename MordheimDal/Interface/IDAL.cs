using DomainModel;

namespace MordheimDal.Interface
{
    public interface IDAL
    {
        void Save(IWarbandRoster roster);

        void Save(IWarbandRoster roster, string specificFileName);

        string DefaultStorageDirectory { get; }

        void Load(string file);
    }
}