using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    public class TestTdmsClassifierAttributeValue : TestCaseBase
    {
        public TestTdmsClassifierAttributeValue(TDMSApplication application) : base(application) { }

        public override void Execute()
        {
            TDMSObject @object = application.GetObjectByGUID("{512B3024-D8B6-45A4-80A4-BF0B4C6C383E}");
            TDMSTableAttribute rows = @object.Attributes["A_TblWorkability"].Rows;

            foreach (TDMSTableAttributeRow attributeRow in rows)
            {
                var attribute = attributeRow["A_RecordCA"];
                var classifier = GetClassifier(attribute);
                var sysname = (classifier == null) ? string.Empty : classifier.SysName;
                application.DebugPrint($"rowValue: {sysname}");
            }
        }

        private TDMSClassifier GetClassifier(TDMSAttribute attribute)
        {
            return attribute.Classifier;
        }

        private TDMSClassifier GetClassifierSilent(TDMSAttribute attribute)
        {
            try { return GetClassifier(attribute); }
            catch (Exception) { return null; }
        }
    }
}
