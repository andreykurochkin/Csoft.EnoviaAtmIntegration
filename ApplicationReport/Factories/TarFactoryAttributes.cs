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
using Tdms.Tasks;
using Tdms.Data;
using System.Runtime.CompilerServices;
using Csoft.EnoviaAtmIntegration.Domain;
using Csoft.Tdms.Common.Attributes;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Retreives attributes collection of TdmsObject, stored in TDMSTableAttributeRow
    /// </summary>
    internal class TarFactoryAttributes {
        private TDMSTableAttributeRow Row { get; }
        private string ColumnName { get; }
        private IEnumerable<TDMSAttribute> attributes;
        internal TarFactoryAttributes(TDMSTableAttributeRow row, string columnName) {
            Row = row;
            ColumnName = columnName;
        }
        internal TDMSAttribute GetAttribute(string name) {
            return Attributes.FirstOrDefault(a => a.AttributeDefName.Equals(name));
        }
        private IEnumerable<TDMSAttribute> Attributes {
            get {
                if (attributes == null) { 
                    attributes = GetTdmsObjectAttributesFromCell(Row, ColumnName);
                }
                return attributes;
            }
        }
        private IEnumerable<TDMSAttribute> GetTdmsObjectAttributesFromCell(TDMSTableAttributeRow row, string columnName) {
            var result = new List<TDMSAttribute>();
            try {
                new TdmsObjectTdmsAttributeValueBehavior(row.Attributes[columnName]).GetValue()
                    .Attributes
                    .ToList()
                    .ForEach(a => result.Add(a));
            }
            catch (Exception) {
                throw;
            }
            return result;
        }
    }
}