using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManager.enums;
using System.Windows.Forms;
using ScheduleManager.common;
using ScheduleManager.tools;
using ScheduleManager.forms;
using ScheduleManager.exceptions;
using ScheduleManager.model;

namespace ScheduleManager
{
    public partial class Form1 : Form
    {
        //Variables
        private UserAddForm objForma = new UserAddForm();
        private int tipoUsuario;
        private ScheduleManagerEntities context;
        public Form1(int tipoUsuario)
        {
            InitializeComponent();
            dataGridView1.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right |
                AnchorStyles.Top |
                AnchorStyles.Left;
            this.tipoUsuario = tipoUsuario;
            this.context = new ScheduleManagerEntities();


        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExcelReader excelReader = new ExcelReader();
            excelReader.readExcel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (tipoUsuario == 1)
            {
                cuentaToolStripMenuItem.Visible = true;
            }
            else
            {
                cuentaToolStripMenuItem.Visible = false;
            }

        }

        private void cuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abrir una nueva de ventana de UserAddForm
            objForma.Show();
        }

        private async void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ExcelReader.personalExcelToDB();
            // dataGridView1.DataSource = bindingSource1;
            // dataGridView1.DataMember = "Personal";
            // personalTableAdapter.Fill(this.scheduleManagerDataSet.Personal);
          
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            if (path != "")
            {
                var progress = new Progress<int>(percent => updateProgressBarImporting(percent));

                try
                {
                    await Task.Run(() => ExcelReader.personalExcelToDB(progress, path));
                    var pers = context.Personals.ToList();
                    dataGridView1.DataSource = pers;    
                }
                catch (BadExcelFormatException)
                {
                    MessageBox.Show("El documento no tiene el formato esperado.", "Documento mal formado.");
                }
            }
        }

        private async void personalFrenteAGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            if (path != "")
            {
                var progress = new Progress<int>(percent => updateProgressBarImporting(percent));

                try
                {
                    await Task.Run(() => ExcelReader.personalFrenteAGrupoExcelToDB(progress, path));
                    var group = context.PersonalFrenteAGrupo.ToList();
                    dataGridView1.DataSource = group;    
                }
                catch (BadExcelFormatException)
                {
                    MessageBox.Show("El documento no tiene el formato esperado.", "Documento mal formado.");
                }
            }
        }

        private async void estructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ExcelReader.personalFrenteAGrupoExcelToDB();
            // dataGridView1.DataSource = bindingSource1;
            // dataGridView1.DataMember = "Distribucion";
            // personalFrenteAGrupoTableAdapter.Fill(this.scheduleManagerDataSet.PersonalFrenteAGrupo);
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            if (path != "")
            {
                var progress = new Progress<int>(percent => updateProgressBarImporting(percent));

                try
                {
                    await Task.Run(() => ExcelReader.EstructuraExcelToDB(progress, path));
                    var struc = context.Estructura.ToList();
                    dataGridView1.DataSource = struc;    
                }
                catch (BadExcelFormatException)
                {
                    MessageBox.Show("El documento no tiene el formato esperado.", "Documento mal formado.");
                }
            }
        }

        private async void distribuciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
//             ExcelReader.EstructuraExcelToDB();
//             dataGridView1.DataSource = bindingSource1;
//             dataGridView1.DataMember = "Estructura";
//             estructuraTableAdapter.Fill(this.scheduleManagerDataSet.Estructura);
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);
            if (path != "")
            {
                var progress = new Progress<int>(percent => updateProgressBarImporting(percent));

                try
                {
                    await Task.Run(() => ExcelReader.DistribucionExcelToDB(progress, path));
                    var dist = context.Distribucion.ToList();
                    dataGridView1.DataSource = dist;    
                }
                catch (BadExcelFormatException)
                {
                    MessageBox.Show("El documento no tiene el formato esperado.", "Documento mal formado.");
                }
            }
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

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltroForm filtro = new FiltroForm();
            filtro.Show();
        }

        private void mostrarDistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.DataMember = "Distribucion";
            personalFrenteAGrupoTableAdapter.Fill(this.scheduleManagerDataSet.PersonalFrenteAGrupo);
        }
    }
}
