using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class NoFileWithContentBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;
        public NoFileWithContentBehavior(UpdateContext client)
        {
            this.client = client;
        }
        public void ProcessItems()
        {
            throw new ApplicationException($"В объекте {this.client.TdmsContext.CaRoot.Description} отсутствуют файлы. Добавьте файл, удалите объекты из состава. Повторите запуск команды");
        }
    }

}
