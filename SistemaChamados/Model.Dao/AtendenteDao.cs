using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class AtendenteDao : ICrud<Atendente> //Realiza uma interface que recebe a classe atendente
    {
        //Objetos de conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando = null;
       
        public AtendenteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void alterar(Atendente objAtendente)
        {
            //Comando SQL para atualizar dados na tabela empresa            
            string update = "UPDATE analista SET nome='" + objAtendente.Nome + "', cpf='" + objAtendente.Cpf + "', funcao='" + objAtendente.Funcao +"' where mat_analista ='"+objAtendente.Matricula+"'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objAtendente.EstadoCon = 1;  //Erro ao tentar inserir

            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }


        public bool buscar(Atendente objAtendente)
        {
            bool temRegistros;
            // Comando SQL para buscar dados na tabela empresa
            string find = "SELECT * FROM analista WHERE mat_analista = '" + objAtendente.Matricula + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objAtendente.Matricula = Convert.ToInt32(reader[0]);
                    objAtendente.Nome = reader[1].ToString();
                    objAtendente.Cpf = reader[2].ToString();
                    objAtendente.Funcao = reader[3].ToString();                   
                    objAtendente.EstadoCon = 99; //Registro foi encontrado
                }
                else
                {
                    objAtendente.EstadoCon = 1; //Não foi encontrado nenhum registro
                }
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

        public List<Atendente> buscarTudo()
        {
            List<Atendente> listaAtendente = new List<Atendente>();

            // Comando SQL para buscar dados na tabela analista
            string findAll = "SELECT * FROM analista ORDER BY nome ASC;";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atendente atendente = new Atendente();
                    atendente.Matricula = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    atendente.Nome = reader[1].ToString();
                    atendente.Cpf = reader[2].ToString();
                    atendente.Funcao = reader[3].ToString();
                    
                    //Adicionando o objeto de empresa à lista
                    listaAtendente.Add(atendente);
                }
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
            return listaAtendente;
        }

        public void cadastrar(Atendente objAtendente)
        {
            //Comando SQL para inserir dados na tabela empresa
            string create = "INSERT INTO analista(nome, cpf, funcao) VALUES('" + objAtendente.Nome + "', '" + objAtendente.Cpf + "', '" + objAtendente.Funcao + "');";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objAtendente.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public void excluir(Atendente objAtendente)
        {
            //Comando SQL para excluir dados na tabela atendente            
            string delete = "DELETE FROM analista WHERE mat_analista = '" + objAtendente.Matricula + "';";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objAtendente.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        //Busca atendente por CPF
        public bool buscarAtendentePorCpf(Atendente objAtendente)
        {
            bool temRegistros;
            string find = "select * from analista where cpf='" + objAtendente.Cpf + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objAtendente.Nome = reader[1].ToString();
                    objAtendente.Cpf = reader[2].ToString();
                    objAtendente.Funcao = reader[3].ToString();               
                    objAtendente.EstadoCon = 99;

                }
                else
                {
                    objAtendente.EstadoCon = 1;
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

        //Busca dados do analista por CPF ou nome 
        public List<Atendente> buscarTudoAtendente(Atendente objAtendente)
        {
            List<Atendente> listaAtendentes = new List<Atendente>();
            string findAll = "SELECT * FROM analista WHERE nome like '%" + objAtendente.Nome + "%' or cpf like '%" + objAtendente.Cpf + "%' or funcao like '%" + objAtendente.Funcao + "%' ;";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Atendente atendente = new Atendente();
                    atendente.Matricula = Convert.ToInt32(reader[0].ToString());
                    atendente.Nome = reader[1].ToString();
                    atendente.Cpf = reader[2].ToString();
                    atendente.Funcao = reader[3].ToString();
                    //Adicionando na lista 
                    listaAtendentes.Add(atendente);
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

            return listaAtendentes;
        }

        public Atendente buscarPorMatricula(int matricula)
        {
            Atendente objAtendente = new Atendente();
            string find = "select * from analista where mat_analista=" + matricula + ";";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objAtendente.Matricula = Convert.ToInt32(reader[0].ToString());
                    objAtendente.Nome = reader[1].ToString();
                    objAtendente.Cpf = reader[2].ToString();
                    objAtendente.Funcao = reader[3].ToString();                   
                }
            }
            catch (Exception)
            {               
                objAtendente.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return objAtendente;
        }

        //Busca atendente por CPF e retorna o id
        public int buscarMatriculaPorCpf(string cpf)
        {
            
            int matricula;
            string find = "select mat_analista from analista where cpf='" + cpf + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                
                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0].ToString());
                }
                else
                {
                    matricula = -1;
                }
            }
            catch (Exception)
            {
                matricula = 0;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return matricula;
        }
    }
}
