using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class GerenteDao : ICrud<Gerente> //Realiza uma interface que recebe a classe gerente
    {
        //Objetos de conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public GerenteDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void alterar(Gerente objGerente)
        {
            //Comando SQL para atualizar dados na tabela Gerente            
            string update = "UPDATE gerente SET nome='" + objGerente.Nome + "', cpf='" + objGerente.Cpf +"' where matricula = '" + objGerente.Matricula + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objGerente.EstadoCon = 1;  //Erro ao tentar inserir

            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }
        
        public bool buscar(Gerente objGerente)
        {
            bool temRegistros;
            // Comando SQL para buscar dados na tabela empresa
            string find = "SELECT * FROM gerente WHERE matricula = '" + objGerente.Matricula + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objGerente.Matricula = Convert.ToInt32(reader[0]);
                    objGerente.Nome = reader[1].ToString();
                    objGerente.Cpf = reader[2].ToString();                   
                    objGerente.EstadoCon = 99; //Registro foi encontrado
                }
                else
                {
                    objGerente.EstadoCon = 1; //Não foi encontrado nenhum registro
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

        public List<Gerente> buscarTudo()
        {
            List<Gerente> listaGerente = new List<Gerente>();

            // Comando SQL para buscar dados na tabela analista
            string findAll = "SELECT * FROM gerente ORDER BY nome ASC;";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Gerente gerente = new Gerente();
                    gerente.Matricula = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    gerente.Nome = reader[1].ToString();
                    gerente.Cpf = reader[2].ToString();

                    //Adicionando o objeto de empresa à lista
                    listaGerente.Add(gerente);
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
            return listaGerente;
        }

        public void cadastrar(Gerente objGerente)
        {
            //Comando SQL para inserir dados na tabela empresa
            string create = "INSERT INTO gerente(nome, cpf) VALUES('" + objGerente.Nome + "', '" + objGerente.Cpf +"');";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objGerente.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public void excluir(Gerente objGerente)
        {
            //Comando SQL para excluir dados na tabela atendente            
            string delete = "DELETE FROM gerente WHERE matricula = '" + objGerente.Matricula + "';";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objGerente.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        //Busca gerente por CPF
        public bool buscarGerentePorCpf(Gerente objGerente)
        {
            bool temRegistros;
            string find = "select * from gerente where cpf='" + objGerente.Cpf + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objGerente.Nome = reader[1].ToString();
                    objGerente.Cpf = reader[2].ToString();

                    objGerente.EstadoCon = 99;
                }
                else
                {
                    objGerente.EstadoCon = 1;
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
        public List<Gerente> buscarTudoGerente(Gerente objGerente)
        {
            List<Gerente> listaGerentes = new List<Gerente>();
            string findAll = "SELECT * FROM gerente WHERE nome like '%" + objGerente.Nome + "%' or cpf like '%" + objGerente.Cpf + "' ;";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Gerente gerente = new Gerente();
                    gerente.Matricula = Convert.ToInt32(reader[0].ToString());
                    gerente.Nome = reader[1].ToString();
                    gerente.Cpf = reader[2].ToString();

                    //Adicionando na lista 
                    listaGerentes.Add(gerente);
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

            return listaGerentes;
        }

        //Busca gerente por CPF e retorna o id
        public int buscarMatriculaPorCpf(string cpf)
        {
            bool temRegistros;
            int matricula;
            string find = "select matricula from gerente where cpf='" + cpf + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
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
                throw;
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
