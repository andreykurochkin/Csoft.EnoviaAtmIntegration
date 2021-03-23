using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Gets maximum export date from Enovia to Tdms
    /// </summary>
    public class LastExportDate {
        private TDMSObjects Objects { get; }
        private string AttrName { get; }
        private Lazy<DateTime> dateTime;
        public LastExportDate(TDMSObjects objects, string attrName) {
            Objects = objects;
            AttrName = attrName;
            dateTime = new Lazy<DateTime>(() => {
                var values = new AttributeValues<DateTime>(
                    new Attributes(Objects, AttrName)
                );
                return values.Any() ? values.Max() : default(DateTime);
            });
        }
        public DateTime DateTime { get => dateTime.Value; }
    }
}
