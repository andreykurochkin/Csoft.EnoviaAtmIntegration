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
    public class AlterInvocationSafe<T, TResult> : IInvokable<T, TResult> {
        public T Target { get; }
        public Func<T, TResult> Command { get; }
        public IInvokable<T, TResult> Origin;
        public AlterInvocationSafe(IInvokable<T, TResult> origin) {
            Origin = origin;
            Target = Origin.Target;
            Command = Origin.Command;
        }
        public virtual TResult Invoke() {
            try {
                return Origin.Invoke();
            }
            catch (Exception) {
                return default;
            }
        }
    }
}
