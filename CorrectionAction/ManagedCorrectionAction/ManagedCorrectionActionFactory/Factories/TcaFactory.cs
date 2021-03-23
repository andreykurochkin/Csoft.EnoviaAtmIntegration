using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Domain;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class TcaFactory : ICaFactory {
        private ICa cA;
        private NppMaps NppMaps;
        public TcaFactory(ICa cA) : this(cA, new NppMaps()) { }
        public TcaFactory(ICa correctionAction,
            NppMaps NppMaps) {
            this.cA = correctionAction;
            this.NppMaps = NppMaps;
        }
        public string CreateBuildings() {
            return cA.Buildings;
        }
        /// <summary>
        ///  returns guids
        /// </summary>
        /// <returns></returns>
        public string CreateNpps() {
            var nppNames = this.cA.Npps.ToList();

            var guidsByNppName = this.NppMaps
                .Where(nppMap => nppNames.Contains(nppMap.Name));
            return String.Join(", ", guidsByNppName
                .Select(nppMap => nppMap.Guid).ToList());
        }

        public string CreateSystems() {
            return this.cA.Systems;
        }

        public string CreateDescription() {
            return cA.Description;
        }

        public string CreateLongDescription() {
            return cA.LongDescription;
        }

        public string CreateEnoviaModifiedDate() {
            return this.cA.Modified;
        }

        public string CreateExportDate() {
            return DateTime.Now.ToString();
        }

        public string CreateId() {
            return this.cA.Id;
        }

        public string CreateName() {
            return cA.Name;
        }

        public string CreateRelationShip3() {
            return this.cA.RelationShip3;
        }

        public string CreateType() {
            return this.cA.Type;
        }

        public string CreateHasFiles() {
            return this.cA.HasFiles;
        }

        public string SentToTdms() {
            return this.cA.SentToTdms;
        }
    }
}
