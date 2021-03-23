using System;
using System.Collections.Generic;
using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// compares items by id
    /// </summary>
    public class CorrectionActionIdEqualityComparer : IEqualityComparer<ICa>
    {
        public bool Equals(ICa x, ICa y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(ICa obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
