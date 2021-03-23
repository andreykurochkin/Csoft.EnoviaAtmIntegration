using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Csoft.EnoviaAtmIntegration.Domain.Tests;
using Csoft.EnoviaAtmIntegration.Domain.UtilityServices;
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
using Tdms.Log;
using System.Diagnostics;

namespace Csoft.EnoviaAtmIntegration.Domain {
    [TdmsApi("AutomationTestsSecond")]
    public class AutomationTestsSecond {
        private readonly TDMSApplication app;
        private readonly ILogger log = LogManager.GetLogger($"{typeof(EnoviaPutHttpClientLogged)}");

        public AutomationTestsSecond(TDMSApplication app) {
            this.app = app;
            //tests = new List<ITdmsTest>() {
            //    new PrintAnalyticsWhenNoCorrectionActionInTdms(app)
            //};
        }
        public void Execute() {
            IUtilityService service = new SentToTdmsDatesClient(
                new List<string>() { "27736.38003.38696.46666" },
                DateTime.Now,
                log);
            service.Execute();
        }

        //public void Execute() {
        //    var id = "27736.38003.34624.54757";
        //    bool isFail = false;

        //    try {
        //        var result = new MockAlterFileDownload(app, id);
        //    }
        //    catch (Exception ex) {
        //        isFail = true;
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine(ex.StackTrace);
        //    }

        //    if (isFail) {
        //        Console.WriteLine("MockAlterFileDownload failed");
        //    }
        //}


        //public void Execute()
        //{
        //    var guid = ("{4D07C1B0-1D84-41EE-9CBE-55C4450B5DE8}");
        //    var obj = app.GetObjectByGUID(guid);
        //    var files = obj.Files;
        //    if (files.Count != 0)
        //    {
        //        var file = files[1];

        //        //file.file

        //        file.CheckOut($"c:\\export_test\\{file.FileBodyId}");
        //        Debug.Print($"{file.FileName}");
        //    }
        //}

        //public void Execute()
        //{
        //    var fileName = "c:\\export_test\\from_server_with_long_path\\export.xml";
        //    var objects = new List<TDMSObject>()
        //    {
        //        app.GetObjectByGUID("{4D07C1B0-1D84-41EE-9CBE-55C4450B5DE8}"),
        //    };
        //    log.Debug($"export result: {app.ExportObjectsXml(fileName, objects)}");
        //}

        //public void Execute()
        //{
        //    var fileName = "c:\\export_test\\from_server\\export.xml";
        //    var objects = new List<TDMSObject>()
        //    {
        //        app.GetObjectByGUID("{784BA88C-0F08-414C-9113-04777C88F2F8}"),
        //        app.GetObjectByGUID("{1360A5FC-F3D4-457F-B9D8-CD016B9D761E}"),
        //        app.GetObjectByGUID("{29D52187-060E-4F4D-9E84-11CA77AFC2C0}"),
        //    };
        //    app.ExportObjectsXml(fileName, objects);
        //}

        //public void Execute()
        //{
        //    var root = new TdmsContext(app).CaRoot;
        //    var cas = root.Objects;
        //    ILogger log = LogManager
        //        .GetLogger("Duplicates");

        //    foreach (var tObj in cas)
        //    {
        //        var table = tObj.Attributes["A_Obj_Ref_Tbl"];
        //        var guids = new List<string>();
        //        var id = tObj.Attributes["A_ObjectGUID"].Value;

        //        foreach (var item in table.Rows)
        //        {
        //            var attr = item.Attributes["A_Object_Ref"];
        //            var guid = attr.Object.GUID;
        //            guids.Add(guid);

        //            var isDuplicate = guids
        //                .GroupBy(x => x)
        //                .Any(g => g.Count() > 1);

        //            if (isDuplicate)
        //            {
        //                log.Debug($"id: {id}, guid: {guid}");
        //            }
        //        }
        //    }
        //}

