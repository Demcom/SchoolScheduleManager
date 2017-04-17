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
        void ReadExcel();
        void RenderExcel();
    }
}
