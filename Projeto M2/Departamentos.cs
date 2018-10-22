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
    public partial class Departamentos : Form
    {
        public Departamentos()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCod.Text);

            bool s = false;

            Depto x = new Depto();

            List<Depto> p = x.Listar();

            foreach (var Z in p)
            {
                if (Z.ID == id)
                {
                    txtCod.Text = Z.ID.ToString();
                    txtNome.Text = Z.Nome;
                    txtEvento.Text = Z.Evento;
                    txtFreq.Text = Z.Freq.ToString();

                    s = true;

                    break;
                }
            }

            if (s == false)
            {
                txtCod.Clear();
                txtNome.Clear();
                txtEvento.Clear();
                txtFreq.Clear();
                MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int id = int.Parse(txtCod.Text);
            string evento = txtEvento.Text;
            int frequencia = int.Parse(txtFreq.Text);

            Depto x = new Depto();

            x.ID = id;
            x.Nome = nome;
            x.Evento = evento;
            x.Freq = frequencia;

            x.Cadastrar();

            MessageBox.Show("Produto cadastrado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtCod.Text);

            Depto x = new Depto();

            x.ID = id;
            x.Nome = txtNome.Text;
            x.Evento = txtEvento.Text;
            x.Freq = int.Parse(txtFreq.Text);

            x.alterar();
            MessageBox.Show("Registro alterado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            DGVdepto.Rows.Clear();

            Depto x = new Depto();
            List<Depto> p = x.Listar();

            for (int i = 0; i < p.Count; i++)
            {
                string[] nova_linha = { p[i].ID.ToString(), p[i].Nome, p[i].Evento, p[i].Freq.ToString() };
                DGVdepto.Rows.Add(nova_linha);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Confirma exclusão do registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            Depto x = new Depto();

            if (resposta == DialogResult.Yes)
            {
                int id = int.Parse(DGVdepto.CurrentRow.Cells["ID"].Value.ToString());
                x.ID = id;
                x.excluir();

                MessageBox.Show("Registro excluido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TSMClear_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtNome.Clear();
            txtEvento.Clear();
            txtFreq.Clear();
            DGVdepto.Rows.Clear();
        }

        private void TSMMainMenu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu M = new Menu();
            M.Show();
        }
    }
}
