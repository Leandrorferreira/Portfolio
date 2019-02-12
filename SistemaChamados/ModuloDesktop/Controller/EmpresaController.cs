using Model.Business;
using Model.Entity;

namespace ModuloDesktop.Controller
{
    public class EmpresaController
    {
        EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
        //Verificar se existem campos vazios
        public bool validarCampos(string cnpj,string razaoSocial,string nomeFantasia,string telefone,string logradouro,string complemento,string cidade,string uf)
        {
            bool vazio = false;

            if ((cnpj == "")||(razaoSocial == "")||(nomeFantasia == "")||(telefone=="")||(logradouro=="")||(complemento=="")||(cidade=="")||(uf==""))
            {
                vazio = true;
            }

            return vazio;
        }

        //Cadastrar Empresa
        public string cadastrar(Empresa empresa)
        {
            string mensagem = null;

            objEmpresaBusiness.cadastrar(empresa);
            
            //Verifica se houve erros
            switch (empresa.EstadoCon)
            {

                case 32://campo UF vazio
                    mensagem = "Insira o UF";
                    break;

                case 23://erro de complemento
                    mensagem = "O campo UF não pode ter mais de 2 caracteres";
                    break;

                case 25://campo complemento vazio
                    mensagem = "Insira o complemento do endereço";
                    break;

                case 52://erro de complemento
                    mensagem = "O complemento não pode ter mais de 40 caracteres";
                    break;

                case 20://campo nome vazio
                    mensagem = "Insira o Nome Fantasia da Empresa";
                    break;

                case 2://erro de nome
                    mensagem = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 30://campo razão social vazio
                    mensagem = "Insira a razão social da Empresa";
                    break;

                case 3://erro de razão social
                    mensagem = "A razão social não pode ter mais de 50 caracteres";
                    break;

                case 40://campo logradouro vazio
                    mensagem = "Insira o logradouro da Empresa";
                    break;

                case 4://erro de logradouro
                    mensagem = "O logradouro não pode ter mais de 30 caracteres";
                    break;

                case 50://campo cnpj vazio
                    mensagem = "Insira o CNPJ da Empresa";
                    break;

                case 250://quantidade de números do campo cnpj 
                    mensagem = "O CNPJ tem que ter 14 números!";
                    break;

                case 60://cidade vazio
                    mensagem = "Digite o nome da Cidade";
                    break;

                case 6://erro no campo cidade
                    mensagem = "Campo Cidade não pode ter mais de 30 caracteres";
                    break;

                case 70://campo telefone vazio
                    mensagem = "Insira um telefone da empresa";
                    break;

                case 7://quantidade de caracteres do campo telefone
                    mensagem = "O telefone tem que ter de 8 a 12 digitos";
                    break;

                case 8://erro de duplicidade
                    mensagem = "Empresa " + empresa.CodEmpresa + " já está registrada no sistema";
                    break;

                case 9://erro de duplicidade
                    mensagem = "Número de CNPJ " + empresa.Cnpj + " já está registrado no sistema";
                    break;

                case 99://empresa Salva com Sucesso
                    mensagem = "Empresa " + empresa.NomeFantasia + " foi inserida no sistema";
                    break;
            }
            return mensagem;
        }

        //Alterar Empresa
        public string alterar(Empresa empresa)
        {
            string mensagem = null;

            objEmpresaBusiness.alterar(empresa);

            //Verifica se houve erros
            switch (empresa.EstadoCon)
            {

                case 32://campo UF vazio
                    mensagem = "Insira o UF";
                    break;

                case 23://erro de complemento
                    mensagem = "O campo UF não pode ter mais de 2 caracteres";
                    break;

                case 25://campo complemento vazio
                    mensagem = "Insira o complemento do endereço";
                    break;

                case 52://erro de complemento
                    mensagem = "O complemento não pode ter mais de 40 caracteres";
                    break;

                case 20://campo nome vazio
                    mensagem = "Insira o Nome Fantasia da Empresa";
                    break;

                case 2://erro de nome
                    mensagem = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 30://campo razão social vazio
                    mensagem = "Insira a razão social da Empresa";
                    break;

                case 3://erro de razão social
                    mensagem = "A razão social não pode ter mais de 50 caracteres";
                    break;

                case 40://campo logradouro vazio
                    mensagem = "Insira o logradouro da Empresa";
                    break;

                case 4://erro de logradouro
                    mensagem = "O logradouro não pode ter mais de 30 caracteres";
                    break;

                case 50://campo cnpj vazio
                    mensagem = "Insira o CNPJ da Empresa";
                    break;

                case 250://quantidade de números do campo cnpj 
                    mensagem = "O CNPJ tem que ter 14 números!";
                    break;

                case 60://cidade vazio
                    mensagem = "Digite o nome da Cidade";
                    break;

                case 6://erro no campo cidade
                    mensagem = "Campo Cidade não pode ter mais de 30 caracteres";
                    break;

                case 70://campo telefone vazio
                    mensagem = "Insira um telefone da empresa";
                    break;

                case 7://quantidade de caracteres do campo telefone
                    mensagem = "O telefone tem que ter de 8 a 12 digitos";
                    break;               

                case 9://erro de duplicidade
                    mensagem = "Número de CNPJ " + empresa.Cnpj + " já está registrado no sistema";
                    break;

                case 99://empresa alterada com Sucesso
                    mensagem = "Os dados da empresa " + empresa.NomeFantasia + " foram alterados!";
                    break;
            }
            return mensagem;
        }
    }
}
