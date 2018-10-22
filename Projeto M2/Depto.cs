using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Projeto_M2
{
    class Depto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Evento { get; set; }
        public int Freq { get; set; }

        public Depto()
        { }

        public Depto(int id, string nome, string evento, int freq)
        {
            this.ID = id;
            this.Nome = nome;
            this.Evento = evento;
            this.Freq = freq;
        }

        public void Cadastrar()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "INSERT INTO departamentos (id_depto, nome, evento, frequencia) VALUES (@id_depto, @nome, @evento, @frequencia)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_depto", this.ID));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@evento", this.Evento));
                cmd.Parameters.Add(new NpgsqlParameter("@frequencia", this.Freq));
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

        public List<Depto> Listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new ConectaDB().getConexao();
                string sql = "SELECT * FROM departamentos";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Depto> listaDepto = new List<Depto>();
                while (dr.Read())
                {
                    Depto novoDepto = new Depto();
                    novoDepto.ID = Convert.ToInt16(dr["id_depto"]);
                    novoDepto.Nome = dr["Nome"].ToString();
                    novoDepto.Evento = dr["Evento"].ToString();
                    novoDepto.Freq = Convert.ToInt16(dr["Frequencia"]);

                    listaDepto.Add(novoDepto);
                }
                return listaDepto;
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

        public void excluir()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "delete from departamentos where id_depto=@id_depto;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_depto", ID));

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

                string sql = "UPDATE departamentos SET id_depto=@id_depto, nome=@nome, evento=@evento, frequencia=@frequencia WHERE id_depto=@id_depto;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add(new NpgsqlParameter("@id_depto", this.ID));
                cmd.Parameters.Add(new NpgsqlParameter("@nome", this.Nome));
                cmd.Parameters.Add(new NpgsqlParameter("@evento", this.Evento));
                cmd.Parameters.Add(new NpgsqlParameter("@frequencia", this.Freq));

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
