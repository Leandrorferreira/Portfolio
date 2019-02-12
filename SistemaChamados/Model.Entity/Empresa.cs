using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Empresa
    {
        //Declaração dos Atributos
        private int codEmpresa;
        private string cnpj;
        private string razaoSocial;
        private string nomeFantasia;
        private string telefone;
        private string logradouro;
        private string complemento;
        private string cidade;
        private string uf; 
        private int estadoCon; //Estado da conexão

        //Metodos Construtores
        public Empresa() { }

        public Empresa(int codEmpresa)
        {
            this.codEmpresa = codEmpresa;
        }

        public Empresa(int codEmpresa, string cnpj, string razaoSocial, string nomeFantasia, string telefone, string logradouro, string complemento, string cidade, string uf)
        {
            this.codEmpresa = codEmpresa;
            this.cnpj = cnpj;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.telefone = telefone;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.cidade = cidade;
            this.uf = uf;
        }

        //Propriedades com Métodos Acessores e Modificadores
        [Display(Name = "Código")]
        public int CodEmpresa { get => codEmpresa; set => codEmpresa = value; }

        [Display(Name = "CNPJ")] //Formatação com DataAnotattion
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Cnpj { get => cnpj; set => cnpj = value; }          

        [Display(Name = "Razão Social")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string RazaoSocial { get => razaoSocial; set => razaoSocial = value; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string NomeFantasia { get => nomeFantasia; set => nomeFantasia = value; }

        [Display(Name = "Telefone")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Telefone { get => telefone; set => telefone = value; }

        [Display(Name = "Logradouro")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Logradouro { get => logradouro; set => logradouro = value; }

        [Display(Name = "Complemento")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Complemento { get => complemento; set => complemento = value; }

        [Display(Name = "Cidade")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Cidade { get => cidade; set => cidade = value; }

        [Display(Name = "UF")] 
        [Required(ErrorMessage = "Informe o campo {0}")]
        public string Uf { get => uf; set => uf = value; }

        //Propriedade que receberá números para tratamento de erros        
        public int EstadoCon { get => estadoCon; set => estadoCon = value; }        
    }
}
