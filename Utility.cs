using Newtonsoft.Json;
using Csoft.EnoviaAtmIntegration.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public static class Utility
    {
        public static IEnumerable<TDMSTableAttributeRow> GetRows(
            TDMSAttribute table)
        {
            return table.Rows;
        }

        public static IEnumerable<TDMSTableAttributeRow> GetRowsSafe(
            TDMSAttribute table)
        {
            try
            {
                return table.Rows;
            }
            catch (Exception)
            {
                return Enumerable
                    .Empty<TDMSTableAttributeRow>();
            }
        }

        /// <summary>
        /// returns digits {1;7;6} from integer 176
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> GetDigits(int input)
        {
            //if (input <= 0) new List<int>();

            var absInput = Math.Abs(input);

            if (absInput < 1) return new List<int>() { 0 };

            var result = new List<int>();

            double n = absInput / 10d;
            while (n >= 0.1)
            {
                result.Add((int)Math.Round((n - Math.Truncate(n)) * 10d));
                n = Math.Truncate(n) / 10d;
            }

            return result;
        }

        /// <summary>
        /// returns true if all items are same
        /// returns false if input is null
        /// return false if input has no items
        /// </summary>
        /// <param name="input">list of integers</param>
        /// <returns></returns>
        public static bool AllItemsAreSame(List<int> input)
        {
            if (input == null) return false;
            if (input.Count == 0) return false;

            var measure = input[0];
            foreach (var item in input)
            {
                var difference = item - measure;
                if (difference != 0) return false;
            }

            return true;
        }

        /// <summary>
        /// creates list of integers from first, to second step 1
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static List<int> GetRange(int first, int second)
        {
            var foo = new List<int>() { first, second };
            foo.Sort();

            if (foo.ElementAt(0) == foo.ElementAt(1)) return new List<int>() { foo.ElementAt(0) };
            var count = foo.ElementAt(1) - foo.ElementAt(0) + 1;
            return Enumerable.Range(foo.ElementAt(0), count).ToList();
        }

        /// <summary>
        /// Invokes TdmsAttribute by AttributeDefName from TDMSTableAttributeRow
        /// </summary>
        /// <param name="row">TDMSTableAttributeRow</param>
        /// <param name="name">AttributeDefName to be invoked</param>
        /// <returns>TDMSAttribute</returns>
        public static TDMSAttribute GetAttribute(TDMSTableAttributeRow row, string name)
        {
            return GetAttribute(row.Attributes, name);
        }

        /// <summary>
        /// Invokes TdmsAttribute by AttributeDefName from TDMSTableAttributeRow in silent mode
        /// </summary>
        /// <param name="row">TDMSTableAttributeRow</param>
        /// <param name="name">AttributeDefName to be invoked</param>
        /// <returns>TDMSAttribute</returns>
        public static TDMSAttribute GetAttributeSilent(TDMSTableAttributeRow row, string name)
        {
            try
            {
                return row.Attributes.GetItems().FirstOrDefault(a => a.AttributeDefName.Equals(name));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Invokes TdmsAttribute from TDMSAttributes collection by name
        /// </summary>
        /// <param name="attributes">source TDMSAttributes collection</param>
        /// <param name="name">goal AttributeDefName to be found</param>
        /// <returns></returns>
        public static TDMSAttribute GetAttribute(TDMSAttributes attributes, string name)
        {
            return attributes.FirstOrDefault(attr => attr.AttributeDefName.Equals(name));
        }

        /// <summary>
        /// Invokes TdmsAttribute from TDMSAttributes collection by name in silent mode
        /// </summary>
        /// <param name="attributes">source TDMSAttributes collection</param>
        /// <param name="name">goal AttributeDefName to be found</param>
        /// <returns></returns>
        public static TDMSAttribute GetAttributeSilent(TDMSAttributes attributes, string name)
        {
            try
            {
                return GetAttribute(attributes, name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetAttributeValueAsString(TDMSAttributes attributes, string name)
        {
            var attribute = GetAttributeSilent(attributes, name);
            if (attribute == null) return string.Empty;

            var value = attribute.Value;
            if (value == null) return string.Empty;

            return attribute.Value.ToString();
        }

        public static readonly string chemin = @"C:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\rawResult-copy.txt";

        /// <summary>
        /// id1-1: { }-{PAC, PGB, LAJ, LCB, LAC, PCC, LCT}
        /// id1-2: {АЭС Ханхикиви}-{LCB, PAC, PCC, PGB, LCT, LAJ, LAC
        /// result-1: {PAC, PGB, LAJ, LCB, LAC, PCC, LCT} - {АЭС Пакш-2, АЭС Ханхикиви}
        /// </summary>
        public static ICa GetCa1()
        {
            return GetObject("27736.38003.13592.55634");
        }

        /// <summary>
        /// id1-1: {АЭС Руппур}-{GCB, GCR}
        /// id1-2: {АЭС Эль-Дабаа}-{GCR}
        /// id1-3: {АЭС Проект-53}-{GCR, GCB}
        /// result-1: {GCB, GCR} - {АЭС Руппур, АЭС Проект-53}
        /// result-2: {GCR} - {АЭС Эль-Дабаа}
        /// </summary>
        public static ICa GetCa2()
        {
            return GetObject("27736.38003.3808.19876");
        }

        /// <summary>
        /// id1-1: {АЭС Руппур}-{JND}
        /// id1-1: {Курская АЭС-2}-{JND}
        /// id1-1: {Узбекская АЭС}-{JND}
        /// id1-1: {АЭС Аккую}-{JND}
        /// result-1: {JND} - {АЭС Руппур, Курская АЭС-2, Узбекская АЭС, АЭС Аккую}
        /// </summary>
        public static ICa GetCa3()
        {
            return GetObject("27736.38003.36484.60373");
        }

        /// <summary>
        /// Npps: {АЭС Сюйдапу, АЭС Эль-Дабаа, Ленинградская АЭС-2, Узбекская АЭС, Тяньваньская АЭС, Белорусская АЭС, АЭС Ханхикиви, АЭС Пакш-2}
        /// Systems: {N/A, N/A, N/A, N/A, N/A, N/A, N/A, N/A}
        /// result-1: {N/A} - {АЭС Сюйдапу, АЭС Эль-Дабаа, Ленинградская АЭС-2, Узбекская АЭС, Тяньваньская АЭС, Белорусская АЭС, АЭС Ханхикиви, АЭС Пакш-2}
        /// </summary>
        public static ICa GetCa4()
        {
            return GetObject("27736.38003.52720.20083");
        }

        /// <summary>
        /// Npps: {АЭС Пакш-2, АЭС Эль-Дабаа, АЭС Ханхикиви, Ленинградская АЭС-2, АЭС Эль-Дабаа, АЭС Ханхикиви, Ленинградская АЭС-2}
        /// Systems: {FCA, FCA, FCA, FCA, FCF, FCF, FCF}
        /// result-1: {FCA} - {АЭС Пакш-2}
        /// result-2: {FCA, FCF} - {АЭС Эль-Дабаа, АЭС Ханхикиви, Ленинградская АЭС-2}
        /// </summary>
        public static ICa GetCa5()
        {
            return GetObject("27736.38003.54536.24097");
        }

        /// <summary>
        /// Npps: {АЭС Пакш-2, АЭС Ханхикиви, АЭС Эль-Дабаа, Тяньваньская АЭС, Ленинградская АЭС-2, АЭС СюйдапуБелорусская АЭС, Узбекская АЭС, АЭС Пакш-2, АЭС Эль-Дабаа, Белорусская АЭС, АЭС Сюйдапу, Узбекская АЭС, Тяньваньская АЭС, АЭС Ханхикиви, Ленинградская АЭС-2, Ленинградская АЭС-2, Узбекская АЭС, АЭС Эль-Дабаа, АЭС Ханхикиви, АЭС Пакш-2, Белорусская АЭС}
        /// Systems: {CRF, CRF, CRF, CRF, CRF, CRF, CRF, CRF, CRD, CRD, CRD, CRD, CRD, CRD, CRD, CRD, MAA, MAA, MAA, MAA, MAA, MAA}
        /// result-1: {CRF, CRD, MAA} - {АЭС Пакш-2, АЭС Ханхикиви, АЭС Эль-Дабаа, Ленинградская АЭС-2, Белорусская АЭС, Узбекская АЭС}
        /// result-2: {CRF, CRD} - {Тяньваньская АЭС, АЭС Сюйдапу}
        /// </summary>
        public static ICa GetCa6()
        {
            return GetObject("27736.38003.43200.27510");
        }

        public static ICa GetObject(string id)
        {
            var objs = GetObjects(chemin);
            var obj = GetObjects(chemin).Where(o => o.Id == id).FirstOrDefault();
            return obj;
        }

        public static string Print(ICa searchRootObject)
        {
            var result = $"Id: {searchRootObject.Id}\nАЭС: {searchRootObject.Npps}\nСистемы: {searchRootObject.Systems}\nЗдания: {searchRootObject.Buildings}";
            return result;
        }

        public static string Print(IEnumerable<ICa> searchRootObjects)
        {
            var result = string.Empty;
            foreach (var searchRootObject in searchRootObjects)
                result = $"{Print(searchRootObject)}\n\n{result}";
            return result;
        }

        public static void PrintSpecializationsToFile()
        {
            var result = new List<string>();
            var enoviaCorrectionActions = GetObjects(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\09-09-2020-17-47-52.txt");

            enoviaCorrectionActions.Where(cA => cA.Specialization != null).Select(cA => cA.Specialization.ToList()).ToList().ForEach(specs => specs.ForEach(s => result.Add(s)));

            var folder = Directory.CreateDirectory("c:\\TFSS\\Temp\\TH000415EB03000000000000\\EnoviaExport\\EnoviaExport");
            var fileName = ($"{DateTime.Now.ToString().Replace(" ", "-").Replace(".", "-").Replace(":", "-")}.txt");
            var file = File.CreateText($"{folder.FullName}\\{fileName}");
            result.Distinct().ToList().ForEach(s => file.WriteLine(s));
            file.Close();

            return;
        }

        /// <summary>
        /// Retrieves correction actions from txt file
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ICa> GetObjects(string fullFileName)
        {
            var jsonString = new StreamReader(Path.GetFullPath(fullFileName), Encoding.UTF8).ReadToEnd();
            var objs = JsonConvert.DeserializeObject<List<Ca>>(jsonString);
            return objs.Cast<ICa>();
        }

        public static IEnumerable<ICa> GetObjectsSafe(string fullFileName)
        {
            try
            {
                return GetObjects(fullFileName);
            }
            catch (Exception)
            {
                return Enumerable.Empty<ICa>();
            }
        }

        /// <summary>
        /// Retrieves correction actions from the maximum upload time file of tdmsObject
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ICa> GetObjects(TDMSObject tdmsObject)
        {
            if (tdmsObject.Files.Count == 0) return new List<ICa>();

            var max = tdmsObject.Files.Max(f => Convert.ToDateTime(f.UploadTime));
            var file = tdmsObject.Files.FirstOrDefault(f => Convert.ToDateTime(f.UploadTime).Equals(max));
            file.CheckOut(tdmsObject.Files.Main.WorkFileName);
            return GetObjects(tdmsObject.Files.Main.WorkFileName);
        }

        /// <summary>
        /// Retrieves correction actions from Enovia
        /// All objects are within 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ICa> GetObjects()
        {
            var jsonString = new EnoviaHttpClient().GetResponse("json");
            var objs = JsonConvert.DeserializeObject<List<Ca>>(jsonString);
            return objs.Cast<ICa>();
        }

        public static DateTime ConvertToDateTime(string str)
        {
            var ar = str.Split(new char[] { Convert.ToChar("/"), Convert.ToChar(" "), Convert.ToChar(":") });

            int year = Convert.ToInt32(ar[2]);
            int month = Convert.ToInt32(ar[1]);
            int day = Convert.ToInt32(ar[0]);
            int hour = Convert.ToInt32(ar[3]);
            int minute = Convert.ToInt32(ar[4]);
            int second = Convert.ToInt32(ar[5]);

            DateTime date = new DateTime(year, month, day, hour, minute, second);
            return date;
        }
    }
}
