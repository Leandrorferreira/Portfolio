using Model.Entity;
using System;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class LoginDao
    {
        //Objetos de conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando = null;

        public LoginDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        //Alterar o login com base no id e no cargo
        public void alterar(Login objLogin)
        {
            //Comando SQL para atualizar dados na tabela empresa            
            string update = "UPDATE login SET senha='" + objLogin.Senha + "' WHERE matricula ='" + objLogin.Matricula + "' AND cargo='"+objLogin.Cargo+"'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        //Buscar a Matricula e Cargo com base no Email
        public Login buscarMatriculaCargo(string email)
        {
            Login objLogin = new Login();
            string find = "select * from login where email=" + email + ";";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {                    
                    objLogin.Email = reader[1].ToString();
                    objLogin.Senha = reader[2].ToString();
                    objLogin.Cargo = reader[3].ToString();
                    objLogin.Matricula = Convert.ToInt32(reader[4].ToString());
                }
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return objLogin;
        }

        public void excluir(int matricula, string cargo)
        {
            Login objLogin = new Login();
            //Comando SQL para excluir login          
            string delete = "DELETE FROM login WHERE cargo = '" + cargo + "' AND matricula = '"+ matricula +"';";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public void cadastrar(Login objLogin)
        {
            //Comando SQL para inserir dados na tabela empresa
            string create = "INSERT INTO login(email, senha, cargo, matricula) VALUES('" + objLogin.Email + "', '" + objLogin.Senha + "', '" + objLogin.Cargo + "', '"+objLogin.Matricula+"');";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public Login logar(string email, string senha)
        {
            Login objLogin = new Login();
            bool temRegistros;
            // Comando SQL para buscar o email e senha informados
            string find = "SELECT * FROM login WHERE email = '" + email + "' AND senha ='"+senha+"';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objLogin.Email = reader[1].ToString();
                    objLogin.Senha = reader[2].ToString();
                    objLogin.Cargo = reader[3].ToString();
                    objLogin.Matricula = Convert.ToInt32(reader[4]);
                }
                else
                {
                    objLogin.EstadoCon = 1; //Email e Senha não encontrados
                }
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1000; //Erro ao tentar encontrar email e senha
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }

            return objLogin;
        }

        //Verifica se já possúi um email cadastrado igual ao que foi informado
        public bool verificaDuplicidade(string email)
        {
            bool temRegistros;
            // Comando SQL para buscar o email e senha informados
            string find = "SELECT * FROM login WHERE email = '" + email + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }

            return temRegistros;
        }

        //Buscar o email e senha do usuario logado
        public Login buscarDadosLogin(int matricula, string cargo)
        {
            Login objLogin = new Login();
            string find = "select * from login where matricula=" + matricula + " and cargo = '"+cargo+"';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objLogin.Email = reader[1].ToString();
                    objLogin.Senha = reader[2].ToString();
                    objLogin.Cargo = reader[3].ToString();
                    objLogin.Matricula = Convert.ToInt32(reader[4].ToString());
                }
            }
            catch (Exception)
            {
                objLogin.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return objLogin;
        }
    }
}
