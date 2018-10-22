using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Projeto_M2
{
    class Admins
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        public Admins (int id, string nome, string login, string senha)
        {
            this.ID = id;
            this.Nome = Nome;
            this.login = login;
            this.senha = senha;
        }

        public Admins()
        {
          
        }

        public List<Admins> Enter()
        {
            NpgsqlConnection conexao = null;

            try
            {
                conexao = new ConectaDB().getConexao();

                string sql = "SELECT * from Admins";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                List<Admins> listaAdmins = new List<Admins>();
                while (dr.Read())
                {
                    Admins novoAdmin = new Admins();
                    novoAdmin.ID = Convert.ToInt16(dr["id"]);
                    novoAdmin.login = dr["Nome"].ToString();
                    novoAdmin.login = dr["login"].ToString();
                    novoAdmin.senha = dr["senha"].ToString();

                    listaAdmins.Add(novoAdmin);
                }

                return listaAdmins;
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
