using Model.Business;
using Model.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class AtendenteController : Controller
    {
        //Criando objeto da classe de negócio
        AtendenteBusiness objAtendenteBusiness;
        LoginBusiness objLoginBusiness;

        public AtendenteController()
        {
            objAtendenteBusiness = new AtendenteBusiness();
            objLoginBusiness = new LoginBusiness();
        }

        // GET: Atendente
        public ActionResult Index()
        {
            //Criando uma lista de atendentes
            List<Atendente> lista = objAtendenteBusiness.buscarTudo();
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
        public ActionResult Create(Atendente objAtendente, string txtEmail, string txtSenha)
        {
            if (txtEmail == "" || txtSenha == "")
            {
                ViewBag.MensagemErro = "Informe um E-mail e uma Senha!";
            }

            mensagemInicioRegistrar();
            objAtendenteBusiness.cadastrar(objAtendente);
            mensagemErroRegistrar(objAtendente);

            if (objAtendente.EstadoCon == 99) //Se foi cadastrado um gerente com sucesso
            {
                Login objLogin = new Login();
                objLogin.Email = txtEmail;
                objLogin.Senha = txtSenha;
                objLogin.Matricula = objAtendenteBusiness.buscarMatriculaPorCpf(objAtendente.Cpf);
                objLogin.Cargo = "Analista";
                objLogin.EstadoCon = 99;

                //Cadastrar um login para este gerente
                objLoginBusiness.cadastrar(objLogin);
            }
            ModelState.Clear();  //Limpa os dados
            return View("Create");
        }

        //mensagem de erro
        public void mensagemErroRegistrar(Atendente objAtendente)
        {
            switch (objAtendente.EstadoCon)
            {

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome do Atendente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira o CPF do Atendente";
                    break;

                case 250://quantidade de números do campo cpf
                    ViewBag.MensagemErro = "O CPF tem que ter 11 dígitos!";
                    break;

                case 60://Função vazio
                    ViewBag.MensagemErro = "Digite a função do Atendente";
                    break;

                case 6://erro no campo função
                    ViewBag.MensagemErro = "Campo função não pode ter mais de 20 caracteres";
                    break;                       

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF: " + objAtendente.Cpf + " já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = null;
                    ViewBag.MensagemExito = "Atendente " + objAtendente.Nome + " foi inserido no sistema";
                    break;
            }
        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Atendente e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            mensagemInicialAtualizar();
            Atendente objAtendente = new Atendente(id);
            objAtendenteBusiness.buscar(objAtendente);
            return View(objAtendente);
        }
        [HttpPost]
        public ActionResult Update(Atendente objAtendente)
        {
            mensagemInicialAtualizar();
            objAtendenteBusiness.alterar(objAtendente);
            MensagemErroAtualizar(objAtendente);
            return View();

        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Atendente objAtendente)
        {
            switch (objAtendente.EstadoCon)
            {
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o Nome do Atendente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 50 caracteres";
                    break;

                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira o CPF do Atendente";
                    break;

                case 250://quantidade de números do campo cpf
                    ViewBag.MensagemErro = "O CPF tem que ter 11 dígitos!";
                    break;

                case 60://Função vazio
                    ViewBag.MensagemErro = "Digite a função do Atendente";
                    break;

                case 6://erro no campo função
                    ViewBag.MensagemErro = "Campo função não pode ter mais de 20 caracteres";
                    break;

                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = null;
                    ViewBag.MensagemExito = "Dados do atendente " + objAtendente.Nome + " foram atualizados!";
                    break;

            }

        }
        //mensagem Inicial Atualizar
        public void mensagemInicialAtualizar()
        {
            ViewBag.MensagemInicialAtualizar = "Formulário para Atualizar Dados do Atendente";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensagemInicialEliminar();
            Atendente objAtendente = new Atendente(id);
            objAtendenteBusiness.buscar(objAtendente);
            return View(objAtendente);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            mensagemInicialEliminar();
            Atendente objAtendente = new Atendente(id);
            objAtendenteBusiness.excluir(objAtendente);
            mostrarMensagemEliminar(objAtendente);
            return Redirect("~/Atendente/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            mensagemInicialEliminar();
            Atendente objAtendente = new Atendente(id);
            objAtendenteBusiness.buscar(objAtendente);
            return View(objAtendente);
        }

        [HttpPost]
        public ActionResult Eliminar(Atendente objAtendente)
        {
            mensagemInicialEliminar();
            objAtendenteBusiness.excluir(objAtendente);
            mostrarMensagemEliminar(objAtendente);
            Atendente objAtendente2 = new Atendente();
            return View(objAtendente2);
            
        }

        //mensagem de erro ao excluir
        private void mostrarMensagemEliminar(Atendente objAtendente)
        {

            switch (objAtendente.EstadoCon)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Atendente " + objAtendente.Matricula + " não está registrado no sistema ";
                    break;

                case 33://NAO EXISTE
                    ViewBag.MensagemErro = "Atendente: " + objAtendente.Nome + " já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar o Atendente" + objAtendente.Nome + ", tem chamados relacionados ao atendente!";
                    break;

                case 300:
                    ViewBag.MensagemErro = "O atendente " + objAtendente.Nome + " não pode ser excluído sem excluir os chamados que ele atendeu!";
                    break;

                case 99: //EXITO
                    ViewBag.MensagemExito = "Empresa " + objAtendente.Nome + " excluido com sucesso!!!";
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
            Atendente objAtendente = new Atendente(id);
            objAtendenteBusiness.buscar(objAtendente);

            return View(objAtendente);
        }

        [HttpGet]
        public ActionResult BuscarAtendentes()
        {
            List<Atendente> lista = objAtendenteBusiness.buscarTudo();
            return View(lista);
        }

        [HttpPost]
        public ActionResult BuscarAtendentes(string txtnome, string txtcpf, string txtfuncao)
        {

            if (txtnome == "")
            {
                txtnome = "-1";
            }

            if (txtcpf == "")
            {
                txtcpf = "-1";
            }
            if(txtfuncao == "")
            {
                txtfuncao = "-1";
            }
            Atendente objAtendente = new Atendente();
            objAtendente.Nome = txtnome;
            objAtendente.Cpf = txtcpf;
            objAtendente.Funcao = txtfuncao;
            List<Atendente> atendente = objAtendenteBusiness.buscarTudoAtendentes(objAtendente);
            return View(atendente);
        }
    }
}
