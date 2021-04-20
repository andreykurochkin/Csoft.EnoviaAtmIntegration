using System;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Invokes bool value from TdmsAttributes by name
    /// </summary>
    public class BoolTdmsAttributeValueBehavior : AlterTdmsAttributeValueBehavior<bool> {
        public BoolTdmsAttributeValueBehavior(TDMSAttribute attribute)
            : base(
                attribute,
                new AlterInvocationSafe<TDMSAttribute, bool>(
                    new Invocation<TDMSAttribute, bool>(
                        attribute,
                        (attr) => Convert.ToBoolean(attr.Value)
                    )
                )
        ) { }
    }
}