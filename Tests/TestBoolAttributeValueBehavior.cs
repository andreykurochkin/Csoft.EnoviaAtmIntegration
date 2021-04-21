using Csoft.Tdms.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    public class TestBoolAttributeValueBehavior : TestCaseBase
    {
        public TestBoolAttributeValueBehavior(TDMSApplication application) : base(application) { }

        public override void Execute()
        {
            var guid = "{036AA823-3162-449B-9BE5-B7D7082FB19C}";
            //var guid = "{036AA823-3162-449B-9BE5-B7D7082FB19C}";
            //var guid = "{036AA823-3162-449B-9BE5-B7D7082FB19C}";
            guid = "{3B0C8DB2-4C16-4427-9FB8-BC469FDED910}";
            var kspp = application.GetObjectByGUID(guid);
            var rows = Utility.GetRowsSafe(kspp.Attributes[0]);
            var row = rows.FirstOrDefault();

            var attribute = row.Attributes["A_Fl_Record"];

            var status = new BoolTdmsAttributeValueBehavior(attribute).GetValue();
            application.DebugPrint($"A_Fl_Record: {status}");

            var strValue = new StringTdmsAttributeValueBehavior(attribute).GetValue();
            application.DebugPrint($"A_Fl_Record: {strValue}");
        }
    }
}
