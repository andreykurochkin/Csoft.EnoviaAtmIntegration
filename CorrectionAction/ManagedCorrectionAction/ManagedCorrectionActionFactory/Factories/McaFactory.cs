using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    class McaFactory : ICaFactory
    {
        private ICa eca;
        private SystemsRelationship systemsRelationship;

        public McaFactory(ICa eca, SystemsRelationship systemsRelationship)
        {
            this.eca = eca;
            this.systemsRelationship = systemsRelationship;
        }

        public string CreateBuildings()
        {
            var listOfBuildings = eca.Buildings.ToList().Select(str =>
            {
                str = str.Trim();
                str = str.Replace("OO", string.Empty);
                str = Regex.Replace(str, @"[\d]", string.Empty);
                str = Regex.Replace(str, @"[а-яА-Я]", string.Empty);
                if (str.Length > 3) str = str.Substring(0, 3);
                return str;
            });
            return String.Join(", ", listOfBuildings);
        }

        public string CreateNpps()
        {
            return this.systemsRelationship.Npps;
        }

        public string CreateSystems()
        {
            return this.systemsRelationship.Systems;
        }

        public string CreateDescription()
        {
            return eca.Description;
        }

        public string CreateLongDescription()
        {
            return eca.LongDescription;
        }

        public string CreateEnoviaModifiedDate()
        {
            return eca.Modified;
        }

        public string CreateExportDate()
        {
            return System.DateTime.Now.Date.ToString();
        }

        public string CreateId()
        {
            return eca.Id;
        }

        public string CreateName()
        {
            return eca.Name;
        }

        public string CreateRelationShip3()
        {
            return eca.RelationShip3;
        }

        public string CreateType()
        {
            return eca.Type;
        }

        public string CreateHasFiles()
        {
            return eca.HasFiles;
        }

        public string SentToTdms()
        {
            return eca.SentToTdms;
        }
    }
}
