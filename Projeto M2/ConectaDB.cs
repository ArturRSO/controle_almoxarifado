using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Projeto_M2
{
    class ConectaDB
    {
        private string serverName = "localhost";
        private string port = "5432";
        private string userName = "postgres";
        private string password = "postgres";
        private string dataBaseName = "db_m2";

        public NpgsqlConnection getConexao()
        {
            try
            {
                string stgConexao = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4}", serverName, port, userName, password, dataBaseName);

                NpgsqlConnection conexao = new NpgsqlConnection(stgConexao);

                conexao.Open();
                return conexao;
            }
            catch (Exception e)
            {
                throw new Exception("   Erro!   " + e.Message);
            }
        }
    }
}


