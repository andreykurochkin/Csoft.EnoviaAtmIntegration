using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using Tdms.Data;
using System.Globalization;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class TdmsContext {
        private readonly TDMSApplication app;
        private TDMSObjectDef caObjectDef;
        private TDMSObject caRoot;
        private TDMSFileDef caFileDef;

        // update correction actions
        private readonly string caQueryName = "Q_T2E_CA_001";

        // send data to Enovia
        private readonly string ksppQueryName = "Q_T2E_KSPP_001";

        //private TDMSQuery caTdmsQuery;
        private readonly static string caAttrExportName = "A_Date1";
        internal static readonly string caObjectDefName = "O_Correct_Action";

        private readonly string excortCardObjDefName = "O_EXCORT_CARD";
        private TDMSObjectDef excortCardObjDef;

        public TdmsContext(TDMSApplication app) {
            this.app = app;
        }

        public TDMSObjectDef ExcortCardObjDef {
            get {
                if (excortCardObjDef == null) excortCardObjDef = GetExcortCardObjDef();
                return excortCardObjDef;
            }
        }

        public TDMSObjectDef CaObjectDef {
            get {
                if (caObjectDef == null) caObjectDef = GetCaObjectDef();
                return caObjectDef;
            }
        }

        public TDMSObject CaRoot {
            get {
                if (caRoot == null) caRoot = GetCaRoot();
                return caRoot;
            }
        }

        public TDMSFileDef CaFileDef {
            get {
                if (caFileDef == null) caFileDef = GetCaFileDef();
                return caFileDef;
            }
        }
        /// <summary>
        /// label on tdmsInputForm: Дата загрузки
        /// </summary>
        public static string CaAttrExportName => caAttrExportName;

        public TDMSObjects GetCaItemsByIdQuick(string id) {
            var query = GetCaQuery();
            query.SetParameter("PARAM0", id);
            return query.Objects;
        }

        public IEnumerable<TDMSObject> GetCaItemsById(string id) {
            return GetCaItemsByIdQuick(id).AsEnumerable<TDMSObject>();
        }

        private TDMSQuery GetCaQuery() {
            return app.Queries[caQueryName];
        }

        internal TDMSQuery GetKsppQuery() {
            return app.Queries[ksppQueryName];
        }

        private TDMSFileDef GetCaFileDef() {
            return app.FileDefs.FirstOrDefault(fD => fD.SysName.Equals("FILE_TXT"));
        }

        private TDMSObjectDef GetObjectDef(string name) {
            return app.ObjectDefs.FirstOrDefault(oD => oD.SysName.Equals(name));
        }

        private bool IsExcortCard(TDMSObject tdmsObject) {
            return (tdmsObject.ObjectDefName.Equals(this.excortCardObjDefName));
        }

        private TDMSObjectDef GetExcortCardObjDef() {
            return GetObjectDef(excortCardObjDefName);
        }
        private TDMSObjectDef GetCaObjectDef() {
            return GetObjectDef(caObjectDefName);
        }

        private TDMSObject GetCaRoot() {
            TDMSObject catalogsFolder = app.Root.Objects
                .Where(obj => obj.ObjectDefName == "O_Folder")
                .Where(obj => obj.Attributes["A_Type_Folder"].Classifier != null)
                .FirstOrDefault(obj => obj.Attributes["A_Type_Folder"].Classifier.SysName == "N_TYPE_FOLDER_SERVICE");
            if (catalogsFolder == null) return null;

            TDMSObject result = catalogsFolder.Objects
                .Where(obj => obj.ObjectDefName == "O_Folder")
                .Where(obj => obj.Attributes["A_Type_Folder"].Classifier != null)
                .FirstOrDefault(obj => obj.Attributes["A_Type_Folder"].Classifier.SysName == "N_TYPE_FOLDER_SERVICE_CA");

            return result;
        }

        #region DateAttributeInitialization



        internal static void InitializeDateAttributeBycicle(TDMSAttributes attributes, string name, string value) {
            var date = Utility.ConvertToDateTime(value);
            attributes[name].Value = date;
        }

        internal static void InitializeDateAttributeBycicleSilent(TDMSAttributes attributes, string name, string value) {
            try {
                InitializeDateAttributeBycicle(attributes, name, value);
            }
            catch (Exception ex) {
                LogManager.GetLogger("TdmsContext.InitializeDateAttributeBicycle").Debug($"Error. attName: {name}, value: {value}, ex: {ex.Message}, stack: {ex.StackTrace}");
            }
        }

        internal static void InitializeDateAttribute(TDMSAttributes attributes, string name, string value) {
            var attribute = attributes[name];
            if (attribute == null) return;
            attribute.Value = Convert.ToDateTime(value);
        }

        internal static void InitializeDateAttributeSilent(TDMSAttributes attributes, string name, string value) {
            try {
                InitializeDateAttribute(attributes, name, value);
            }
            catch (Exception ex) {
                LogManager.GetLogger("TdmsContext.InitializeDateAttributeSilent").Debug($"Error. attName: {name}, value: {value}, ex: {ex.Message}, stack: {ex.StackTrace}");
            }
        }
        #endregion

        internal static void InitializeAttribute(TDMSAttributes attributes, string name, string value) {
            var attr = attributes.FirstOrDefault(a => a.AttributeDefName.Equals(name));
            try {
                if (attr != null) attr.Value = value;
            }
            catch (Exception) {
                LogManager.GetLogger("TdmsContext.InitializeAttribute").Debug($"Error. attName: {name}, value: {value}");
            }
        }

        public TDMSObject CreateCaVersion(TDMSObject tdmsObject, int versionName) {
            var obj = app.GetObjectByGUID(tdmsObject.GUID);
            obj.Versions.Create(versionName, $"export @: {DateTime.Now}");
            var activeVersion = tdmsObject.Versions.Active;
            return activeVersion;
        }

        public TDMSObject CreateCaTdmsObject() {
            return CaRoot.Objects.Create(CaObjectDef);
        }

        public void InitializeCaFields(TDMSObject tdmsObject, int versionName, ICa tdmsCorrectionAction) {
            InitializeCaFields(tdmsObject, tdmsCorrectionAction);
            tdmsObject.VersionName = versionName.ToString();
        }

        public void InitializeCaFields(TDMSObject tdmsObject, ICa tdmsCorrectionAction, DateTime exportDateTime) {
            this.InitializeCaFields(tdmsObject, tdmsCorrectionAction);
            InitializeAttribute(tdmsObject.Attributes, "A_Date1", exportDateTime.ToString());
        }

        /// <summary>
        /// generates description
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private static string CreateDescriptionValue(string str1, string str2) {
            return (string.IsNullOrEmpty(str1)) ? str2.Trim(127) : str1;
        }
        public void InitializeCaFields(TDMSObject tdmsObject, ICa tca) {
            var attributes = tdmsObject.Attributes;

            // wtf ????????????
            //if (!string.IsNullOrEmpty(tca.Description)) {
            //    descriptionValue = tca.Description;
            //} else {
            //    if (!string.IsNullOrEmpty(tca.LongDescription)) {
            //        if (tca.LongDescription.Length < 128) {
            //            descriptionValue = tca.LongDescription;
            //        } else {
            //            descriptionValue = tca.LongDescription.Substring(0, 127);
            //        }
            //    } else {
            //        descriptionValue = string.Empty;
            //    }
            //}

            InitializeAttribute(attributes,
                                "A_Name",
                                (string.IsNullOrEmpty(tca.Description)) ? tca.LongDescription.Trim(127) : tca.Description
            );
            InitializeAttribute(attributes, "A_JSON", tca.LongDescription);
            InitializeAttribute(attributes, "A_System_Code", tca.Systems);
            InitializeAttribute(attributes, "A_Building_Code", tca.Buildings);
            InitializeAttribute(attributes, "A_ObjectGUID", tca.Id);

            InitializeDateAttributeBycicleSilent(attributes, "A_Date", tca.Modified);
            InitializeDateAttributeSilent(attributes, "A_Date1", tca.Export);

            FillTableWithKudanKulamNpps(
                tdmsObject.Attributes.FirstOrDefault(a=>a.AttributeDefName.Equals("A_Obj_Ref_Tbl")),
                tca
                );
            }

            //var attrName = "A_Obj_Ref_Tbl";
            //var table = tdmsObject.Attributes.FirstOrDefault(a => a.AttributeDefName.Equals(attrName));
            //table.Rows.RemoveAll();
            //var nppsGuids = tdmsCorrectionAction.Npps.ToList();
            //foreach (var nppGuid in nppsGuids) {
            //    var nppFromTdms = app.GetObjectByGUID(nppGuid);
            //    if (nppFromTdms == null) continue;

            //    var nppCode = nppFromTdms.Attributes["A_Object_Code"];
            //    var nppDescription = nppFromTdms.Attributes["A_Desc_ObjPJ"];

            //    var newRow = table.Rows.Create();
            //    newRow.Attributes["A_Object_Code"].Value = nppCode;
            //    newRow.Attributes["A_Desc_ObjPJ"].Value = nppDescription;
            //    newRow.Attributes["A_Object_Ref"].Value = nppFromTdms;
            //}
        //}
        private void FillTableWithAllNpps(TDMSAttribute table, ICa tca) {
            if (table == null) {
                return;
            }
            var npps = app.GetObjectsByGUIDs(tca.Npps.ToList());
            table.Rows.RemoveAll();
            AddRows(table, npps);
        }
        private void FillTableWithKudanKulamNpps(TDMSAttribute table, ICa tca) {
            if (table == null) {
                return;
            }
            var kudanKulamGuids = new KudanKulamNppMaps().Select(nppMap => nppMap.Guid);
            var containsKudanKulam = tca.Npps.ToList().Intersect(kudanKulamGuids);
            if (!containsKudanKulam.Any()) {
                return;
            }
            var npps = app.GetObjectsByGUIDs(kudanKulamGuids.ToList());
            table.Rows.RemoveAll();
            AddRows(table, npps);
        }
        private static void AddRows(TDMSAttribute table, IEnumerable<TDMSObject> npps) {
            
            foreach (TDMSObject npp in npps) {
                IninializeTableAttributeRow(
                    table.Rows.Create(),
                    CreateRowNames(),
                    CreateRowValues(
                        npp, CreateRowNames()
                    )
                );
            }
        }
        private static void IninializeTableAttributeRow(TDMSTableAttributeRow row,
                                                 Tuple<string, string, string> names,
                                                 Tuple<string, string, TDMSObject> values) {
            row.Attributes[names.Item1].Value = values.Item1;
            row.Attributes[names.Item2].Value = values.Item2;
            row.Attributes[names.Item3].Value = values.Item3;
        }
        private static Tuple<string, string, string> CreateRowNames() {
            return new Tuple<string, string, string>("A_Object_Code", "A_Desc_ObjPJ", "A_Object_Ref");
        }
        private static Tuple<string, string, TDMSObject> CreateRowValues(TDMSObject obj,
                                                                  Tuple<string, string, string> names) {
            return new Tuple<string, string, TDMSObject>(
                Utility.GetAttributeValueAsString(obj.Attributes, names.Item1),
                Utility.GetAttributeValueAsString(obj.Attributes, names.Item2),
                obj);
        }

        public void UploadFileFromEnovia() {
            string fileContent;
            if (Environment.MachineName.Equals("KUROCHKIN-NB")) {
                fileContent = new StreamReader(Path.GetFullPath(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\EnoviaCorrectionActions\11-09-2020-19-42-18.txt"), Encoding.UTF8).ReadToEnd();
            } else {
                fileContent = new EnoviaHttpClient().GetResponse("json");
            }

            var folder = Directory.CreateDirectory($"{app.WorkFolder}").FullName;
            var fileName = $"{DateTime.Now.ToString().Replace(" ", "-").Replace(".", "-").Replace(":", "-")}.txt";
            var fullFileName = $"{folder}\\{fileName}";
            File.WriteAllText(fullFileName, fileContent);
            //var tdmsFile = CaRoot.Files.Create(this.CaFileDef, fullFileName);
        }
    }

}
