using System;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class Invocation<T, TResult> {
        protected T Target { get; }
        protected Func<T, TResult> Command { get; }
        public Invocation(T target, Func<T, TResult> command) {
            this.Target = target;
            this.Command = command;
        }
        public virtual TResult Invoke() => Command(Target);
    }
}