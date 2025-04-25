using MordheimDal.Interface;

namespace MordheimDal
{
    public class DalProvider
    {
        public static IDAL Instance { get; } = new XmlDal();
    }
}