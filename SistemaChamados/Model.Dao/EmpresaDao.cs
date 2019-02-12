using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class EmpresaDao : ICrud<Empresa> //Realiza uma interface que recebe a classe empresa
    {
        //Objetos de conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public EmpresaDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }
        public void alterar(Empresa objEmpresa)
        {
            //Comando SQL para atualizar dados na tabela empresa            
            string update = "UPDATE empresa SET cnpj='" + objEmpresa.Cnpj + "', nome_fantasia='"+ objEmpresa.NomeFantasia+"', razao_social='"+ objEmpresa.RazaoSocial+"', telefone='"+objEmpresa.Telefone+"', logradouro='"+objEmpresa.Logradouro+"', complemento='"+objEmpresa.Complemento+"', cidade='"+objEmpresa.Cidade+"', uf='"+objEmpresa.Uf + "' where cod_empresa='" + objEmpresa.CodEmpresa + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objEmpresa.EstadoCon = 1;  //Erro ao tentar inserir

            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }
    

        public bool buscar(Empresa objEmpresa)
        {
            bool temRegistros;
            // Comando SQL para buscar dados na tabela empresa
            string find = "SELECT * FROM empresa WHERE cod_empresa = '"+objEmpresa.CodEmpresa+"';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objEmpresa.Cnpj = reader[1].ToString();
                    objEmpresa.NomeFantasia = reader[2].ToString();
                    objEmpresa.RazaoSocial = reader[3].ToString();
                    objEmpresa.Telefone = reader[4].ToString();
                    objEmpresa.Logradouro = reader[5].ToString();
                    objEmpresa.Complemento = reader[6].ToString();
                    objEmpresa.Cidade = reader[7].ToString();
                    objEmpresa.Uf = reader[8].ToString();
                    objEmpresa.EstadoCon = 99; //Registro foi encontrado
                }
                else
                {
                    objEmpresa.EstadoCon = 1; //Não foi encontrado nenhum registro
                }
            }
            catch (Exception)
            {
                objEmpresa.EstadoCon = 1;
                temRegistros = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
                
            }
            return temRegistros;
        }

        public List<Empresa> buscarTudo()
        {
            List<Empresa> listaEmpresas = new List<Empresa>();
                        
            // Comando SQL para buscar dados na tabela empresa
            string findAll = "SELECT * FROM empresa ORDER BY nome_fantasia ASC";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.CodEmpresa = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    empresa.Cnpj = reader[1].ToString();
                    empresa.NomeFantasia = reader[2].ToString();
                    empresa.RazaoSocial = reader[3].ToString();
                    empresa.Telefone = reader[4].ToString();
                    empresa.Logradouro = reader[5].ToString();
                    empresa.Complemento = reader[6].ToString();
                    empresa.Cidade = reader[7].ToString();
                    empresa.Uf = reader[8].ToString();
                    //Adicionando o objeto de empresa à lista
                    listaEmpresas.Add(empresa);
                }
            }
            catch (Exception)
            {
                objConexaoDB.closeDB();
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();

            }
            return listaEmpresas;
        }

        public void cadastrar(Empresa objEmpresa)
        {
            //Comando SQL para inserir dados na tabela empresa
            string create = "INSERT INTO empresa(cnpj, nome_fantasia, razao_social, telefone, logradouro, complemento, cidade, uf) VALUES('" + objEmpresa.Cnpj + "', '" + objEmpresa.NomeFantasia + "', '" + objEmpresa.RazaoSocial + "', '" + objEmpresa.Telefone + "', '" + objEmpresa.Logradouro + "','" + objEmpresa.Complemento + "','" + objEmpresa.Cidade + "', '" + objEmpresa.Uf + "');";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objEmpresa.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public void excluir(Empresa objEmpresa)
        {
            //Comando SQL para excluir dados na tabela empresa            
            string delete = "DELETE FROM empresa WHERE cod_empresa = '" + objEmpresa.CodEmpresa + "';";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();

            }
            catch (Exception)
            {
                objEmpresa.EstadoCon = 1;  //Erro ao tentar inserir

            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        //Busca empresa por CNPJ
        public bool buscarEmpresaPorCnpj(Empresa objEmpresa)
        {
            bool temRegistros = false;
            string find = "select * from empresa where cnpj='" + objEmpresa.Cnpj + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();

                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objEmpresa.Cnpj = reader[1].ToString();
                    objEmpresa.NomeFantasia = reader[2].ToString();
                    objEmpresa.RazaoSocial = reader[3].ToString();
                    objEmpresa.Telefone = reader[4].ToString();
                    objEmpresa.Logradouro = reader[5].ToString();
                    objEmpresa.Complemento = reader[6].ToString();
                    objEmpresa.Cidade = reader[7].ToString();
                    objEmpresa.Uf = reader[8].ToString();
                    objEmpresa.EstadoCon = 99;

                }
                else
                {
                    temRegistros = false;
                    objEmpresa.EstadoCon = 1;
                }
            }
            catch (Exception)
            {
                objEmpresa.EstadoCon = 1;
                temRegistros = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }
            return temRegistros;
        }

        //Busca dados da empresa por CNPJ ou nome fantasia
        public List<Empresa> buscarTudoEmpresa(Empresa objEmpresa)
        {
            List<Empresa> listaEmpresas = new List<Empresa>();
            string findAll = "select * from empresa where nome_fantasia like '%" + objEmpresa.NomeFantasia + "%' or cnpj like '%" + objEmpresa.Cnpj + "%'";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Empresa empresa = new Empresa();
                    empresa.CodEmpresa = Convert.ToInt32(reader[0].ToString());
                    empresa.Cnpj = reader[1].ToString();
                    empresa.NomeFantasia = reader[2].ToString();                    
                    empresa.RazaoSocial = reader[3].ToString();
                    empresa.Telefone = reader[4].ToString();
                    empresa.Logradouro = reader[5].ToString();
                    empresa.Complemento = reader[6].ToString();
                    empresa.Cidade = reader[7].ToString();
                    empresa.Uf = reader[8].ToString();
                    //Adicionando na lista 
                    listaEmpresas.Add(empresa);

                }
            }
            catch (Exception)
            {
                Empresa empresa = new Empresa();
                empresa.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.closeDB();
            }

            return listaEmpresas;

        }

        public string buscarNomeEmpresa(int cod)
        {
            Empresa empresa = new Empresa();

            // Comando SQL para buscar dados na tabela empresa
            string findAll = "SELECT nome_fantasia FROM empresa WHERE cod_empresa = "+ cod;
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {  
                    empresa.NomeFantasia = reader[0].ToString();          
                }
            }
            catch (Exception)
            {
                objConexaoDB.closeDB();
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();

            }
            return empresa.NomeFantasia;
        }

        public Empresa buscarEmpresaPorCod(int cod)
        {
            Empresa empresa = new Empresa();

            // Comando SQL para buscar dados na tabela empresa
            string findAll = "SELECT * FROM empresa WHERE cod_empresa =" + cod +";";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {                    
                    empresa.CodEmpresa = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    empresa.Cnpj = reader[1].ToString();
                    empresa.NomeFantasia = reader[2].ToString();                                     
                }
            }
            catch (Exception)
            {
                objConexaoDB.closeDB();
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();

            }
            return empresa;
        }
    }
}
