using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;
using Csoft.Tdms.Common.Attributes;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class InitialDataOfBlockNumbersStrategies {
        /// <summary>
        /// encapsulates project document
        /// </summary>
        private readonly string attributeName = "A_Block_Number";
        private readonly string folderDefName = "O_Folder_Doc";
        public TDMSObject Document { get; }
        public InitialDataOfBlockNumbersStrategies(TDMSObject document) {
            this.Document = document;
        }
        public TDMSAttribute GetAttribute() {
            return Document.Attributes[attributeName];
        }
        public TDMSAttribute GetTable() {
            var folder = new TdmsObjectTdmsAttributeValueBehavior(Document.Attributes["A_Block_Ref"]).GetValue();
            if (folder == null) return null;
            return folder.Attributes[folderDefName];
        }
        public List<string> GetAttributeValuesFromTable(TDMSAttribute table) =>
            table.Rows.Select(
                row => new StringTdmsAttributeValueBehavior(row.Attributes["A_Block_Number"]).GetValue()
            ).ToList();
        public TDMSObject GetNpp() {
            var npp = new TdmsObjectTdmsAttributeValueBehavior(Document.Attributes["A_Object_Ref"]).GetValue();
            return npp;
        }
        public IEnumerable<TDMSObject> GetBlocks(TDMSObject Npp) {
            return GetNpp().Content.ObjectsByDef("O_Block");
        }
        public IEnumerable<string> GetBlocksNumbersAsStrings(IEnumerable<TDMSObject> blocks) {
            return (blocks.Any()) ?
                blocks.Select(block => new StringTdmsAttributeValueBehavior(
                    block.Attributes["A_Block_Number"]).GetValue()) :
                Enumerable.Empty<string>();
        }
    }
}
