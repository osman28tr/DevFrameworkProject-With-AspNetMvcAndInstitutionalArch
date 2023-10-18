using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingCorners.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton //verilerimizi json
    //formatında tutmak için gerekli layout tanımlamamızı yaptık.
    {
        public override void ActivateOptions()
        {
            throw new NotImplementedException();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent); //loglanacak datayı ve username'i gectik.
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented); //logevent'i json'a çevirdik.
            writer.WriteLine(json); //ilgili ortama yazdık.        
        }
    }
}
