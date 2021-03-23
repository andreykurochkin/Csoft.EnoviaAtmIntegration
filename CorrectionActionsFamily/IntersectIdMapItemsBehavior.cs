using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Encapsulates pairing algorithms via intersect systems of ICorrectionActions
    /// </summary>
    public class IntersectIdMapItemsBehavior : IMapItemsFamilyBehavior
    {
        private CorrectionActionsFamily map;
        internal readonly List<IdMapItemFamily> rawMapItems = new List<IdMapItemFamily>();

        public IntersectIdMapItemsBehavior(CorrectionActionsFamily map)
        {
            this.map = map;
        }

        private void InitializeItems()
        {
            foreach (var oldItem in this.map.Old)
            {
                foreach (var youthItem in this.map.Youth)
                {
                    this.rawMapItems.Add(new IdMapItemFamily(oldItem, youthItem));
                }
            }
        }

        public IEnumerable<IdMapItemFamily> CreateItems()
        {
            InitializeItems();

            var result = new List<IdMapItemFamily>();

            var query0 = this.rawMapItems.Where(m => m.lengthOldSystems == m.lengthIntersectSystems);
            var query1 = query0.Select(m => new { mapItem = m, delta = Math.Abs(m.lengthIntersectSystems - m.lengthYouthSystems) });
            var query2 = query1.GroupBy(g => g.mapItem.oldSystems, new ListContentEqualityComparer());

            foreach (var group in query2)
            {
                var minItemInGroup = group.Min(g => g.delta);
                var item = group.FirstOrDefault(g => g.delta == minItemInGroup);
                if (item == null) continue;
                result.Add(item.mapItem);
            }

            return result;
        }
    }
}
