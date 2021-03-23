using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
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
using Tdms.Data;
using System.Runtime.CompilerServices;
using System.Net;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Encapsulates application report to be sent from tdms to enovia
    /// </summary>
    public class Ar {
        public TarFactory Factory { get; }
        public Ar(TarFactory factory) {
            Factory = factory;
        }
        public bool IsMatchingItem() {
            var hasApplicant = (!this.ApplicantName.Equals(string.Empty));
            var hasBuildingName = (!this.BuildingName.Equals(string.Empty));
            var hasNppId = (!this.NppId.Equals(string.Empty));
            var hasSetCode = (!this.SetCode.Equals(string.Empty));
            return hasApplicant & hasBuildingName & hasNppId & hasSetCode;
        }
        public Ar Configure() {
            this.ApplicantName = Factory.CreateApplicantName();
            this.BuildingName = Factory.CreateBuildingName();
            this.Description = Factory.CreateDescription();
            this.NppId = Factory.CreateNppId();
            this.NppUnit = Factory.CreateNppUnit();
            this.SetCode = Factory.CreateSetCode();
            this.SetName = Factory.CreateSetName();
            this.Status = Factory.CreateStatus();
            this.SystemName = Factory.CreateSystemName();
            this.EcaId = Factory.CreateEcaId();
            this.Revision = Factory.CreateRevision();

            return this;
        }

        public Ar(Ar ar) {
            this.ApplicantName = ar.ApplicantName;
            this.BuildingName = ar.BuildingName;
            this.Description = ar.Description;
            this.EcaId = ar.EcaId;
            this.NppId = ar.NppId;
            this.NppUnit = ar.NppUnit;
            this.Revision = ar.Revision;
            this.SetCode = ar.SetCode;
            this.SetName = ar.SetName;
            this.Status = ar.Status;
            this.SystemName = ar.SystemName;
        }

        /// <summary>
        /// код комплекта
        /// </summary>
        [JsonProperty("setCode")]
        public string SetCode { get; set; }

        /// <summary>
        /// номер блока
        /// </summary>
        [JsonProperty("nppUnit")]
        public string NppUnit { get; set; }

        /// <summary>
        /// статус отчета о применении {Accepted} {NotAccepted}
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// наименование комплекта
        /// </summary>
        [JsonProperty("setName")]
        public string SetName { get; set; }

        /// <summary>
        /// фио разработчика
        /// </summary>
        [JsonProperty("applicantName")]
        public string ApplicantName { get; set; }

        /// <summary>
        /// наименование системы или "-"
        /// </summary>
        [JsonProperty("systemName")]
        public string SystemName { get; set; }

        /// <summary>
        /// id станции
        /// </summary>
        [JsonProperty("nppId")]
        public string NppId { get; set; }

        /// <summary>
        /// наименование унифицированного здания
        /// </summary>
        [JsonProperty("buildingName")]
        public string BuildingName { get; set; }

        /// <summary>
        /// наименование корректирующего мероприятия
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }

        public string EcaId { get; set; }

        public override string ToString() {
            var str1 = $"ApplicantName: {this.ApplicantName}\n";
            var str2 = $"BuildingName: {this.BuildingName}\n";
            var str3 = $"Description: {this.Description}\n";
            var str4 = $"EcaId: {this.EcaId}\n";
            var str5 = $"NppId: {this.NppId}\n";
            var str6 = $"NppUnit: {this.NppUnit}\n";
            var str7 = $"Revision: {this.Revision}\n";
            var str8 = $"SetCode: {this.SetCode}\n";
            var str9 = $"SetName: {this.SetName}\n";
            var str10 = $"Status: {this.Status}\n";
            var str11 = $"SystemName: {this.SystemName}\n";

            return $"{str1}{str2}{str3}{str4}{str5}{str6}{str7}{str8}{str9}{str10}{str11}";
        }
    }
}