        //public void Execute()
        //{
        //    var guid = "27736.38003.24248.53927";
        //    var ecas = new Ecas();
        //    var tcas = new Tcas(ecas);
        //    var item = tcas.Where(ca=>ca.Id.Equals(guid)).FirstOrDefault();
        //}
        //public void Execute() {
        //    var pathDate = @"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\inbox\2021-02-16\allEca-date.txt";
        //    var ecasDate = Utility.GetObjects(pathDate).ToList();

        //    var alterEcas = Utility.GetObjects(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\inbox\2021-02-15\allEca.txt");
        //    var names = new List<string>() { "Doc-0001762", "Doc-0004216", "Doc-0004222" };
        //    var ids = alterEcas.Where(eca => names.Contains(eca.Name)).Select(eca=>eca.Id).ToList();
        //    var id = alterEcas.Where(eca => eca.Name == "Doc-0001762");


        //    var pathDateAndKulam = @"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\inbox\2021-02-16\allEca-date-and-Kulam.txt ";
        //    var ecasDateAndKulam = Utility.GetObjects(pathDateAndKulam).ToList();

        //    Console.WriteLine($"amount of date ecas: {ecasDate.Count}");
        //    Console.WriteLine($"amount of date and Kulam ecas: {ecasDateAndKulam.Count}");

        //    PrintEcas(ecasDate, @"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\inbox\2021-02-16\allEca-date-Ids.txt");
        //    PrintEcas(ecasDateAndKulam, @"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\inbox\2021-02-16\allEca-date-and-Kulam-Ids.txt");
        //}
        //private void PrintEcas(List<ICa> list, string path) {
        //    using (var streamWriter = new FileInfo(path).AppendText()) {
        //        list.ToList().ForEach(eca => streamWriter.WriteLine(eca.Id));
        //    }
        //}
        //public void AlterExecute() {
        //    ITdmsTest test =
        //        new PrintAnalyticsWhenNoCorrectionActionInTdms(app);
        //    test.Execute();
        //}

        /// <summary>
        /// updates pdSentToTdms date in Enovia and logs to nancy
        /// </summary>
        //public void Execute()
        //{
        //    var ids = new List<string>() {
        //        "27736.38003.61212.12791",
        //        "27736.38003.13416.35494",
        //        "27736.38003.51280.20319",
        //        "27736.38003.44560.18839",
        //        "27736.38003.4288.40023",
        //        "27736.38003.43092.7124",
        //        "27736.38003.45784.17539",
        //        "27736.38003.20800.33216",
        //        "27736.38003.31000.38288",
        //        "27736.38003.4384.32325",
        //        "27736.38003.9660.41128",
        //        "27736.38003.24668.51960",
        //        "27736.38003.9620.10467",
        //        "27736.38003.35752.3234",
        //        "27736.38003.9632.39506"
        //    };

        //    IUtilityService utilityService =
        //        new SentToTdmsDatesClient(ids,
        //        DateTime.Now, log);
        //    utilityService.Execute();

        //    ITdmsTest test =
        //        new PrintAnalyticsWhenNoCorrectionActionInTdms(app);
        //    test.Execute();
        //}

        //public void Execute()
        //{
        //tests.ToList().ForEach(t => t.Execute());

        //var ids = new List<string>() { 
        //    "27736.38003.26740.7740",
        //    "27736.38003.61212.12791",
        //    "27736.38003.44560.18839",
        //    "27736.38003.31000.38288",
        //    "27736.38003.4384.32325",
        //    "27736.38003.24668.51960",
        //    "27736.38003.35752.3234",
        //    "27736.38003.52721.17683"
        //};
        //new UtilityServices.TdmsObjectsClient(ids,
        //        @"c:\Users\AP_Petrosyan_TV\Documents\kurochkin\09-12-2020-09-45-17\NoTdmsDateEca.txt",
        //        this.app).Execute();
        //}


    }
}
