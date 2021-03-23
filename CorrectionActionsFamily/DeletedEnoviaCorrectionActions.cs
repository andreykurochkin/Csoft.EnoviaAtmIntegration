using System;
using System.Collections.Generic;
using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Retrieves correction actions from last export deleted in current export
    /// </summary>
    public class DeletedEnoviaCorrectionActions : EnoviaCorrectionActionsFamily
    {
        public DeletedEnoviaCorrectionActions(EnoviaCorrectionActionsFamily family) : base(family) { }
        protected override bool GetIsActive()
        {
            return (this.old.Count() > this.youth.Count());
        }
        protected override IEnumerable<ICa> GetItems()
        {
            return old.Except(youth, new CorrectionActionIdEqualityComparer());
        }
    }
}
