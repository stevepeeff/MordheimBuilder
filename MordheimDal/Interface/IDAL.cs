using DomainModel;

namespace MordheimDal.Interface
{
    public interface IDAL
    {
        string Save(IWarbandRoster roster);

        string Save(IWarbandRoster roster, string specificFileName);

        string DefaultStorageDirectory { get; }

        void Load(string file);
    }
}