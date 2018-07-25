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
        void Save(IWarBand warBand);

        IWarBand Load();
    }
}