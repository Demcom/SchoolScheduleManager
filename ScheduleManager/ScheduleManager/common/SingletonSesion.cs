using ScheduleManager.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScheduleManager.model;

namespace ScheduleManager.common
{
    class SingletonSesion
    {
        private volatile static SingletonSesion objetoUsuarios;
        private static object bloqueoObjeto = new object();
        private ScheduleManagerEntities contexto;

        private SingletonSesion()
        {

        }

        public static SingletonSesion CreacionInstancia()
        {
            if (objetoUsuarios == null)
            {
                lock (bloqueoObjeto)
                {
                    if (objetoUsuarios == null)
                    {
                        objetoUsuarios = new SingletonSesion();
                    }
                }
            }
            return objetoUsuarios;
        }

        public void AñadirUsuarios(int usuario)
        {
            contexto = new ScheduleManagerEntities();
            var query = contexto.Usuarios.FirstOrDefault(u => u.id_usuario == usuario && u.id_cuenta == 1);
            if (query != null)
            {
                UserAddForm forma = new UserAddForm();
                forma.Show();
            }
            else
            {
                MessageBox.Show("No tiene permiso");
            }
        }
    }
}
