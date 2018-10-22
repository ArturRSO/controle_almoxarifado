using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projeto_M2
{
    public partial class Autenticação : Form
    {
        public Autenticação()
        {
            InitializeComponent();
        }

        public void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string senha = txtSenha.Text;

            Admins Admin = new Admins();

            List<Admins> x = Admin.Enter();

            foreach (var z in x)
            {
                if (z.login == login && z.senha == senha)
                {
                        this.Visible = false;
                        Menu n = new Menu();
                        n.Show();
                }
                else
                {
                    MessageBox.Show("Login ou senha inválidos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
