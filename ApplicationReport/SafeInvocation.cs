using System;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// decorates invocation with try...catch operator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class SafeInvocation<T, TResult> : IInvokable<T, TResult> {
        public T Target { get; }
        public Func<T, TResult> Command { get; }
        public IInvokable<T, TResult> Origin;
        public SafeInvocation(IInvokable<T, TResult> origin) {
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
