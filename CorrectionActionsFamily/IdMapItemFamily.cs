using System;
using System.Collections.Generic;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Represents within single Id two points in time:
    /// oldItem is data stored in Tdms as tdmsObject
    /// youthItem is data stord in Enovia
    /// </summary>
    public class IdMapItemFamily
    { 
        public readonly ICa oldItem;
        public readonly ICa youthItem;

        internal readonly List<string> oldSystems;
        internal readonly List<string> youthSystems;
        internal readonly List<string> intersectSystems;

        internal readonly int lengthOldSystems;
        internal readonly int lengthYouthSystems;
        internal readonly int lengthIntersectSystems;

        internal IdMapItemFamily(ICa restoredTdmsCorrectionAction, ICa tdmsCorrectionAction)
        {
            this.oldItem = restoredTdmsCorrectionAction;
            this.youthItem = tdmsCorrectionAction;

            oldSystems = oldItem.Systems.ToList();
            youthSystems = youthItem.Systems.ToList();
            intersectSystems = oldSystems.Intersect(youthSystems).ToList();

            lengthOldSystems = oldSystems.Count;
            lengthYouthSystems = youthSystems.Count;
            lengthIntersectSystems = intersectSystems.Count;
        }

        public override string ToString()
        {
            return $"oldSystems: {string.Join(", ", oldSystems)};\n" +
                $"youthSystems: {string.Join(", ", youthSystems)};\n" +
                $"intersectSystems: {string.Join(", ", intersectSystems)};\n" +

                $"lengthOldSystems: {lengthOldSystems}\n" +
                $"lengthYouthSystems: {lengthYouthSystems}\n" +
                $"lengthIntersectSystems: {lengthIntersectSystems}";
        }
    }
}
