namespace Model.Entity
{
    public class Login
    {
        //Atributos
        private int matricula; //Atributo que recebe a matricula do Gerente/Atendente cadastrado
        private string email;
        private string senha;
        private string cargo; //Atributo para saber se é Gerente ou Atendente
        private int estadoCon;
                
        public int Matricula { get => matricula; set => matricula = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }
    }
}