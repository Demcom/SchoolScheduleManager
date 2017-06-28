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
using ScheduleManager.forms;

namespace ScheduleManager
{
    public partial class Form1 : Form
    {
        //Variables
        private UserAddForm objForma = new UserAddForm();
        private int tipoUsuario;

        public Form1(int tipoUsuario)
        {
            InitializeComponent();
            this.tipoUsuario = tipoUsuario;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExcelReader excelReader = new ExcelReader();
            excelReader.readExcel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Si el tipo de usuario es administrador activar sus funcionalidades
            if(tipoUsuario == 1)
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
    }
}
