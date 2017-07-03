using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleManager.common;
using ScheduleManager.model;
using System.Security.Cryptography;

namespace ScheduleManager.forms
{
    public partial class UserAddForm : Form
    {

        //Declaración de Variables
        private MD5 md5Hash;
        private string hash;
        private Encriptar objetoEncriptar;
        private ScheduleManagerEntities contexto;
        private Usuario usuario;
        private Usuarios objetoMetodos;
        private int opcbutton = 1;
        private int indexLista;

        public UserAddForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Salir de aplicación
            this.Close();
        }

        private void listarCuentas()
        {
            contexto = new ScheduleManagerEntities();

            var query = (from a in contexto.Cuentas select "-- Seleccione --").Concat(
                        from p in contexto.Cuentas
                        select p.nombre_cuenta);

            comboboxCuenta.DisplayMember = "nombre_cuenta";
            comboboxCuenta.DataSource = query.Distinct().ToList();
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            objetoMetodos = new Usuarios();

            listarCuentas();

            //Listar Usuarios
            listView1.Items.Clear();
            objetoMetodos.listarUsuario(listView1);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (opcbutton == 2)
            {
                buttonAñadir.Text = "Añadir";
                groupBox1.Enabled = true;
                opcbutton = 1;
                return;
            }
                
            this.Close();
        }

        private void buttonAñadir_Click(object sender, EventArgs e)
        {
            //Definición de objetos
            contexto = new ScheduleManagerEntities();
            objetoMetodos = new Usuarios();
            md5Hash = MD5.Create();
            objetoEncriptar = new Encriptar();

            if (opcbutton == 1)
            {
                //Comprobación
                if (comboboxCuenta.SelectedIndex == 0)
                {
                    MessageBox.Show("Seleccione un tipo de cuenta");
                    return;
                }

                //Encriptar contraseña
                hash = objetoEncriptar.GetMd5Hash(md5Hash, textboxContraseña.Text);

                //Creamos objeto de Usuario con los atributos añadidos
                usuario = new Usuario()
                {
                    nombre_usuario = textboxUsuario.Text,
                    id_cuenta = comboboxCuenta.SelectedIndex,
                    contraseña_usuarios = hash
                };

                objetoMetodos.añadirUsuario(usuario);

                //Limpiar textbox
                textboxUsuario.Clear();
                textboxContraseña.Clear();
            }

            if (opcbutton == 2)
            {
                groupBox1.Enabled = true;
                buttonAñadir.Text = "Añadir";
                
                //Convertimos el item seleccionado y mediante el id borramos
                int index = Convert.ToInt32(listView1.Items[indexLista].SubItems[0].Text);
                usuario = contexto.Usuarios.First(p => p.id_usuario == index);
                contexto.Usuarios.Remove(usuario);
                contexto.SaveChanges();
                opcbutton = 1;
            }

            //Listar datos
            listView1.Items.Clear();
            objetoMetodos.listarUsuario(listView1);

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            indexLista = e.Item.Index;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            //Cambiar titulo del botón
            buttonAñadir.Text = "Borrar";
            opcbutton = 2;
            groupBox1.Enabled = false;
        }
    }
}
