﻿using System;
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

        private async void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            var progress = new Progress<int>(percent => updateProgressBarImporting(percent));
            await Task.Run(() => ExcelReader.personalExcelToDB(progress, path));
        }

        private async void personalFrenteAGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            var progress = new Progress<int>(percent => updateProgressBarImporting(percent));
            await Task.Run(() => ExcelReader.personalFrenteAGrupoExcelToDB(progress, path));
        }

        private async void estructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            var progress = new Progress<int>(percent => updateProgressBarImporting(percent));
            await Task.Run(() => ExcelReader.EstructuraExcelToDB(progress, path));
        }

        private async void distribuciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            var progress = new Progress<int>(percent => updateProgressBarImporting(percent));
            await Task.Run(() => ExcelReader.DistribucionExcelToDB(progress, path));
        }

        void updateProgressBarImporting(int percent)
        {
            importarToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = percent + "%" + " Importando...";
            toolStripProgressBar1.Value = percent;

            if (percent == 100)
            {
                toolStripStatusLabel1.Text = "Terminado";
                importarToolStripMenuItem.Enabled = true;
            }
        }
    }
}
