using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCRUD
{
    public partial class Form1 : Form
    {
        GestionAudioVisEntities db = new GestionAudioVisEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = (from u in db.Usuarios
                         where u.Usuario1.Equals(txtUsuario.Text) &&
                               u.Clave.Equals(txtClave.Text)
                         select u).FirstOrDefault();

            if (usuario == null)
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            else if (!usuario.Estado.Equals("A"))
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            else
            {
                MessageBox.Show("Bienvenido " + txtUsuario.Text);
                FrmMenu frm = new FrmMenu();
                frm.ShowDialog();
            }
        }
    }
}