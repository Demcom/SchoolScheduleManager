using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleManager.common;
using ScheduleManager.model;

namespace ScheduleManager.forms
{
    public partial class LogInForm : Form
    {

        //Declaración de Variables
        private MD5 md5Hash;
        private string hash;
        private Encriptar objetoEncriptar;
        private Usuario usuario;
        private ScheduleManagerEntities contexto;

        public LogInForm()
        {
            InitializeComponent();
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            //Instanciar objeto de encriptación
            md5Hash = MD5.Create();
            objetoEncriptar = new Encriptar();
            contexto = new ScheduleManagerEntities();
            usuario = new Usuario();
            
            
            //Comprobar tamaño de la cadena de texto de los textbox
            if (textboxContraseña.TextLength > 0 && textboxUsuario.TextLength > 0)
            {
                hash = objetoEncriptar.GetMd5Hash(md5Hash, textboxContraseña.Text);

                //Comprobar si existe un usuario con esas credenciales
                var user = contexto.Usuarios.FirstOrDefault(u => u.nombre_usuario == textboxUsuario.Text && u.contraseña_usuarios == hash);

                if (user != null)
                {
                    //Abrir forma
                    UserAddForm form = new UserAddForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña o Usuario incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Contraseña o Usuario esta vacio");
            }

            //Limpiar campos de textbox
            textboxContraseña.Clear();
            textboxUsuario.Clear();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Salir de la aplicación
            Application.Exit();
        }
    }
}
