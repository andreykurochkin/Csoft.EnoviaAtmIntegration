using System;
using System.Collections.Generic;
using System.Linq;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Maps old items and youth tdmsCorrectionActions within single Id
    /// </summary>
    public class IntersectIdMapItemsFamily : CorrectionActionsFamily
    {
        internal readonly IMapItemsFamilyBehavior mapItemBehavior;

        public IntersectIdMapItemsFamily(IEnumerable<ICa> oldItems, IEnumerable<ICa> youthItems) : base(oldItems, youthItems) 
        { 
            this.mapItemBehavior = new IntersectIdMapItemsBehavior(this);
        }

        /// <summary>
        /// Creates pairs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IdMapItemFamily> CreateItems()
        {
            return this.mapItemBehavior.CreateItems();
        }
    }
}
