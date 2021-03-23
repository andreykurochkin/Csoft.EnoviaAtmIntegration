using System;
using System.Collections.Generic;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Base class to compare generations of ICorectionActions
    /// </summary>
    public class CorrectionActionsFamily
    {
        protected readonly IEnumerable<ICa> old;
        protected readonly IEnumerable<ICa> youth;

        public CorrectionActionsFamily(IEnumerable<ICa> old, IEnumerable<ICa> youth)
        {
            this.old = old;
            this.youth = youth;
        }

        public IEnumerable<ICa> Old { get => old; }
        public IEnumerable<ICa> Youth { get => youth; }
    }
}
