using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using projetoForum.Models;

namespace projetoForum.DAO
{
    public class DAOUsuario
    {
        string sqlCon = @"Data source=.\SqlExpress;Initial Catalog=forum;User id=sa;Password=senai@123;";
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                cn = new SqlConnection(sqlCon);
                string sqlQuery = "SELECT * FROM Usuarios";
                cmd = new SqlCommand(sqlQuery, cn);
                cn.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Usuario usuario = new Usuario(Convert.ToInt32(sdr["Id"]), sdr["Nome"].ToString(), sdr["Login"].ToString(), sdr["Senha"].ToString(), DateTime.Parse(sdr["DataCadastro"].ToString()));
                    usuarios.Add(usuario);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar dados do banco " + ex.Message);
            }
            catch (SystemException e)
            {
                throw new Exception("Erro inesperado do sistema " + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return usuarios;
        }

        public bool Cadastrar(Usuario usuario)
        {
            bool result = false;
            try
            {
                cn = new SqlConnection(sqlCon);
                string sqlQuery = "INSERT INTO Usuarios (Nome,Login,Senha,DataCadastro) VALUES (@n,@l,@s,@d)";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
                cmd.Parameters.AddWithValue("@d", DateTime.Now);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao cadastrar dados " + ex.Message);
            }
            catch (SystemException e)
            {
                throw new Exception("Erro insperado do sistema" + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return result;
        }

        public bool Editar(Usuario usuario)
        {
            bool result = false;
            try
            {
                cn = new SqlConnection(sqlCon);
                string sqlQuery = "UPDATE Usuarios SET Nome = @n, Login = @l, Senha = @s, DataCadastro = @d WHERE id = @i";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
                cmd.Parameters.AddWithValue("@d", DateTime.Now);
                cmd.Parameters.AddWithValue("@i", usuario.Id);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao atualizar dados " + ex.Message);
            }
            catch (SystemException e)
            {
                throw new Exception("Erro insperado do sistema " + e.Message);
            }
            finally
            {
                cn.Close();
            }

            return result;
        }

        public bool Deletar(int Id)
        {
            bool result = false;
            try
            {
                cn = new SqlConnection(sqlCon);
                string sqlQuery = "DELETE FROM Usuarios WHERE Id = @i";
                cn.Open();
                cmd = new SqlCommand(sqlQuery, cn);
                cmd.Parameters.AddWithValue("@i", Id);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                cmd.Parameters.Clear();
            }
            catch(SqlException ex)
            {
                throw new Exception("Erro ao deletar dados " + ex.Message);
            }
            catch(SystemException e)
            {
                throw new Exception("Erro inesperado do sitema " + e.Message);
            }
            finally
            {
                cn.Close();
            }
            
            return result;
        }
    }
}