using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Retrieves correction actions with
    /// </summary>
    public class ModifiedEnoviaCorrectionActions : EnoviaCorrectionActionsFamily
    {
        public ModifiedEnoviaCorrectionActions(EnoviaCorrectionActionsFamily family) : base(family) { }

        protected override IEnumerable<ICa> GetItems()
        {
            return this.youth.Intersect(this.old, 
                new CorrectionActionFatEqualityComparer()).Where(cA => Convert.ToDateTime(cA.Modified).Date > Convert.ToDateTime(this.old.FirstOrDefault(oldcA => oldcA.Id.Equals(cA.Id)).Modified).Date);
        }
    }
}
