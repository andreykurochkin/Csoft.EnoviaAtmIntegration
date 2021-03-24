using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// creates new tdmsObjects and versions of tdmsObjects
    /// </summary>
    public class UpdateFromEnoviaBehavior : IUpdateCorrectionActionsBehavior {
        protected UpdateContext client;
        protected DateTime exportDate;
        public UpdateFromEnoviaBehavior(UpdateContext client) {
            this.client = client;
            this.exportDate = new LastExportDate(
                client.TdmsContext.CaRoot.Objects, 
                TdmsContext.CaAttrExportName
            ).DateTime;
        }
        public void ProcessItems() {
            var ecas = new EcasBeforeDate(new Ecas(), this.exportDate);
            foreach (ICa eca in ecas) {
                ProcessItem(eca);
            }
        }
        private void ProcessItem(ICa eca) {
            var tdmsObjects = GetTdmsObjects(eca.Id).ToList();
            var noObjectsFound = (tdmsObjects.Count == 0);
            if (noObjectsFound) {
                CreateTdmsObject(eca);
                return;
            }
            var oldItems = tdmsObjects.Select(t => t.ToRestoredTdmsCorrectionAction()).ToList();
            var noObjectsRestored = (oldItems.Count == 0);
            if (noObjectsRestored) {
                CreateTdmsObject(eca);
                return;
            }

            var youthItems =new KudanTcaClient( new TcaClient(new McaClient(new List<ICa>() { eca }))).CreateItems();

            var pairs = new IntersectIdMapItemsFamily(oldItems, youthItems).CreateItems();

            var theVersion = this.GetMaxVersion(tdmsObjects) + 1;

            var itemsToUpdate = pairs.Select(p => p.youthItem);
            var itemsNew = youthItems.Except(itemsToUpdate, new CaIdAndSystemsEqualityComparer());

            new CreateFromTcaItemsBehavior(client, itemsNew).ProcessItems();

            foreach (var pair in pairs) {
                var behavior = new UpdateItemsFromTdmsCorrectionActionsBehavior(client, new List<ICa>() { pair.youthItem }, ((RestoredTdmsCorrectionAction)pair.oldItem).tdmsObject, theVersion);
                behavior.ProcessItems();
            }
        }
        private void CreateTdmsObject(ICa enoviaCorrectionAction) {
            new CreateFromEnoviaCorrectionActionBehavior(this.client, enoviaCorrectionAction).ProcessItems();
        }
        private int GetMaxVersion(IEnumerable<TDMSObject> tdmsObjects) {
            try {
                return tdmsObjects.Select(tdmsObject => Convert.ToInt32(tdmsObject.VersionName)).Max();
            }
            catch (Exception) {
                return 0;
            }
        }
        /// <summary>
        /// Retrieves tdmsObjects within one Id and filters by maximum version name
        /// Provides same version name within same Id
        /// </summary>
        /// <param name="id">Id of ICorrectionAction</param>
        /// <returns></returns>
        private IEnumerable<TDMSObject> GetTdmsObjects(string id) {
            var tdmsObjectsById = client.TdmsContext.GetCaItemsById(id);
            var maxVersion = GetMaxVersion(tdmsObjectsById);
            var tdmsObjectsByIdByVersion = tdmsObjectsById.Where(tdmsObject => Convert.ToInt32(tdmsObject.VersionName).Equals(maxVersion));
            return tdmsObjectsByIdByVersion;
        }
        //public virtual IEnumerable<ICa> GetEcaItems() {
        //    var result = Utility.GetObjects().Where(c => {
        //        try {
        //            return (Utility.ConvertToDateTime(c.Modified).Date >= this.exportDate);
        //        }
        //        catch (Exception ex) {
        //            LogManager.GetLogger("UpdateFromEnoviaBehavior").Debug($"{ex.Message}, {c.Modified}");
        //            return false;
        //        }
        //    });

        //    LogManager.GetLogger("UpdateFromEnoviaBehavior").Debug($"amount of correctin actions to be updated: {result.Count()}");

        //    return result;
        //}
    }
}
