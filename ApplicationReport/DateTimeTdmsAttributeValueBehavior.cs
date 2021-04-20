using System;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Invokes DateTime value from TdmsAttribute or default(DateTime)
    /// </summary>
    public class DateTimeTdmsAttributeValueBehavior : TdmsAttributeValueBehavior<DateTime> {
        public DateTimeTdmsAttributeValueBehavior(TDMSAttribute attribute) : base(
            attribute,
            new SafeInvocation<TDMSAttribute, DateTime>(
                new Invocation<TDMSAttribute, DateTime>(
                    attribute,
                    (attr) => Convert.ToDateTime(attribute.Value)
                )
            )
        ) { }
    }
}