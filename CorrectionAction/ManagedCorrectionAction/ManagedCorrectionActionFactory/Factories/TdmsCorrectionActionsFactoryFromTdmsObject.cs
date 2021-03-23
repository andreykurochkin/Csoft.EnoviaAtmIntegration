using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Domain;
namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class TdmsCorrectionActionsFactoryFromTdmsObject : ICaFactory
    {
        private readonly TDMSObject tdmsObject;
        private readonly TDMSAttributes attributes;
        private readonly NppMaps NppMaps;

        public TdmsCorrectionActionsFactoryFromTdmsObject(TDMSObject tdmsObject, NppMaps nppMaps)
        {
            this.tdmsObject = tdmsObject;
            NppMaps = nppMaps;
            this.attributes = this.tdmsObject.Attributes;
        }

        public string CreateBuildings()
        {
            var attrName = "A_Building_Code";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }

        public string CreateDescription()
        {
            var attrName = "A_Name";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }

        public string CreateLongDescription()
        {
            var attrName = "A_JSON";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }


        public string CreateEnoviaModifiedDate()
        {
            var attrName = "A_Date";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }

        public string CreateExportDate()
        {
            var attrName = "A_Date1";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }

        public string CreateHasFiles()
        {
            return (tdmsObject.Files.Count!=0).ToString();
        }

        public string CreateId()
        {
            var attrName = "A_ObjectGUID";
            return Utility.GetAttributeValueAsString(attributes, attrName);
        }

        public string CreateName()
        {
            return string.Empty;
        }

        public string CreateNpps()
        {
            var result = new List<string>();

            var attrName = "A_Obj_Ref_Tbl";
            var table = attributes[attrName];
            
            foreach (var row in table.Rows)
            {
                var nppGuidFromTDMS = row.Attributes["A_Object_Ref"].GetGuidSilent();
                if (nppGuidFromTDMS.Equals(string.Empty)) continue;

                var nppMap = this.NppMaps.FirstOrDefault(map => map.Guid == nppGuidFromTDMS);
                if (nppMap == null) continue;

                result.Add(nppMap.Name);
            }

            return String.Join(", ", result);
        }

        public string CreateRelationShip3()
        {
            return string.Empty;
        }

        public string CreateSystems()
        {
            var attrName = "A_System_Code";
            return attributes[attrName].Value.ToString();
        }

        public string CreateType()
        {
            return "pdCorrectionAction";
        }

        public string SentToTdms()
        {
            return String.Empty;
        }
    }
}
