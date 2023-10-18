using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingCorners.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent //loglarımızı json formatında tutmak için gerekli bilgiler
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public string UserName { get { return _loggingEvent.UserName; } }
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
