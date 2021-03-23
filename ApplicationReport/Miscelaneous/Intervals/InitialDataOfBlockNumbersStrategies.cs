using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

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
            var folder = new TdmsObjectValueBehavior(Document.Attributes["A_Block_Ref"]).GetValue();
            if (folder == null) return null;
            return folder.Attributes[folderDefName];
        }
        public TDMSObject GetNpp() {
            var npp = new TdmsObjectValueBehavior(Document.Attributes["A_Object_Ref"]).GetValue();
            return npp;
        }
    }
}
