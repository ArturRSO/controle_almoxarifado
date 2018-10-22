using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_M2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Estoque n = new Estoque();
            n.Show();
        }

        private void btnDepto_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Departamentos n = new Departamentos();
            n.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
