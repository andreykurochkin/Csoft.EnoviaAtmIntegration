using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public abstract class TdmsAttributeValueBehavior<TResult> {
        protected TDMSAttribute attribute;
        protected InvocationSafe<TDMSAttribute, TResult> value;
        public TdmsAttributeValueBehavior(TDMSAttribute attribute) {
            this.attribute = attribute;
        }
        public TResult GetValue() {
            return value.Invoke();
        }
    }
}