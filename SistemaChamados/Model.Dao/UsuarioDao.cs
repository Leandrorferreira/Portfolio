using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class UsuarioDao : ICrud<Usuario> //Realiza uma interface que recebe a classe usuario
    {
        //Variáveis para conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;
        private SqlDataReader reader;

        //Metodo Construtor
        public UsuarioDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void cadastrar(Usuario objUsuario)
        {
            string create = "INSERT INTO usuario VALUES('" + objUsuario.Nome + "','" + objUsuario.Cpf + "','" + objUsuario.Ramal + "', '"+ objUsuario.CodEmpresa+ "')";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
        }

        public void excluir(Usuario objUsuario)
        {
            string delete = "delete from usuario where mat_usuario='" + objUsuario.Matricula + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
        }

        public bool buscar(Usuario objUsuario)
        {
            bool temRegistros;
            string find = "select * from usuario where mat_usuario='" + objUsuario.Matricula + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.Ramal = reader[3].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[4]);  
                    objUsuario.EstadoCon = 99;
                }
                else
                {
                    objUsuario.EstadoCon = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return temRegistros;
        }

        public bool buscarCpf(Usuario objUsuario)
        {
            bool temRegistros;
            string find = "select * from usuario where cpf_usuario='" + objUsuario.Cpf + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.Ramal = reader[3].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[4]);
                    objUsuario.EstadoCon = 99;
                }
                else
                {
                    objUsuario.EstadoCon = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return temRegistros;
        }

        public List<Usuario> buscarTudo()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string find = "select * from usuario order by nome_usuario asc";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Matricula = Convert.ToInt32(reader[0]);
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.Ramal = reader[3].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[4]);
                    listaUsuarios.Add(objUsuario);
                }

            }
            catch (Exception)
            {
                Usuario objUsuario2 = new Usuario();
                objUsuario2.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return listaUsuarios;
        }

        public void alterar(Usuario objUsuario)
        {
            string update = "update usuario set  nome_usuario='" + objUsuario.Nome + "',cpf_usuario='" + objUsuario.Cpf + "',ramal_usuario='" + objUsuario.Ramal + "', cod_empresa='"+objUsuario.CodEmpresa+"' where mat_usuario='" + objUsuario.Matricula + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
        }

        public bool findUsuarioPorEmpresa(Usuario objUsuario)
        {
            bool temRegistros = false;
            string find = "select * from usuario where cod_empresa='" + objUsuario.CodEmpresa + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objUsuario.EstadoCon = 99;
                }
                else
                {
                    objUsuario.EstadoCon = 1;
                }
            }
            catch (Exception)
            {
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return temRegistros;
        }

        public List<Usuario> findAllUsuarios(Usuario objUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            string findAll = "select * from usuario where nome_usuario like '%" + objUsuario.Nome + "%' or cpf_usuario like '%" + objUsuario.Cpf + "%' or cod_empresa like '%" + objUsuario.CodEmpresa + "%'";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario objUsuarios = new Usuario();
                    objUsuarios.Matricula = Convert.ToInt32(reader[0]);
                    objUsuarios.Nome = reader[1].ToString();
                    objUsuarios.Cpf = reader[2].ToString();
                    objUsuarios.Ramal = reader[3].ToString();
                    objUsuarios.CodEmpresa = Convert.ToInt32(reader[4]);
                    listaUsuarios.Add(objUsuarios);

                }
            }
            catch (Exception)
            {

                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return listaUsuarios;

        }

        public List<Usuario> findAllUsuariosPorEmpresa(Usuario objUsuario)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            string findAll = "select * from usuario where cod_empresa='" + objUsuario.CodEmpresa + "'";
            
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario objUsuarios = new Usuario();
                    objUsuario.Matricula = Convert.ToInt32(reader[0].ToString());
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[3].ToString());

                    listaUsuarios.Add(objUsuarios);
                }
            }
            catch (Exception)
            {
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return listaUsuarios;

        }

        public List<Usuario> findUsuarioPorCpf(Usuario objUsuario)
        {
            List<Usuario> lista = new List<Usuario>();
            string find = "select * from usuario where cpf_usuario='" + objUsuario.Cpf + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Usuario objUsuarios = new Usuario();
                    objUsuarios.Matricula = Convert.ToInt32(reader[0].ToString());
                    objUsuarios.Nome = reader[1].ToString();
                    objUsuarios.Cpf = reader[2].ToString();
                    objUsuarios.Ramal = reader[3].ToString();
                    objUsuarios.CodEmpresa = Convert.ToInt32(reader[4].ToString());
                    lista.Add(objUsuarios);
                }

            }
            catch (Exception)
            {
                Usuario objUsuario2 = new Usuario();
                objUsuario2.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return lista;
        }

        //Busca um usuário com base em um numero de CPF
        public Usuario findUsuarioCpf(string cpf)
        {
            Usuario objUsuario = new Usuario();
            string find = "select * from usuario where cpf_usuario='" + cpf + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objUsuario.Matricula = Convert.ToInt32(reader[0].ToString());
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.Ramal = reader[3].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[4].ToString());
                }

            }
            catch (Exception)
            {                
                objUsuario.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return objUsuario;
        }

        public Usuario buscarPorMatricula(int matricula)
        {
            Usuario objUsuario = new Usuario();
            string find = "select * from usuario where mat_usuario="+matricula+";";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objUsuario.Matricula = Convert.ToInt32(reader[0].ToString());
                    objUsuario.Nome = reader[1].ToString();
                    objUsuario.Cpf = reader[2].ToString();
                    objUsuario.Ramal = reader[3].ToString();
                    objUsuario.CodEmpresa = Convert.ToInt32(reader[4].ToString());
                }

            }
            catch (Exception)
            {
                Usuario objUsuario2 = new Usuario();
                objUsuario2.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return objUsuario;
        }
              
        //Verifica se empresa possui funcionários cadastrados
        public bool buscarEmpresaUsuario(int codigo)
        {
            bool temEmpresa;
            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT * FROM usuario WHERE cod_empresa = '" + codigo + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temEmpresa = true;
                }
                else
                {
                    temEmpresa = false;
                }
            }
            catch (Exception)
            {
                temEmpresa = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
            return temEmpresa;
        }
    
}
}
