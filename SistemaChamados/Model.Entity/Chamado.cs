using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Chamado
    {
        //Declaração dos Atributos
        private int protocolo;  //Numero de protocolo do chamado gerado automaticamente
        private DateTime dataAbertura;
        private DateTime dataFinalizacao;
        private string descChamado;
        private string descSolucao;
        private int atendente;  //Qual a matricula do Analista que realiza/realizou o atendimento
        private int cliente;   //Qual a matricula do cliente que solicita/solicitou o atendimento
        private string estatus;   //Estatus do Atendimento pode ser em atendimento ou finalizado
        private int estadoCon;   //Estado da conexão com o banco

        //Metodos Contrutores

        public Chamado()
        {

        }

        public Chamado(int protocolo)
        {
            this.protocolo = protocolo;
        }

        public Chamado(int protocolo, DateTime dataAbertura, DateTime dataFinalizacao, string descChamado, string descSolucao, int atendente, int cliente, string estatus)
        {
            this.protocolo = protocolo;
            this.dataAbertura = dataAbertura;
            this.dataFinalizacao = dataFinalizacao;
            this.descChamado = descChamado;
            this.descSolucao = descSolucao;
            this.atendente = atendente;
            this.cliente = cliente;
            this.estatus = estatus;
        }

        //Propriedades com Métodos Acessores e Modificadores

        [Display(Name = "Protocolo")] //Formatação com DataAnotattion     
        public int Protocolo { get => protocolo; set => protocolo = value; }

        [Display(Name = "Abertura do Chamado")] //Formatação com DataAnotattion
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }

        [Display(Name = "Finalização do Chamado")] //Formatação com DataAnotattion
        public DateTime DataFinalizacao { get => dataFinalizacao; set => dataFinalizacao = value; }

        [Display(Name = "Descrição")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string DescChamado { get => descChamado; set => descChamado = value; }

        [Display(Name = "Solução")] //Formatação com DataAnotattion
        public string DescSolucao { get => descSolucao; set => descSolucao = value; }

        [Display(Name = "Atendente")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public int Atendente { get => atendente; set => atendente = value; }

        [Display(Name = "Cliente")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public int Cliente { get => cliente; set => cliente = value; }

        public string Estatus { get => estatus; set => estatus = value; }
               
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }
    }       
    
}
