using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManager.enums;
using System.Windows.Forms;
using ScheduleManager.common;

namespace ScheduleManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //FileBrowser is a Singleton to get the path of a file as patametters it takes the file format
            FileBrowser.Instance.getFilePathWithFormat(FileFormatsEnum.EXCELFILES);
        }
    }
}
