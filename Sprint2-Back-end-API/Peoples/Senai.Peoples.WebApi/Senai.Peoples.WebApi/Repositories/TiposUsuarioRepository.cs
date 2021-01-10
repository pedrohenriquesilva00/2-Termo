using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class TiposUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// string de conexão com o Banco de Dados que recebe os parâmetros
        /// Data Source - Banco de dados
        /// initial catolog - Nome do Bando de Dados
        /// user id - Login do Bando de dados
        /// pwd - Senha do Bando de Dados
        /// </summary>
        private string stringConexao = "Data Source=DESKTOP-BEVTDEI\\TSQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@123";
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipos = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario";

                //Abre a conexão com o Banco de Dados
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        tipos.Add(tipo);

                    }
                }

            }
            return tipos;
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TipoUsuario" +
                                       " WHERE IdTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        TipoUsuarioDomain tipo = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                       return tipo;

                    }
                    return null;
                }
            }
        }

        public void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE TipoUsuario " +
                                     "SET Titulo = @Titulo" +
                                     "WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", tipoUsuarioAtualizado.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
