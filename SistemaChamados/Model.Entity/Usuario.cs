using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Usuario
    {
        //Declaração dos Atributos
        private int matricula;
        private int codEmpresa;    //Recebe e informa o Código da empresa
        private string nome;
        private string cpf;
        private string ramal;
        private int estadoCon;  //Recebe e informa o Estado da Conexão
               
        //Metodos Construtores

        public Usuario()
        {

        }

        public Usuario(int matricula)
        {
            this.matricula = matricula;
        }

        public Usuario(int matricula, int codEmpresa, string nome, string cpf, string ramal)
        {
            this.matricula = matricula;
            this.codEmpresa = codEmpresa;
            this.nome = nome;
            this.cpf = cpf;
            this.ramal = ramal;
        }

        //Propriedades com Métodos Acessores e Modificadores

        [Display(Name = "Matrícula")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public int Matricula { get => matricula; set => matricula = value; }

        [Display(Name = "Empresa")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public int CodEmpresa { get => codEmpresa; set => codEmpresa = value; }

        [Display(Name = "Nome")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Nome { get => nome; set => nome = value; }

        [Display(Name = "CPF")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Cpf { get => cpf; set => cpf = value; }

        [Display(Name = "Ramal")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Ramal { get => ramal; set => ramal = value; }
                    
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }   
       
    }
}
