using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ChamadoDao
    {
        //Objetos de conexão com banco de dados
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        //Metodo construtor
        public ChamadoDao()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public bool buscarPorProtocolo(Chamado objChamado)
        {
            bool temRegistros;
            string find = "SELECT * FROM chamado WHERE protocolo = '" + objChamado.Protocolo + "';";
            try
            {                
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DescChamado = reader[3].ToString();
                    objChamado.Estatus = reader[5].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[6]);
                    objChamado.Atendente = Convert.ToInt32(reader[7]);
                    objChamado.EstadoCon = 99; //Registro foi encontrado
                }
            }
            catch (Exception)
            {
                objChamado.EstadoCon = 1;
                temRegistros = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
            return temRegistros;
        }

        public bool buscarFinalizadoPorProtocolo(Chamado objChamado)
        {
            bool temRegistros;
            string find = "SELECT * FROM chamado WHERE protocolo = '" + objChamado.Protocolo + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();

                if (temRegistros)
                {
                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DataFinalizacao = Convert.ToDateTime(reader[2]);
                    objChamado.DescChamado = reader[3].ToString();
                    objChamado.DescSolucao = reader[4].ToString();
                    objChamado.Estatus = reader[5].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[6]);
                    objChamado.Atendente = Convert.ToInt32(reader[7]);
                    objChamado.EstadoCon = 99; //Registro foi encontrado
                }
            }
            catch (Exception)
            {
                objChamado.EstadoCon = 1;
                temRegistros = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
            return temRegistros;
        }

        public List<Chamado> buscarChamadosAbertos()
        {
            List<Chamado> listaChamados = new List<Chamado>();

            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT protocolo, data_abertura, desc_chamado, estatus, mat_usuario, mat_analista FROM chamado WHERE estatus = 'Aberto';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    //Criando um novo objeto de chamado
                    Chamado objChamado = new Chamado();
                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DescChamado = reader[2].ToString();
                    objChamado.Estatus = reader[3].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[4]);
                    objChamado.Atendente = Convert.ToInt32(reader[5]);
                    //Adicionando o objeto de empresa à lista
                    listaChamados.Add(objChamado);
                }
            }
            catch (Exception)
            {
                Chamado objChamado = new Chamado();
                objChamado.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();

            }
            return listaChamados;
        }

        public List<Chamado> chamadosAbertosAtendente(int matricula)
        {
            List<Chamado> listaChamados = new List<Chamado>();

            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT protocolo, data_abertura, desc_chamado, estatus, mat_usuario, mat_analista FROM chamado WHERE estatus = 'Aberto' AND mat_analista=" + matricula + ";";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    //Criando um novo objeto de chamado
                    Chamado objChamado = new Chamado();
                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DescChamado = reader[2].ToString();
                    objChamado.Estatus = reader[3].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[4]);
                    objChamado.Atendente = Convert.ToInt32(reader[5]);
                    //Adicionando o objeto de empresa à lista
                    listaChamados.Add(objChamado);
                }
            }
            catch (Exception)
            {
                Chamado objChamado = new Chamado();
                objChamado.EstadoCon = 1000;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();

            }
            return listaChamados;
        }

        //Mostrar uma lista de chamados finalizados
        public List<Chamado> buscarChamadosFinalizados()
        {
            List<Chamado> listaChamados = new List<Chamado>();
            //Criando um novo objeto de chamado
            Chamado objChamado = new Chamado();
            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT * FROM chamado WHERE estatus = 'Fechado';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DataFinalizacao = Convert.ToDateTime(reader[2]);
                    objChamado.DescChamado = reader[3].ToString();
                    objChamado.DescSolucao = reader[4].ToString();
                    objChamado.Estatus = reader[5].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[6]);
                    objChamado.Atendente = Convert.ToInt32(reader[7]);
                    //Adicionando o objeto de empresa à lista
                    listaChamados.Add(objChamado);
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
            return listaChamados;
        }

        public void abrirChamado(Chamado objChamado)
        {
            //Comando SQL para inserir dados na tabela empresa
            string create = "INSERT INTO chamado(data_abertura, desc_chamado, estatus, mat_usuario, mat_analista) VALUES('" + objChamado.DataAbertura + "', '" + objChamado.DescChamado + "', '" + objChamado.Estatus + "', '" + objChamado.Cliente + "', '" + objChamado.Atendente + "');";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objChamado.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public void finalizarChamado(Chamado objChamado)
        {
            //Comando SQL para atualizar dados na tabela de chamado            
            string update = "UPDATE chamado SET desc_solucao='" + objChamado.DescSolucao + "', estatus='" + objChamado.Estatus + "', data_finalizacao ='" + objChamado.DataFinalizacao + "' WHERE protocolo =" + objChamado.Protocolo + "";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objChamado.EstadoCon = 1;  //Erro ao tentar inserir
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        public List<Chamado> chamadosFinalizadosAtendente(int matricula)
        {
            List<Chamado> listaChamados = new List<Chamado>();

            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT protocolo, data_abertura, desc_chamado, estatus, mat_usuario, mat_analista FROM chamado WHERE estatus = 'Fechado' AND mat_analista=" + matricula + ";";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    //Criando um novo objeto de chamado
                    Chamado objChamado = new Chamado();
                    objChamado.Protocolo = Convert.ToInt32(reader[0].ToString()); //Pegando um valor inteiro e convertendo para String
                    objChamado.DataAbertura = Convert.ToDateTime(reader[1]);
                    objChamado.DescChamado = reader[2].ToString();
                    objChamado.Estatus = reader[3].ToString();
                    objChamado.Cliente = Convert.ToInt32(reader[4]);
                    objChamado.Atendente = Convert.ToInt32(reader[5]);
                    //Adicionando o objeto de empresa à lista
                    listaChamados.Add(objChamado);
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
            return listaChamados;
        }

        public void alterar(Chamado objChamado)
        {
            //Comando SQL para atualizar dados na tabela Gerente            
            string update = "UPDATE chamado SET desc_chamado='" + objChamado.DescChamado + "' where protocolo = '" + objChamado.Protocolo + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objChamado.EstadoCon = 1;  //Erro ao tentar inserir

            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
        }

        //Verifica se atendente possui chamados abertos
        public bool buscarChamadosAtendente(int matricula)
        {
            bool temChamados;
            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT * FROM chamado WHERE mat_analista = '" + matricula +"';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temChamados = true;
                }
                else
                {
                    temChamados = false;
                }
            }
            catch (Exception)
            {
                temChamados = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
            return temChamados;
        }

        //Verifica se usuário possui chamados abertos
        public bool buscarChamadosUsuario(int matricula)
        {
            bool temChamados;
            // Comando SQL para buscar dados na tabela de chamado
            string find = "SELECT * FROM chamado WHERE mat_usuario = '" + matricula + "';";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open(); //Abre uma nova conexao
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    temChamados = true;
                }
                else
                {
                    temChamados = false;
                }
            }
            catch (Exception)
            {
                temChamados = false;
            }
            finally
            {
                objConexaoDB.getCon().Close();  //Fecha a conexão
                objConexaoDB.closeDB();
            }
            return temChamados;
        }
    }
}
