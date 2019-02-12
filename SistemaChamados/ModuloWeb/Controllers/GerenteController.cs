using Model.Business;
using Model.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class GerenteController : Controller
    {
        //Criando objeto da classe de negócio
        GerenteBusiness objGerenteBusiness;
        LoginBusiness objLoginBusiness;

        //Metodo Construtor
        public GerenteController()
        {
            objGerenteBusiness = new GerenteBusiness();
            objLoginBusiness = new LoginBusiness();
        }

        // GET: Atendente
        public ActionResult Index()
        {
            //Criando uma lista de atendentes
            List<Gerente> lista = objGerenteBusiness.buscarTudo();
            return View(lista); //Retorna a lista de atendentes para a View Index
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            mensagemInicioRegistrar();
            ViewBag.Email = "";
            ViewBag.Senha = "";
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create(Gerente objGerente, string txtEmail, string txtSenha)
        {
            if(txtEmail == "" || txtSenha == "")
            {
                ViewBag.MensagemErro = "Informe um E-mail e uma Senha!";                
            }

            mensagemInicioRegistrar();
            objGerenteBusiness.cadastrar(objGerente);
            mensagemErroRegistrar(objGerente);

            if(objGerente.EstadoCon == 99) //Se foi cadastrado um gerente com sucesso
            {
                Login objLogin = new Login();
                objLogin.Email = txtEmail;
                objLogin.Senha = txtSenha;
                objLogin.Matricula = objGerenteBusiness.buscarMatriculaPorCpf(objGerente.Cpf);
                objLogin.Cargo = "Gerente";
                objLogin.EstadoCon = 99;

                //Cadastrar um login para este gerente
                objLoginBusiness.cadastrar(objLogin);
            }
            ModelState.Clear();  //Limpa os dados
            return View("Create");
        }
        
        //mensagem de erro
        public void mensagemErroRegistrar(Gerente objGerente)
        {
            switch (objGerente.EstadoCon)
            {

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome do Gerente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira o CPF do Gerente";
                    break;

                case 250://quantidade de números do campo cpf
                    ViewBag.MensagemErro = "O CPF tem que ter 11 números, apenas números!";
                    break;                               

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF: " + objGerente.Cpf + " já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Gerente " + objGerente.Nome + " foi inserido no sistema";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Gerente e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            mensagemInicialAtualizar();
            Gerente objGerente = new Gerente(id);
            objGerenteBusiness.buscar(objGerente);
            return View(objGerente);
        }

        [HttpPost]
        public ActionResult Update(Gerente objGerente)
        {
            mensagemInicialAtualizar();
            objGerenteBusiness.alterar(objGerente);
            MensagemErroAtualizar(objGerente);
            return View();
        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Gerente objGerente)
        {
            switch (objGerente.EstadoCon)
            {
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome do Gerente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira o CPF do Gerente";
                    break;

                case 250://quantidade de números do campo cpf
                    ViewBag.MensagemErro = "O CPF tem que ter 11 números, apenas números!";
                    break;

                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = "Dados do Gerente " + objGerente.Nome + " foram atualizados!";
                    break;
            }

        }
        //mensagem Inicial Atualizar
        public void mensagemInicialAtualizar()
        {
            ViewBag.MensagemInicialAtualizar = "Formulário para Atualizar Dados do Gerente";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensagemInicialEliminar();
            Gerente objGerente = new Gerente(id);
            objGerenteBusiness.buscar(objGerente);
            return View(objGerente);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            mensagemInicialEliminar();
            Gerente objGerente = new Gerente(id);
            objGerenteBusiness.excluir(objGerente);
            mostrarMensagemEliminar(objGerente);
            return Redirect("~/Atendente/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            mensagemInicialEliminar();
            Gerente objGerente = new Gerente(id);
            objGerenteBusiness.buscar(objGerente);
            return View(objGerente);
        }

        [HttpPost]
        public ActionResult Eliminar(Gerente objGerente)
        {
            mensagemInicialEliminar();
            objGerenteBusiness.excluir(objGerente);
            mostrarMensagemEliminar(objGerente);
            Gerente objGerente2 = new Gerente();
            return View(objGerente2);

        }

        //mensagem de erro ao excluir
        private void mostrarMensagemEliminar(Gerente objGerente)
        {

            switch (objGerente.EstadoCon)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Gerente " + objGerente.Matricula + " não está registrado no sistema";
                    break;

                case 33://NAO EXISTE
                    ViewBag.MensagemErro = "Gerente: " + objGerente.Nome + " já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar o Gerente" + objGerente.Nome + ", tem chamados relacionados";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Gerente " + objGerente.Nome + " excluido com sucesso";
                    break;

                default:
                    ViewBag.MensagemErro = "=== Deu Erro ??? ===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
        }

        public ActionResult Find(int id)
        {
            Gerente objGerente = new Gerente(id);
            objGerenteBusiness.buscar(objGerente);

            return View(objGerente);
        }

        [HttpGet]
        public ActionResult BuscarGerentes()
        {
            List<Gerente> lista = objGerenteBusiness.buscarTudo();
            return View(lista);
        }

        [HttpPost]
        public ActionResult BuscarGerentes(string txtnome, string txtcpf)
        {

            if (txtnome == "")
            {
                txtnome = "-1";
            }

            if (txtcpf == "")
            {
                txtcpf = "-1";
            }

            Gerente objGerente = new Gerente();
            objGerente.Nome = txtnome;
            objGerente.Cpf = txtcpf;
           
            List<Gerente> gerente = objGerenteBusiness.buscarTudoGerentes(objGerente);
            return View(gerente);
        }
    }
}
