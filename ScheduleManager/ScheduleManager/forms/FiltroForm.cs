using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleManager.forms
{
    public partial class TestData : Form
    {
        public TestData()
        {
            InitializeComponent();
        }

        private void TestData_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'scheduleManagerDataSet.Estructura' Puede moverla o quitarla según sea necesario.
            this.estructuraTableAdapter.Fill(this.scheduleManagerDataSet.Estructura);

        }
    }
}
