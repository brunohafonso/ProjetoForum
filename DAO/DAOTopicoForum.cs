using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projetoForum.Models;

namespace projetoForum.DAO {

    public class DAOTopicoForum {

        string sqlCon = @"Data source=.\SqlExpress;Initial Catalog=forum;User id=sa;Password=senai@123;";
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public List<TopicoForum> Listar () {
            List<TopicoForum> topicos = new List<TopicoForum> ();
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "SELECT * FROM TopicosForum";
                cn.Open ();
                cmd = new SqlCommand (sqlQuery, cn);
                sdr = cmd.ExecuteReader ();
                while (sdr.Read ()) {
                    TopicoForum topico = new TopicoForum (Convert.ToInt32 (sdr["Id"]), sdr["Titulo"].ToString (), sdr["Descricao"].ToString (), DateTime.Parse (sdr["DataCadastro"].ToString ()));
                    topicos.Add (topico);
                }
            } catch (SqlException ex) {
                throw new Exception ("Erro ao ler dados " + ex.Message);
            } catch(SystemException e) {
                throw new Exception ("Erro inesperado do sistema " + e.Message);
            } finally {
                cn.Close ();
            }

            return topicos;
        }

        public bool Cadastrar (TopicoForum topico) {
            bool result = false;
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "INSERT INTO TopicosForum(Titulo,Descricao,DataCadastro)VALUES(@t,@de,@da)";
                cn.Open ();
                cmd = new SqlCommand (sqlQuery, cn);
                cmd.Parameters.AddWithValue ("@t", topico.Titulo);
                cmd.Parameters.AddWithValue ("@de", topico.Descricao);
                cmd.Parameters.AddWithValue ("@da", DateTime.Now);
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

        public bool Editar (TopicoForum topico) {
            bool result = false;
            try {
                cn = new SqlConnection (sqlCon);
                string sqlQuery = "UPDATE TopicosForum SET Titulo = @t, Descricao = @de, DataCadastro = @da WHERE Id = @i";
                cn.Open ();
                cmd = new SqlCommand (sqlQuery, cn);
                cmd.Parameters.AddWithValue ("@t", topico.Titulo);
                cmd.Parameters.AddWithValue ("@de", topico.Descricao);
                cmd.Parameters.AddWithValue("@da", DateTime.Now);
                cmd.Parameters.AddWithValue ("@i", topico.Id);
                int r = cmd.ExecuteNonQuery ();
                if (r > 0) {
                    result = true;
                } else {
                    result = false;
                }

                cmd.Parameters.Clear ();
            } catch (SqlException ex) {
                throw new Exception ("Erro ao editar dados " + ex.Message);
            } catch(SystemException e) {
                throw new Exception ("Erro inesperado do sistema " + e.Message);
            } finally {
                cn.Close ();
            }

            return result;
        }

        public bool Deletar (int Id) {
            bool result = false;
            try {
                cn = new SqlConnection(sqlCon);
                string sqlQuery = "DELETE FROM TopicosForum WHERE Id = @i";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.AddWithValue("@i", Id);
                int r = cmd.ExecuteNonQuery();
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