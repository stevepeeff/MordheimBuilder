using DomainModel;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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