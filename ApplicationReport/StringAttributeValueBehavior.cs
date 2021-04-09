using System;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Invokes string value from TdmsAttribute by name or string.Empty
    /// </summary>
    public class StringValueBehavior : TdmsAttributeValueBehavior<string> {
        public StringValueBehavior(TDMSAttribute attribute) : base(attribute) {
            this.value = new InvocationSafe<TDMSAttribute, string>(
                this.attribute,
                a => {
                    string result;
                    try { result = a.Value.ToString(); }
                    catch (Exception) { result = string.Empty; }
                    return result;
                });
        }
    }
}