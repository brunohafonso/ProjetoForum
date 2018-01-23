using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projetoForum.Models;

namespace projetoForum.DAO {

    public class DAOPostagem {

        string sqlCon = @"Data source=.\SqlExpress;Initial Catalog=forum;User id=sa;Password=senai@123;";

        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public List<Postagem> Listar () {
            List<Postagem> postagens = new List<Postagem> ();
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "SELECT * FROM Postagens";
                cn.Open ();
                cmd = new SqlCommand (sqlQuery, cn);
                sdr = cmd.ExecuteReader ();
                while (sdr.Read ()) {
                    Postagem postagem = new Postagem (Convert.ToInt32 (sdr["Id"]), Convert.ToInt32 (sdr["IdTopico"]), Convert.ToInt32 (sdr["IdUsuario"]), sdr["Mensagem"].ToString (), DateTime.Parse (sdr["DataPublicacao"].ToString ()));
                    postagens.Add (postagem);
                }
            } catch (SqlException ex) {
                throw new Exception ("Erro ao ler banco de dados " + ex.Message);
            } catch (SystemException e) {
                throw new Exception ("Erro inesperado do sistema " + e.Message);
            } finally {
                cn.Close ();
            }

            return postagens;
        }

        public bool Cadastrar (Postagem postagem) {
            
            bool result = false;
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "INSERT INTO Postagens(IdTopico,IdUsuario,Mensagem,DataPublicacao)VALUES(@t,@u,@m,@d)";
                cn.Open ();
                cmd = new SqlCommand (sqlQuery, cn);
                cmd.Parameters.AddWithValue ("@t", postagem.IdTopico);
                cmd.Parameters.AddWithValue ("@u", postagem.IdUsuario);
                cmd.Parameters.AddWithValue ("@m", postagem.Mensagem);
                cmd.Parameters.AddWithValue ("@d", DateTime.Now);
                int r = cmd.ExecuteNonQuery ();
                if (r > 0) {
                    result = true;
                } else {
                    result = false;
                }

                cmd.Parameters.Clear ();
            } catch (SqlException ex) {
                throw new Exception ("Erro ao cadastrar dados " + ex.Message);
            } catch (SystemException e) {
                throw new Exception ("Erro inesperado do sistema " + e.Message);
            } finally {
                cn.Close ();
            }

            return result;
        }

        public bool Editar (Postagem postagem) {
            bool result = false;
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "UPDATE postagens SET IdTopico = @t, IdUsuario = @u, Mensagem = @m, DataPublicacao = @da WHERE Id = @i";
                cn.Open();
                cmd = new SqlCommand (sqlQuery, cn);
                cmd.Parameters.AddWithValue ("@t", postagem.IdTopico);
                cmd.Parameters.AddWithValue ("@u", postagem.IdUsuario);
                cmd.Parameters.AddWithValue ("@m", postagem.Mensagem);
                cmd.Parameters.AddWithValue("@da", DateTime.Now);
                cmd.Parameters.AddWithValue ("@i", postagem.Id);
                int r = cmd.ExecuteNonQuery ();
                if (r > 0) {
                    result = true;
                } else {
                    result = false;
                }

                cmd.Parameters.Clear ();

            } catch (SqlException ex) {
                throw new Exception ("Erro ao atualizar dados " + ex.Message);
            } catch (SystemException e) {
                throw new Exception ("Erro inesperad do sistema " + e.Message);
            } finally {
                cn.Close ();
            }

            return result;
        }

        public bool Deletar (int Id) {
            bool result = false;
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "DELETE FROM Postagens WHERE Id = @i";
                cn.Open();
                cmd = new SqlCommand (sqlQuery, cn);
                cmd.Parameters.AddWithValue ("@i", Id);
                int r = cmd.ExecuteNonQuery ();
                
                if (r > 0) {
                    result = true;
                } else {
                    result = false;
                }

                cmd.Parameters.Clear();
            } catch(SqlException ex) {
                throw new Exception("Erro ao deletar dados " + ex.Message);
            } catch(SystemException e) {
                throw new Exception("Erro inesperado do sistema " + e.Message);
            } finally {
                cn.Close();
            }

            return result;
        }
    }
}