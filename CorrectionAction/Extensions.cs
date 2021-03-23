using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Newtonsoft.Json;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public static class Extensions {
        public static string Trim(this string str, int trimLength) {
            if (string.IsNullOrEmpty(str)) {
                return string.Empty;
            }
            return (str.Length > trimLength) ? str.Substring(0, trimLength) : str;
        }
        public static string ToFioSafe(this TDMSUser user) {
            try {
                return ToFio(user);
            }
            catch (Exception) {
                return string.Empty;
            }
        }

        public static string ToFio(this TDMSUser user) {
            return $"{user.FirstName} " +
                $"{user.MiddleName} " +
                $"{user.LastName}";
        }

        public static string ToJson(this Ar ar) {
            return JsonConvert.SerializeObject(ar);
        }

        public static string ToJsonSafe(this Ar ar) {
            try {
                return ar.ToJson();
            }
            catch (Exception) {
                return string.Empty;
            }
        }
        public static string ToBase64String(this string str) {
            byte[] inArray = System.Text.UTF8Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// creates char(7), ',' separated items or empty list
        /// </summary>
        /// <param name="str">source string</param>
        /// <returns></returns>
        public static List<string> ToList(this string str) {
            try {
                if (String.IsNullOrEmpty(str)) {
                    return new List<string>();
                }
                return str.Split(new char[] { Convert.ToChar(7), ',' }).ToList().Select(s => s.Trim()).ToList();
            }
            catch (Exception) {
                return new List<string>();
            }
        }

        /// <summary>
        /// creates char(7), ',' separated items or list with single dash
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> ToListOrDash(this string str) {
            var list = str.ToList();
            return (list.Count == 0)
                ? new List<string>() { "-" } : list;
        }

        /// <summary>
        /// is immutable
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> ToListImmutable(this string[] input) {
            var list = new List<int>();

            if (input == null) return list;

            foreach (var item in input) {
                int @try;
                if (int.TryParse(item, out @try)) list.Add(@try);
            }

            return list;
        }

        /// <summary>
        /// shows if collection has item
        /// </summary>
        /// <param name="lists">collection of lists</param>
        /// <param name="list">list of string</param>
        /// <returns></returns>
        public static bool Has(this List<List<string>> lists, List<string> list) {
            foreach (var item in lists)
                if (list.IsContentEqual(item)) return true;
            return false;
        }

        /// <summary>
        /// returns true if collection does not have item
        /// </summary>
        /// <param name="lists">collection of lists</param>
        /// <param name="list">list of string</param>
        /// <returns></returns>
        public static bool HasNot(this List<List<string>> lists, List<string> list) {
            return !Has(lists, list);
        }

        /// <summary>
        /// returns true if same length lists has same elements
        /// </summary>
        /// <param name="x">first list of string</param>
        /// <param name="y">second list of string</param>
        /// <returns>true if lists have same length and same elements</returns>
        public static bool IsContentEqual(this List<string> x, List<string> y) {
            if (x == null) return false;
            if (y == null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.Count != y.Count) return false;

            var alterX = new List<string>();
            alterX.AddRange(x);
            var alterY = new List<string>();
            alterY.AddRange(y);
            alterX.Sort();
            alterY.Sort();

            for (int i = 0; i < x.Count; i++) {
                if (alterX[i] != alterY[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// returns true if same length lists has same elements
        /// </summary>
        /// <param name="x">first list of string</param>
        /// <param name="y">second list of string</param>
        /// <returns>true if lists have same length and same elements</returns>
        public static bool IsContentEqual(this List<int> x, List<int> y) {
            if (x == null) return false;
            if (y == null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.Count != y.Count) return false;

            var alterX = new List<int>();
            alterX.AddRange(x);
            var alterY = new List<int>();
            alterY.AddRange(y);
            alterX.Sort();
            alterY.Sort();

            for (int i = 0; i < x.Count; i++) {
                if (alterX[i] != alterY[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// distinct similar items
        /// </summary>
        /// <param name="lists"></param>
        /// <returns>new list with unsimilar items</returns>
        public static List<List<string>> Unrepeat(this List<List<string>> lists) {
            var result = new List<List<string>>();
            foreach (var list in lists)
                if (result.HasNot(list)) result.Add(list);
            return result;
        }

        /// <summary>
        /// Creates TdmsCorrectionAction from TdmsObject. Is mutable
        /// </summary>
        /// <param name="tdmsObject"></param>
        public static ICa ToRestoredTdmsCorrectionAction(this TDMSObject tdmsObject) {
            var assertIsNull = tdmsObject == null;
            if (assertIsNull) return new Ca();

            var assertIsCorrectionAction = tdmsObject.ObjectDefName.Equals(TdmsContext.caObjectDefName);
            if (!assertIsCorrectionAction) return new Ca();

            var tdmsCorrectionAction = new RestoredTdmsCorrectionAction(
                new TdmsCorrectionActionsFactoryFromTdmsObject(tdmsObject, new NppMaps()), tdmsObject);
            tdmsCorrectionAction.Configure();
            return tdmsCorrectionAction;
        }

        /// <summary>
        /// Create Application report from TdmsObject
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>


        public static string GetGuidSilent(this TDMSAttribute attribute) {
            try {
                return attribute.Object.GUID;
            }
            catch (Exception) {
                return string.Empty;
            }

        }

        /// <summary>
        /// splits string into substrings of integers
        /// </summary>
        /// <param name="regex"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] SplitSilent(this SubstringsOfIntegersRegex regex, string input) {
            try {
                return regex.Split(input);
            }
            catch (Exception) {
                return null;
            }
        }
        internal static IEnumerable<TDMSObject> GetObjectsByGUIDs(
            this TDMSApplication app,
            IEnumerable<string> guids
        ) {
            return guids.Select(g => app.GetObjectByGUID(g));
        }

        internal static IEnumerable<TDMSObject> GetObjectsByGUIDs(
            this TDMSApplication app,
            List<CacheItem> cache,
            string Id) {
            return cache
                .Where(c => c.Id == Id)
                .Select(c => c.Guid)
                .Select(g => app.GetObjectByGUID(g));

        }
        public static DateTime ToDateTime(this string date) {
            var t = date.ToTuple();
            return new DateTime(t.Item1, t.Item2, t.Item3, t.Item4, t.Item5, t.Item6);
        }
        private static Tuple<int, int, int, int, int, int> ToTuple(this string date) {
            var @default = new Tuple<int, int, int, int, int, int>(1, 1, 1, 0, 0, 0);
            if (string.IsNullOrEmpty(date)) {
                return @default;
            }
            var ints = new List<int>();
            var ar = date.Split(new char[] { '/', ' ', ':' });
            int i;
            foreach (string item in ar) {
                if (int.TryParse(item, out i)) {
                    ints.Add(i);
                }
            }
            if (ints.Count != 6) {
                return @default;
            }
            return new Tuple<int, int, int, int, int, int>(ints[2], ints[1], ints[0], ints[3], ints[4], ints[5]);
        }
    }
}
