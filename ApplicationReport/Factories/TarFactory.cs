using System;
using System.Linq;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Encapsulates algorithm to initialize fields of EnoviaApplicationReport instance
    /// </summary>
    public class TarFactory : IArFactory
    {
        private readonly TDMSTableAttributeRow row;
        private readonly TarFactoryAttributes setAttributes;
        private readonly TarFactoryAttributes ecaAttributes;
        private readonly NppMaps nppMaps;

        public TarFactory(TDMSTableAttributeRow row) 
            : this(row, new NppMaps()) { }

        private TarFactory(TDMSTableAttributeRow row, 
            NppMaps nppMaps)
        {
            this.row = row;
            this.nppMaps = nppMaps;

            setAttributes = new TarFactoryAttributes(row, 
                "A_DocRef");
            ecaAttributes = new TarFactoryAttributes(row, 
                "A_CorrectAct");
        }

        public string CreateApplicantName()
        {
            return new TdmsUserAttributeValueBehavior(
                setAttributes.GetAttribute("A_User"))
                .GetValue().ToFioSafe();
        }

        public string CreateBuildingName() => 
            new StringValueBehavior(
                ecaAttributes.GetAttribute
                ("A_Building_Code"))
            .GetValue();

        public string CreateRevision() => 
            new StringValueBehavior(
                setAttributes.GetAttribute(
                    "A_Revision_Number"))
            .GetValue();

        public string CreateDescription() => 
            new StringValueBehavior(
                ecaAttributes.GetAttribute("A_Name"))
            .GetValue();

        public string CreateNppId()
        {
            var npp = new TdmsObjectTdmsAttributeValueBehavior(
                setAttributes.GetAttribute("A_Object_Ref"))
                .GetValue();
            if (npp == null) return string.Empty;
            var mapItem = this.nppMaps.FirstOrDefault(
                map => map.Guid.Equals(npp.GUID));
            return (mapItem == null) ? 
                string.Empty : mapItem.Id;
        }

        public string CreateNppUnit()
        {
            var document = new TdmsObjectTdmsAttributeValueBehavior(
                row.Attributes["A_DocRef"]).GetValue();
            if (document == null) return string.Empty;
            var client = new BlocksNumbersClient(document);
            var interval = client.GetNumbers();
            if (interval.Count == 0) return string.Empty;
            return String.Join(",", interval);
        }

        public string CreateSetCode() => 
            new StringValueBehavior(
                setAttributes.GetAttribute("A_Designation"))
            .GetValue();

        public string CreateSetName() => new StringValueBehavior(setAttributes.GetAttribute("A_Name")).GetValue();

        public string CreateStatus()
        {
            try
            {
                return row.Attributes["A_RecordCA"].Classifier.SysName;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string CreateSystemName()
        {
            var val = new StringValueBehavior(
                ecaAttributes.GetAttribute("A_System_Code"))
                .GetValue();
            return (string.IsNullOrEmpty(val)) ? "-" : val;
        }

        public string CreateEcaId()
        { 
            return new StringValueBehavior(
                ecaAttributes.GetAttribute("A_ObjectGUID"))
                .GetValue();
        }
    }
}