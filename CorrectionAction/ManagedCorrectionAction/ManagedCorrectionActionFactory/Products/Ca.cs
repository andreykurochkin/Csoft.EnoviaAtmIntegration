using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {

    public class Ca : ICa
    {
        protected ICaFactory factory;
        public Ca() { }
        public Ca(ICa correctionAction)
        {
            this.Buildings = correctionAction.Buildings;
            this.Description = correctionAction.Description;
            this.Export = correctionAction.Export;
            this.Id = correctionAction.Id;
            this.LongDescription = correctionAction.LongDescription;
            this.Modified = correctionAction.Modified;
            this.Name = correctionAction.Name;
            this.Npps = correctionAction.Npps;
            this.RelationShip3 = correctionAction.RelationShip3;
            this.Systems = correctionAction.Systems;
            this.Type = correctionAction.Type;
            this.HasFiles = correctionAction.HasFiles;
            this.SentToTdms = correctionAction.SentToTdms;
        }

        public Ca(ICaFactory factory)
        {
            this.factory = factory;
        }

        public Ca Configure()
        {
            Buildings = factory.CreateBuildings();
            Description = factory.CreateDescription();
            Export = factory.CreateExportDate();
            Id = factory.CreateId();
            LongDescription = factory.CreateLongDescription();
            Modified = factory.CreateEnoviaModifiedDate();
            Name = factory.CreateName();
            Npps = factory.CreateNpps();
            RelationShip3 = factory.CreateRelationShip3();
            Systems = factory.CreateSystems();
            Type = factory.CreateType();
            HasFiles = factory.CreateHasFiles();
            SentToTdms = factory.SentToTdms();

            return this;
        }

        [JsonProperty("relationship[pdPBSSystem].from.relationship[Subclass].to.to[Subclass].from.attribute[Title]")]
        public string Npps { get; set; }

        [JsonProperty("relationship[pdFaultToCorrection].from.attribute[pdBuildingName]")]
        public string Buildings { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attribute[pdHashField")]
        public string Description { get; set; }
        
        [JsonProperty("description")]
        public string LongDescription { get; set; }

        [JsonProperty("relationship[pdFaultToCorrection].from.id")]
        public string RelationShip3 { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("relationship[pdPBSSystem].from.attribute[Title]")]
        public string Systems { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("modified")]
        public string Modified { get; set; }
        
        public string Export { get; set; }
        
        [JsonProperty("relationship[pdFaultToCorrection].from.to[pdESKKSpec].from.attribute[Title]")]
        public string Specialization { get; set; }
        
        [JsonProperty("relationship[Active Version]")]
        public string HasFiles { get; set; }

        [JsonProperty("attribute[pdSentToTDMS]")]
        public string SentToTdms { get; set; }
    }
}