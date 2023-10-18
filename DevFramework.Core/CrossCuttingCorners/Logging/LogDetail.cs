using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingCorners.Logging
{
    public class LogDetail //ilgili log parameter'ın daha detaylı bilgilerini tutar.
    {
        public string FullName { get; set; } //namespace'deki class
        public string MethodName { get; set; } //class'daki hangi metot
        public List<LogParameter> Parameters { get; set; } //metodun parametrelerini tutar.
    }
}
