using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sql
    {
        private readonly SqlConnection _connection;

        public Sql()
        {
            this._connection = new SqlConnection();
        }

        public void InserirDados(ContentEmail dados)
        {
            _connection.Open();
            SqlTransaction sqlTransaction = _connection.BeginTransaction();
            
            try
            {
                string query = @"INSERT INTO Cliente
                             (NOME,REMETENTE,DESTINATARIO,DATAEMAIL,CONTEUDO)
                             VALUES
                             (@NOME,@REMETENTE,@DESTINATARIO,@DATAEMAIL,@CONTEUDO);";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("NOME", dados.NOME);
                    command.Parameters.AddWithValue("REMETENTE", dados.REMETENTE);
                    command.Parameters.AddWithValue("DESTINATARIO", dados.DESTINATARIO);
                    command.Parameters.AddWithValue("DATAEMAIL", dados.DATAEMAIL);
                    command.Parameters.AddWithValue("CONTEUDO", dados.CONTEUDO);
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
