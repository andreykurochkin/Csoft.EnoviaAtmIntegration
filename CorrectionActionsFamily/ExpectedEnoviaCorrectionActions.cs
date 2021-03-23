using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;
using System.Collections.Generic;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Retrieves new correction actions to be created in tdms
    /// </summary>
    public class ExpectedEnoviaCorrectionActions : EnoviaCorrectionActionsFamily
    {
        public ExpectedEnoviaCorrectionActions(EnoviaCorrectionActionsFamily family) : base(family) { }

        protected override IEnumerable<ICa> GetItems()
        {
            return youth.Except(old, new CorrectionActionIdEqualityComparer());
        }
    }
}
