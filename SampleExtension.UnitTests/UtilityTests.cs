using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Log;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain.Csoft.EnoviaAtmIntegration.Domain.UnitTests
{
    class UtilityTests
    {
        private ILogger log = LogManager
            .GetLogger($"{typeof(UtilityTests)}");

        public void GetRowsSafe_TableWithRows_ReturnsNumberOfRows(
            TDMSApplication app)
        {
            var kspp = app.GetObjectByGUID(
                "{7963AD9F-294E-4A7E-A0C4-3D2B52BD380B}");
            var table = kspp.Attributes["A_TblWorkability"];

            var rows = Utility.GetRowsSafe(table);
            var result = rows.Count();

            log.Debug("method: GetRowsSafe");
            log.Debug("scenario: TableWithRows");
            log.Debug($"behavior: returns number of rows: {result}");
        }

        public void GetRowsSafe_NullAttribute_ReturnsEnumerableEmpty(
            TDMSApplication app)
        {
            var kspp = app.GetObjectByGUID(
                "{7963AD9F-294E-4A7E-A0C4-3D2B52BD380B}");
            var table = kspp.Attributes["A_TblWorkability_Does_Not_Exist"];

            var rows = Utility.GetRowsSafe(table);
            var result = rows.Equals(
                Enumerable.Empty<TDMSTableAttributeRow>());

            log.Debug("method: GetRowsSafe");
            log.Debug("scenario: NullAttribute");
            log.Debug($"behavior: returns enumerable empty: {result}");
        }

        public void GetRowsSafe_NotTable_ReturnsEnumerableEmpty(
            TDMSApplication app)
        {
            var kspp = app.GetObjectByGUID(
                "{7963AD9F-294E-4A7E-A0C4-3D2B52BD380B}");
            var table = kspp.Attributes["A_Fl_OutTechCntrl"];

            var rows = Utility.GetRowsSafe(table);
            var result = rows.Equals(
                Enumerable.Empty<TDMSTableAttributeRow>());

            log.Debug("method: GetRowsSafe");
            log.Debug("scenario: ObjectHasNoTable");
            log.Debug($"behavior: returns enumerable empty: {result}");
        }

        public void GetRowsSafe_NoRowsTable_ReturnsEnumerableEmpty(
            TDMSApplication app)
        {
            var kspp = app.GetObjectByGUID(
                "{367F6686-E9BD-42C1-A1D3-05EAC8A55447}");
            var table = kspp.Attributes["A_Obj_Ref_Tbl"];

            var rows = Utility.GetRowsSafe(table);
            var result = rows.Count();

            log.Debug("method: GetRowsSafe");
            log.Debug("scenario: NoRowsTable");
            log.Debug($"behavior: returns number of rows: {result}");
        }
    }
}
