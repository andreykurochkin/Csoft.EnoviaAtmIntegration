using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class AttributeValues<T> : IEnumerable<T> {
        private readonly List<T> list = new();
        private Attributes Attributes { get; }
        public AttributeValues(Attributes attributes) {
            Attributes = attributes;
            foreach (TDMSAttribute attribute in Attributes) {
                if (TryCast<T>(attribute.Value, out T result)) {
                    list.Add(result);
                }
            }
        }
        private static bool TryCast<T>(object obj, out T result) {
            result = default;
            if (obj is T) {
                result = (T)obj;
                return true;
            }
            // If it's null, we can't get the type.
            if (obj != null) {
                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                if (converter.CanConvertFrom(obj.GetType()))
                    result = (T)converter.ConvertFrom(obj);
                else
                    return false;
                return true;
            }
            //Be permissive if the object was null and the target is a ref-type
            return !typeof(T).IsValueType;
        }
        public IEnumerator<T> GetEnumerator() {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return list.GetEnumerator();
        }
    }
}
