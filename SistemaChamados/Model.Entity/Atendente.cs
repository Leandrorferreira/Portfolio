using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Atendente
    {
        //Declaração dos Atributos (variáveis de instância)
        private int matricula;
        private string nome;
        private string funcao; //Pode ser Analista de Help desk ou Service desk
        private string cpf;        
        private int estadoCon; //Recebe e informa o Estado da Conexão

        //Metodos Construtores
        public Atendente()
        {

        }
        public Atendente(int matricula)
        {
            this.Matricula = matricula;
        }
        public Atendente(int matricula, string nome, string funcao, string cpf)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Funcao = funcao;
            this.Cpf = cpf;           
        }

        //Propriedades
        [Display(Name = "Matrícula")]
        public int Matricula { get => matricula; set => matricula = value; }

        [Display(Name = "Nome")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Nome { get => nome; set => nome = value; }

        [Display(Name = "Função")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Funcao { get => funcao; set => funcao = value; }

        [Display(Name = "CPF")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]

        public string Cpf { get => cpf; set => cpf = value; }
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }
    }
}
