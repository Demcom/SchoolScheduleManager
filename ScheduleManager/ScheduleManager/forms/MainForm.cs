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
using ScheduleManager.tools;

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

            ExcelReader excelReader = new ExcelReader();
            excelReader.readExcel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelReader.personalExcelToDB();
        }

        private void personalFrenteAGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelReader.personalFrenteAGrupoExcelToDB();
        }

        private void estructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelReader.EstructuraExcelToDB();
        }
    }
}
