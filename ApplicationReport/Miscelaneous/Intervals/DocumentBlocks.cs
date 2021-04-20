using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// gets numbers of blocks from attribute of document
    /// </summary>
    public class DocumentBlocks : BlocksNumbersStrategy {
        private TDMSAttribute attribute;
        public DocumentBlocks(TDMSAttribute attribute) {
            this.attribute = attribute;
        }
        public override List<int> GetNumbers() {
            return new NaturalNumbersInterval(
                GetAttributeValue()).Split();
        }
        protected override bool GetIsAplicable() {
            return !string.IsNullOrEmpty(
                GetAttributeValue());
        }
        private string GetAttributeValue() {
            return new StringTdmsAttributeValueBehavior(attribute).GetValue();
        }
    }
}
