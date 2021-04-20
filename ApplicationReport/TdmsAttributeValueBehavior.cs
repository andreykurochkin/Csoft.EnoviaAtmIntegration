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
    public abstract class AlterTdmsAttributeValueBehavior<TResult> {
        protected IInvokable<TDMSAttribute, TResult> Invocation { get; }
        public AlterTdmsAttributeValueBehavior(TDMSAttribute attribute, IInvokable<TDMSAttribute, TResult> invocation) {
            Invocation = invocation;
        }
        public TResult GetValue() {
            return Invocation.Invoke();
        }
    }
}