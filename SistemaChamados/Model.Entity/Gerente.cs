using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Gerente
    {
        //Declaração dos Atributos (variáveis de instância)
        private int matricula;
        private string nome;
        private string cpf;
        private int estadoCon; //Recebe e informa o Estado da Conexão

        //Metodo Construtor
        public Gerente()
        {

        }
        public Gerente(int matricula)
        {
            this.Matricula = matricula;
        }
        public Gerente(int matricula, string nome, string cpf)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Cpf = cpf;                      
        }
        //Propriedades
        [Display(Name = "Matrícula")]
        public int Matricula { get => matricula; set => matricula = value; }
        [Display(Name = "Nome")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Nome { get => nome; set => nome = value; }
        [Display(Name = "Cpf")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Cpf { get => cpf; set => cpf = value; }      
        
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }
    }
}
