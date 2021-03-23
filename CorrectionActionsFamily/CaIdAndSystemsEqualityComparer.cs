using System;
using System.Collections.Generic;
using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// compares items by id
    /// </summary>
    public class CaIdAndSystemsEqualityComparer : IEqualityComparer<ICa>
    {
        public bool Equals(ICa x, ICa y)
        {
            if (!Compare(x.Id, y.Id)) return false;
            if (!Compare(x.Systems, y.Systems)) return false;

            return true;
        }

        private bool Compare(string x, string y)
        {
            if ((x == null) && (y == null)) return true;
            if (x == null) return false;
            if (y == null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(ICa obj)
        {
            return ((obj.Id == null) ? string.Empty.GetHashCode() : obj.Id.GetHashCode()) ^
            ((obj.Systems == null) ? string.Empty.GetHashCode() : obj.Systems.GetHashCode());
        }
    }
}