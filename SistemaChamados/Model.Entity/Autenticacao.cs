namespace Model.Entity
{
    //Classe Singleton
    public class Autenticacao
    {
        //Construtor privado
        private Autenticacao() { }

        //Atributo que instacia a classe 
        private static Autenticacao instancia;

        //Propriedades da classe
        public int Matricula { get; set; }
        public string Cargo { get; set; }
        
        public static Autenticacao Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Autenticacao();
                }
                return instancia;
            }
        }
    }
}
