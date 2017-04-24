using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
namespace ScheduleManager.interfaces
{
    interface IExcelReader
    {
        void readExcel();
        void renderExcel();
    }
}
