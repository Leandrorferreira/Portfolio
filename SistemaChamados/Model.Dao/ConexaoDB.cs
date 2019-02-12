using System.Data.SqlClient;

namespace Model.Dao
{
    class ConexaoDB
    {
        //Variavel para receber a classe de conexao 
        private static ConexaoDB objConexaoDB = null;

        //Variavel que carrega a conexao com o banco
        private SqlConnection con;

        //Construtor
        private ConexaoDB()
        {
            //Passando o LOCAL, NOME DO BANCO e SEGURANÇA 
            con = new SqlConnection("Data Source=SistemaChamados.mssql.somee.com;packet size=4096;user id=LeandroRFerreira_SQLLogin_1;pwd=o4n1jvmvhk;data source=SistemaChamados.mssql.somee.com;persist security info=False;initial catalog=SistemaChamados");
            //con = new SqlConnection(@"Data Source=DESKTOP-M5LH3FL\SQLEXPRESS;Initial Catalog=SistemaChamados;Integrated Security=True");
        }

        //Metodo publico para saber o estado da conexão
        public static ConexaoDB saberEstado()
        {

            //Se ainda não houver conexão com banco
            if (objConexaoDB == null)
            {
                //Cria uma nova conexão chamando o construtor da classe
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;

        }

        //Captura a conexão
        public SqlConnection getCon()
        {
            return con;
        }

        //Metodo para fechar conexao com o banco
        public void closeDB()
        {
            objConexaoDB = null;
        }
    }
}
