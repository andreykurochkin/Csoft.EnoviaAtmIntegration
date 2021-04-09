using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    public class TestTdmsUserAttributeBehavior : TestCaseBase {
        public TestTdmsUserAttributeBehavior(TDMSApplication application) : base(application) { }
        public override void Execute()
        {
            var tdmsObject = application.GetObjectByGUID("{52CE64C6-0461-4765-8DB9-33C048CD8B60}");

            var name = "null";
            var attribute = tdmsObject.Attributes[name];

            var invoker = new Invocation<TDMSAttribute, bool>(attribute, a =>
            {
                try
                {
                    return Convert.ToBoolean(a.Value);
                }
                catch (Exception)
                {
                    return default(bool);
                }
            });
            application.DebugPrint($"invocation with try catch: {invoker.Invoke()}");

            invoker = new InvocationSafe<TDMSAttribute, bool>(attribute, a => Convert.ToBoolean(a.Value));
            application.DebugPrint($"invocation silent: {invoker.Invoke()}");
        }
    }
}
