using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{

    [TdmsApi("SampleCommand")]
    public class SampleCommand
    {
        private readonly TDMSApplication application;
        //private readonly string T2ERootObjectDefName = "OBJ_SampleObjectDef";
        //private readonly string T2EFileDefName = "FILE_TXT";

        public SampleCommand(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            var query = application.Queries["Q_CorrectionAction"];
            var npp = application.GetObjectByGUID("{7AEF6063-2D97-415D-ABDC-3F6FF62CC147}");
            var buildingCode = "UJA";
            //var systemCode = "";

            query.SetParameter("ObjRef", npp);
            query.SetParameter("CodeSys", String.Empty);
            query.SetParameter("CodeBld", buildingCode);

            //var queryObjs = query.Objects;

            return;


            //var objectDef = application.ObjectDefs.FirstOrDefault(objDef => objDef.SysName.Equals(T2ERootObjectDefName));
            //if (objectDef == null) return;

            //var objs = objectDef.Objects;
            //if (objs.Count == 0) return;
            //var obj = objs[0];



            //obj.Attributes["SampleAttributeDef-string"].Value = System.DateTime.Now.ToString();

            //var xmlString = httpClient.GetResponse("xml");
            //obj.Attributes["ATTR_SampleAttributeDef-xml"].Value = jsonString;

            //var invoker = new Invoker();
            ////var httpClient = new LocalHttpClient();
            //var httpClient = new EnoviaHttpClient();
            //var attributes = Application.
            //    GetObjectByGUID("{9CBED675-7CD0-4815-8D02-C8099D165C41}").
            //    Attributes;

            //var value = httpClient.GetResponse("json");
            //var command = new ChangeValue(attributes["ATTR_SampleAttributeDef-json"], value);
            //invoker.SetCommand(command);
            //invoker.ExecuteCommand();

            //value = httpClient.GetResponse("xml");
            //command = new ChangeValue(attributes["ATTR_SampleAttributeDef-xml"], value);
            //invoker.SetCommand(command);
            //invoker.ExecuteCommand();
        }
    }
}