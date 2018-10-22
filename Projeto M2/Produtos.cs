using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Projeto_M2
{
    class Produtos
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int QTDE { get; set; }
        public double Preco { get; set; }
        public string Desc { get; set; }

        public Produtos()
        { }

        public Produtos(int id, string nome, int qtde, double preco, string desc)
        {
            this.ID = id;
            this.Nome = nome;
            this.QTDE = qtde;
            this.Preco = preco;
            this.Desc = desc;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "INSERT INTO Estoque (id_produto, nome, qtde, preco, descricao) VALUES (@id_produto, @nome, @qtde, @preco, @descricao)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_produto", this.ID));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@qtde", this.QTDE));
                cmd.Parameters.Add(new NpgsqlParameter("@preco", this.Preco));
                cmd.Parameters.Add(new NpgsqlParameter("@descricao", this.Desc));
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("   Erro!   " + e.Message);
            }

            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public List<Produtos> Listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new ConectaDB().getConexao();
                string sql = "SELECT * FROM Estoque";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Produtos> listaProdutos = new List<Produtos>();
                while (dr.Read())
                {
                    Produtos novoProduto = new Produtos();
                    novoProduto.ID = Convert.ToInt16(dr["id_produto"]);
                    novoProduto.Nome = dr["Nome"].ToString();
                    novoProduto.QTDE = Convert.ToInt16(dr["QTDE"]);
                    novoProduto.Preco = Convert.ToDouble(dr["Preco"]);
                    novoProduto.Desc = dr["descricao"].ToString();

                    listaProdutos.Add(novoProduto);
                }
                return listaProdutos;
            }
            catch (Exception e)
            {
                throw new Exception("   Erro!   " + e.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public List<Produtos> Enter()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "SELECT * from estoque";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Produtos> listaProdutos = new List<Produtos>();
                while (dr.Read())
                {
                    Produtos novoProduto = new Produtos();
                    novoProduto.ID = Convert.ToInt16(dr["id_produto"]);
                    novoProduto.Nome = dr["Nome"].ToString();
                    novoProduto.QTDE = Convert.ToInt16(dr["QTDE"]);
                    novoProduto.Preco = Convert.ToDouble(dr["Preco"]);
                    novoProduto.Desc = dr["descricao"].ToString();

                    listaProdutos.Add(novoProduto);
                }

                return listaProdutos;
            }
            catch (Exception ex)
            {
                throw new Exception("   Erro!   " + ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public void excluir()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "delete from estoque where id_produto=@id_produto;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_produto", ID));

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("   Erro!   " + e.Message);
            }

            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }

        }

        public void alterar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "UPDATE estoque SET id_produto=@id_produto, nome=@nome, qtde=@qtde, preco=@preco, descricao=@descricao WHERE id_produto=@id_produto;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_produto", this.ID));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@qtde", this.QTDE));
                cmd.Parameters.Add(new NpgsqlParameter("@preco", this.Preco));
                cmd.Parameters.Add(new NpgsqlParameter("@descricao", this.Desc));

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("   Erro!   " + ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}
