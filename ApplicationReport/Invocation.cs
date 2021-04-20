using System;
namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// invokes encapsulated delegate 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class Invocation<T, TResult> : IInvokable<T, TResult> {
        public T Target { get; }
        public Func<T, TResult> Command { get; }
        public Invocation(T target, Func<T, TResult> command) {
            this.Target = target;
            this.Command = command;
        }
        public virtual TResult Invoke() => Command(Target);
    }
}