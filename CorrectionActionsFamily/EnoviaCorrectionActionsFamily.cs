using System;
using System.Collections.Generic;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class EnoviaCorrectionActionsFamily : CorrectionActionsFamily {
        public EnoviaCorrectionActionsFamily(IEnumerable<ICa> old, IEnumerable<ICa> youth) : base(old, youth) { }
        public EnoviaCorrectionActionsFamily(EnoviaCorrectionActionsFamily family) : this(family.old, family.youth) { }
        public bool IsActive => GetIsActive();
        public virtual IEnumerable<ICa> Items => GetItems();
        protected virtual bool GetIsActive() => (GetItems().Any());
        protected virtual IEnumerable<ICa> GetItems() => this.youth;
    }
}