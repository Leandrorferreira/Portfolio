using Model.Business;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class EmpresaController : Controller
    {
        //Criando objeto da classe de negócio
        EmpresaBusiness objEmpresaBusiness;

        public EmpresaController()
        {            
            objEmpresaBusiness = new EmpresaBusiness();
        }

        // GET: Empresa
        public ActionResult Index()
        {
            //Criando uma lista de empresas
            List<Empresa> lista = objEmpresaBusiness.buscarTudo();
            return View(lista); //Retorna a lista de empresas para a View Index
        }
              
        // GET: Empresa/Create
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create(Empresa objEmpresa)
        {
            mensagemInicioRegistrar();
            objEmpresaBusiness.cadastrar(objEmpresa);
            mensagemErroRegistrar(objEmpresa);
            ModelState.Clear();  //Limpa os dados
            return View("Create");
        }
               
        //mensagem de erro
        public void mensagemErroRegistrar(Empresa objEmpresa)
        {
            switch (objEmpresa.EstadoCon)
            {
                
                case 32://campo UF vazio
                    ViewBag.MensagemErro = "Insira o UF";
                    break;

                case 23://erro de complemento
                    ViewBag.MensagemErro = "O campo UF não pode ter mais de 2 caracteres";
                    break;

                case 25://campo complemento vazio
                    ViewBag.MensagemErro = "Insira o complemento do endereço";
                    break;

                case 52://erro de complemento
                    ViewBag.MensagemErro = "O complemento não pode ter mais de 40 caracteres";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome Fantasia da Empresa";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 30://campo razão social vazio
                    ViewBag.MensagemErro = "Insira a razão social da Empresa";
                    break;

                case 3://erro de razão social
                    ViewBag.MensagemErro = "A razão social não pode ter mais de 50 caracteres";
                    break;

                case 40://campo logradouro vazio
                    ViewBag.MensagemErro = "Insira o logradouro da Empresa";
                    break;

                case 4://erro de logradouro
                    ViewBag.MensagemErro = "O logradouro não pode ter mais de 30 caracteres";
                    break;

                case 50://campo cnpj vazio
                    ViewBag.MensagemErro = "Insira o CNPJ da Empresa";
                    break;

                case 250://quantidade de números do campo cnpj 
                    ViewBag.MensagemErro = "O CNPJ tem que ter 14 números!";
                    break;

                case 60://cidade vazio
                    ViewBag.MensagemErro = "Digite o nome da Cidade";
                    break;

                case 6://erro no campo cidade
                    ViewBag.MensagemErro = "Campo Cidade não pode ter mais de 30 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira um telefone da empresa";
                    break;

                case 7://quantidade de caracteres do campo telefone
                    ViewBag.MensagemErro = "O telefone tem que ter de 8 a 12 digitos";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Empresa " + objEmpresa.CodEmpresa + " já está registrada no sistema";
                    break;

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CNPJ " + objEmpresa.Cnpj + " já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Empresa " + objEmpresa.NomeFantasia + " foi inserida no sistema";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados da Empresa e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            mensagemInicialAtualizar();
            Empresa objEmpresa = new Empresa(id);
            objEmpresaBusiness.buscar(objEmpresa);
            return View(objEmpresa);
        }
        [HttpPost]
        public ActionResult Update(Empresa objEmpresa)
        {
            mensagemInicialAtualizar();
            objEmpresaBusiness.alterar(objEmpresa);
            MensagemErroAtualizar(objEmpresa);
            return View();            
        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Empresa objEmpresa)
        {
            switch (objEmpresa.EstadoCon)
            {

                case 32://campo UF vazio
                    ViewBag.MensagemErro = "Insira o UF";
                    break;

                case 23://erro de complemento
                    ViewBag.MensagemErro = "O campo UF não pode ter mais de 2 caracteres";
                    break;

                case 25://campo complemento vazio
                    ViewBag.MensagemErro = "Insira o complemento do endereço";
                    break;

                case 52://erro de complemento
                    ViewBag.MensagemErro = "O complemento não pode ter mais de 40 caracteres";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome Fantasia da Empresa";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 30://campo razão social vazio
                    ViewBag.MensagemErro = "Insira a razão social da Empresa";
                    break;

                case 3://erro de razão social
                    ViewBag.MensagemErro = "A razão social não pode ter mais de 50 caracteres";
                    break;

                case 40://campo logradouro vazio
                    ViewBag.MensagemErro = "Insira o logradouro da Empresa";
                    break;

                case 4://erro de logradouro
                    ViewBag.MensagemErro = "O logradouro não pode ter mais de 30 caracteres";
                    break;

                case 50://campo cnpj vazio
                    ViewBag.MensagemErro = "Insira o CNPJ da Empresa";
                    break;

                case 250://quantidade de números do campo cnpj 
                    ViewBag.MensagemErro = "O CNPJ tem que ter 14 números!";
                    break;

                case 60://cidade vazio
                    ViewBag.MensagemErro = "Digite o nome da Cidade";
                    break;

                case 6://erro no campo cidade
                    ViewBag.MensagemErro = "Campo Cidade não pode ter mais de 30 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira um telefone da empresa";
                    break;

                case 7://quantidade de caracteres do campo telefone
                    ViewBag.MensagemErro = "O telefone tem que ter de 8 a 12 digitos";
                    break;

                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = "Dados da empresa " + objEmpresa.NomeFantasia + " foram atualizados!";
                    break;

            }

        }
        //mensagem Inicial Atualizar
        public void mensagemInicialAtualizar()
        {
            ViewBag.MensagemInicialAtualizar = "Formulário para Atualizar Dados da Empresa";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensagemInicialEliminar();
            Empresa objEmpresa = new Empresa(id);
            objEmpresaBusiness.buscar(objEmpresa);
            return View(objEmpresa);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            mensagemInicialEliminar();
            Empresa objEmpresa = new Empresa(id);
            objEmpresaBusiness.excluir(objEmpresa);
            mostrarMensagemEliminar(objEmpresa);
            return Redirect("~/Empresa/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            mensagemInicialEliminar();
            Empresa objEmpresa = new Empresa(id);
            objEmpresaBusiness.buscar(objEmpresa);
            return View(objEmpresa);
        }

        [HttpPost]
        public ActionResult Eliminar(Empresa objEmpresa)
        {
            mensagemInicialEliminar();
            objEmpresaBusiness.excluir(objEmpresa);
            mostrarMensagemEliminar(objEmpresa);
            Empresa objEmpresa2 = new Empresa();
            return View(objEmpresa2);
            //return RedirectToAction("Index");
        }

        //mensagem de erro ao excluir
        private void mostrarMensagemEliminar(Empresa objEmpresa)
        {

            switch (objEmpresa.EstadoCon)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Empresa " + objEmpresa.CodEmpresa + " Não está registrado no sistema ";
                    break;

                case 33://CLIENTE NAO EXISTE
                    ViewBag.MensagemErro = "Empresa: " + objEmpresa.NomeFantasia + " já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar a Empresa " + objEmpresa.NomeFantasia + ", Tem clientes relacionados à empresa!";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Empresa " + objEmpresa.NomeFantasia + " excluida com sucesso!!!";
                    break;

                default:
                    ViewBag.MensagemErro = "===Deu Erro ???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
        }

        public ActionResult Find(int id)
        {
            Empresa objEmpresa = new Empresa(id);
            objEmpresaBusiness.buscar(objEmpresa);

            return View(objEmpresa);
        }

        [HttpGet]
        public ActionResult BuscarEmpresas()
        {
            List<Empresa> lista = objEmpresaBusiness.buscarTudo();
            return View(lista);
        }

        [HttpPost]
        public ActionResult BuscarEmpresas(string txtnome, string txtcnpj)
        {

            if (txtnome == "")
            {
                txtnome = "-1";
            }

            if (txtcnpj == "")
            {
                txtcnpj = "-1";
            }
           
            Empresa objEmpresa = new Empresa();
            objEmpresa.NomeFantasia = txtnome;
            objEmpresa.Cnpj = txtcnpj;

            List<Empresa> empresa = objEmpresaBusiness.buscarTudoEmpresas(objEmpresa);
            return View(empresa);
        }
    }
}
    

