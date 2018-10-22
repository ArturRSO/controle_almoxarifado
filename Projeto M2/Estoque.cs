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
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            int id = int.Parse(txtCod.Text);
            string desc = txtDesc.Text;
            double preco = double.Parse(txtPreco.Text);
            int qtde = int.Parse(txtQTDE.Text);

            Produtos x = new Produtos();

            x.ID = id;
            x.Nome = nome;
            x.QTDE = qtde;
            x.Preco = preco;
            x.Desc = desc;

            x.Cadastrar();

            MessageBox.Show("Produto cadastrado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            DGVEstoque.Rows.Clear();

            Produtos x = new Produtos();
            List<Produtos> p = x.Listar();

            for (int i = 0; i < p.Count; i++)
            {
                string[] nova_linha = {p[i].ID.ToString(), p[i].Nome, p[i].QTDE.ToString(), p[i].Preco.ToString(), p[i].Desc };
                DGVEstoque.Rows.Add(nova_linha);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Confirma exclusão do registro?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            Produtos x = new Produtos();

            if (resposta == DialogResult.Yes)
            {
                int id = int.Parse(DGVEstoque.CurrentRow.Cells["ID"].Value.ToString());
                x.ID = id;
                x.excluir();

                MessageBox.Show("Registro excluido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TSMClearAll_Click(object sender, EventArgs e)
        {
            txtCod.Clear();
            txtDesc.Clear();
            txtNome.Clear();
            txtPreco.Clear();
            txtQTDE.Clear();
            DGVEstoque.Rows.Clear();
        }

        private void TSMMainMenu_Click(object sender, EventArgs e)
        {
            this.Visible=false;
            Menu M = new Menu();
            M.Show();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCod.Text);

            bool s = false;

            Produtos x = new Produtos();

            x.ID = id;

            List<Produtos> p = x.Listar();

            foreach (var Z in p)
            {
               if (Z.ID == id)
               {
                   txtCod.Text = Z.ID.ToString();
                   txtNome.Text = Z.Nome;
                   txtQTDE.Text = Z.QTDE.ToString();
                   txtPreco.Text = Z.Preco.ToString();
                   txtDesc.Text = Z.Desc;

                    s = true;

                   break;
                }
            }

            if (s == false)
            {
                txtCod.Clear();
                txtDesc.Clear();
                txtNome.Clear();
                txtPreco.Clear();
                txtQTDE.Clear();
                MessageBox.Show("Registro não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCod.Text);

            Produtos x = new Produtos();

            x.ID = id;

            List<Produtos> p = x.Enter();

            x.Nome = txtNome.Text;
            x.QTDE = int.Parse(txtQTDE.Text);
            x.Preco = double.Parse(txtPreco.Text);
            x.Desc = txtDesc.Text;

            x.alterar();
            MessageBox.Show("Registro alterado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
