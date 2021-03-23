using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    class WriteNoSentToTdmsDateCorrectionActions : ITdmsTest
    {
        private TDMSApplication app;
        private PrintAnalyticsWhenNoCorrectionActionInTdms origin;

        public WriteNoSentToTdmsDateCorrectionActions(
            TDMSApplication app)
        {
            this.app = app;
            origin = new PrintAnalyticsWhenNoCorrectionActionInTdms(app);
        }

        public void Execute()
        {
            try
            {
                //var cachedDateTime = DateTime.Now;
                //var folder = origin.AcquireLayoutFolder(
                //    origin.AcquireRootFolder(), cachedDateTime);
                //var fileName = "NoSentToTdmsDateCorrectionActions.txt";
                //var file = File.CreateText($"")
                throw new NotFiniteNumberException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void SaveJsonToFile(DateTime dateTime)
        {
            //var folder = AcquireLayoutFolder(
            //    AcquireRootFolder(rootPath), 
            //    dateTime);

            //var fileName = $"NoSentToTdmsDateCorrectionActions-{CreateDateTimeName(dateTime)}.txt";
            //var file = File.CreateText($"{folder.FullName}\\{fileName}");
            //file.WriteLine(
            //    new ServiceEnoviaHttpClient(
            //        new NoSentToTdmsDateEnoviaHttpRequestMessageFactory(
            //            new EnoviaHttpRequestMessageFactory()))
            //        .GetResponse("json"));
            //file.Close();
            throw new NotFiniteNumberException();
        }

        internal DirectoryInfo AcquireLayoutFolder(DirectoryInfo root, DateTime dateTime)
        {
            return root.CreateSubdirectory(CreateDateTimeName(dateTime));
        }

        internal DirectoryInfo AcquireRootFolder(string path)
        {
            return Directory.CreateDirectory(path);
        }

        internal string CreateDateTimeName(DateTime dateTime)
        {
            return dateTime.ToString().Replace(" ", "-").Replace(".", "-").Replace(":", "-");
        }
    }
}
