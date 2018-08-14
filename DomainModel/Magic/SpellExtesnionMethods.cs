using DomainModel.Magic.Prayers_of_Sigmar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Magic
{
    internal static class SpellExtesnionMethods
    {
        public static IReadOnlyList<T> GetSpells<T>(this IList<ISpell> spells) where T : ISpell
        {
            List<T> retval = new List<T>();

            foreach (ISpell item in spells)
            {
                if (item is T)
                {
                    retval.Add((T)item);
                }
            }

            return retval;
        }
    }
}