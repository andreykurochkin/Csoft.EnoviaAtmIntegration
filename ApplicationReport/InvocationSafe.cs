using System;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class InvocationSafe<T, TResult> : Invocation<T, TResult> {
        public InvocationSafe(T attribute, Func<T, TResult> command) : base(attribute, command) { }
        public override TResult Invoke() {
            try {
                return base.Invoke();
            }
            catch (Exception) {
                return default;
            }
        }
    }
}
