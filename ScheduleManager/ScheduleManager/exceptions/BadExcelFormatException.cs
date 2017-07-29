using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManager.exceptions
{
    [Serializable]
    public class BadExcelFormatException : Exception
    {
        public BadExcelFormatException() : base() { }

        public BadExcelFormatException(string message) : base(message) { }

        public BadExcelFormatException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
