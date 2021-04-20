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
    /// gets numbers of blocks from table of documentation folder
    /// </summary>
    public class FolderBlocks : BlocksNumbersStrategy {
        private TDMSAttribute attribute;

        public FolderBlocks(TDMSAttribute attribute) {
            this.attribute = attribute;
        }

        public override List<int> GetNumbers() {
            var result = new List<int>();

            attribute.Rows.ForEach(row => {
                int foo;
                string rowValue = new StringTdmsAttributeValueBehavior(row.Attributes["A_Block_Number"]).GetValue();
                if (int.TryParse(rowValue, out foo)) result.Add(foo);
            });

            return result;
        }

        protected override bool GetIsAplicable() {
            return !(attribute.Rows.Count == 0);
        }
    }
}
