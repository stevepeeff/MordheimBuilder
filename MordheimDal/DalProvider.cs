using MordheimDal.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimDal
{
    public class DalProvider
    {
        public static IDAL Instance { get; } = new XmlDal();
    }
}