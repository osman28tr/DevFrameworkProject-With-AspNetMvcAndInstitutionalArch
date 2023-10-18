﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingCorners.Logging.Log4Net
{
    public class LoggerService //farklı ortamlarda farklı loglama seviyelerini tutabilmek için oluşturuldu.
    {
        private ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }
        public bool IsInfoEnabled //info seviyesindeki loglar açıkmı ona bakılır.
        {
            get { return _log.IsInfoEnabled; }
        }
        public bool IsDebugEnabled { get { return _log.IsDebugEnabled; } }
        public bool IsWarnEnabled { get { return _log.IsWarnEnabled; } }
        public bool IsFatalEnabled { get { return _log.IsFatalEnabled; } }
        public bool IsErrorEnabled { get { return _log.IsErrorEnabled; } }

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
    }
}
