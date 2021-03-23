using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Data;
using System.Runtime.CompilerServices;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class Invocation<T, TResult>
    {
        protected T target;
        protected Func<T, TResult> command;

        public Invocation(T target, Func<T, TResult> command)
        {
            this.target = target;
            this.command = command;
        }

        public virtual TResult Invoke()
        {
            return command(target);
        }
    }
}