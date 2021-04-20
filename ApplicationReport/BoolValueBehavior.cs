using System;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Invokes bool value from TdmsAttributes by name
    /// </summary>
    public class BoolValueBehavior : TdmsAttributeValueBehavior<bool> {
        public BoolValueBehavior(TDMSAttribute attribute) : base(attribute) {
            this.value = new InvocationSafe<TDMSAttribute, bool>(attribute,
                a => Convert.ToBoolean(a.Value));
        }
    }
    public class AlterBoolTdmsAttributeValueBehavior : AlterTdmsAttributeValueBehavior<bool> {
        public AlterBoolTdmsAttributeValueBehavior(TDMSAttribute attribute)
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