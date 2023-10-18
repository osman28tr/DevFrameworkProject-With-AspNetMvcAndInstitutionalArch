﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingCorners.Logging.Log4Net.Loggers
{
    public class FileLogger:LoggerService
    {
        public FileLogger():base(LogManager.GetLogger("JsonFileLogger"))
        {

        }
    }
}
