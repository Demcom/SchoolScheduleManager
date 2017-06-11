using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleManager.model;
using System.Data.Entity;
using System.Windows.Forms;

namespace ScheduleManager.common
{
    public sealed class Usuarios
    {
        private ScheduleManagerEntities contexto;

        public void añadirUsuario(Usuario usuario)
        {
            contexto = new ScheduleManagerEntities();
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public void listarUsuario(ListView list)
        {
            contexto = new ScheduleManagerEntities();
            var usuarios = contexto.Usuarios.ToList();

            foreach (var user in usuarios)
            {
                ListViewItem ilst = list.Items.Add(user.id_usuario.ToString());
                ilst.SubItems.Add(user.nombre_usuario);
                ilst.SubItems.Add(user.Cuenta.nombre_cuenta);
                ilst.SubItems.Add(user.contraseña_usuarios);
            }
        }
    }
}
