using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Tdms;
using System.IO.Compression;
using System.Globalization;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    [TdmsApi("FileDownload")]
    class FileDownload
    {
        private readonly TDMSApplication application;

        public FileDownload(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            //release case
            var client = new EnoviaHttpClient();
            var correctionActionsWithFiles = JsonConvert.DeserializeObject<List<Ca>>(client.GetResponse("json")).Where(ca => (Convert.ToBoolean(ca.HasFiles)));
            var folder = Directory.CreateDirectory($"{application.WorkFolder}\\{DateTime.Now.ToString().Replace(" ", "-").Replace(".", "-").Replace(":", "-")}");
            correctionActionsWithFiles.ForEach(cA => CheckOutFiles(cA, folder.FullName));
            var cache = CacheTdms();    // to work quicker
            correctionActionsWithFiles.ForEach(cA => CheckInFiles(cache, cA.Id, folder.FullName, $"{cA.Id}.zip"));    // assert fileName equals $"{cA.Id}.zip"

            // test case
            //var cache = CacheTdms();
            //var correctionActionIds = new List<string>() { "27736.38003.13608.38073", "27736.38003.34624.54757", "27736.38003.49985.3077", "27736.38003.58140.54928" };
            //var folderPath = @"C:\TFSS\Temp\TH000415EB03000000000000\04-09-2020-1-32-30";
            //correctionActionIds.ForEach(cA => CheckInFiles(cache, cA, folderPath, $"{cA}.zip"));
        }

        /// <summary>
        /// Checkout files from Enovia to local drive
        /// </summary>
        /// <param name="enoviaCorrectionAction">Enovia Correction Action supposed to have files</param>
        /// <param name="folderPath">Copy to destination folder</param>
        private void CheckOutFiles(Ca enoviaCorrectionAction, string folderPath)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Endpoints.CheckoutUri(enoviaCorrectionAction.Id);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Authorization", new EnoviaBasicAuthenticationHeaderValue().ToString());

            Task<HttpResponseMessage> httpResponse = (new HttpClient()).SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            HttpContent responseContent = httpResponseMessage.Content;

            var fileName = httpResponseMessage.Content.Headers.ContentDisposition.FileName;
            fileName = fileName.Replace("\"", "");

            var fileStream = new FileStream($"{folderPath}\\{fileName}", System.IO.FileMode.OpenOrCreate);

            Task<Stream> responseData = responseContent.ReadAsStreamAsync();
            var stream = responseData.Result;
            stream.CopyTo(fileStream);

            stream.Close();
            fileStream.Close();
        }

        internal class CacheItem
        {
            internal readonly string id;
            internal readonly string guid;

            internal CacheItem(string id, string guid)
            {
                this.id = id;
                this.guid = guid;
            }
        }

        private List<CacheItem> CacheTdms()
        {
            var result = new List<CacheItem>();
            var catalogsFolder = application.Root.Objects
                .Where(obj => obj.ObjectDefName == "O_Folder")
                .Where(obj => obj.Attributes["A_Type_Folder"].Classifier != null)
                .FirstOrDefault(obj => obj.Attributes["A_Type_Folder"].Classifier.SysName == "N_TYPE_FOLDER_SERVICE");
            if (catalogsFolder == null) return result;

            var myRoot = catalogsFolder.Objects
                .Where(obj => obj.ObjectDefName == "O_Folder")
                .Where(obj => obj.Attributes["A_Type_Folder"].Classifier != null)
                .FirstOrDefault(obj => obj.Attributes["A_Type_Folder"].Classifier.SysName == "N_TYPE_FOLDER_SERVICE_CA");
            if (myRoot == null) return result;

            myRoot.Objects.ForEach(obj => result.Add(new CacheItem(obj.Attributes["A_ObjectGUID"].Value.ToString(), obj.GUID)));
            return result;
        }

        /// <summary>
        /// Uploads files to Tdms objects
        /// </summary>
        /// <param name="cacheTdms"></param>
        /// <param name="Id"></param>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        public void CheckInFiles(List<CacheItem> cacheTdms, string Id, string folderPath, string fileName)
        {
            try
            {
                if (!File.Exists($"{folderPath}\\{fileName}")) return;

                var zipPath = $"{folderPath}\\{fileName}";
                var folder = Directory.CreateDirectory($"{folderPath}\\{fileName.Substring(0, fileName.Length - "zip".Length)}");
                ZipFile.ExtractToDirectory(zipPath, folder.FullName);

                var match = cacheTdms.Where(cacheItem => cacheItem.id.Equals(Id));
                match.ToList().ForEach(cacheItem =>
                {
                    var cA = application.GetObjectByGUID(cacheItem.guid);
                    var files = cA.Files;

                    var unZippedFiles = folder.GetFiles();

                    foreach (var item in unZippedFiles)
                    {
                        if (files.Has(item.Name)) files.Remove(files[item.Name]);
                        files.Create(application.FileDefs["FILE_ALL"], $"{item.FullName}");
                    }
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
