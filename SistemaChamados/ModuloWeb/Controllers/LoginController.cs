using Model.Business;
using Model.Entity;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class LoginController : Controller
    {
        LoginBusiness objLoginBusiness;

        //Contrutor iniciando objeto de LoginBusiness
        public LoginController()
        {
            objLoginBusiness = new LoginBusiness();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string senha)
        {
            //Iniciando variaveis da classe Singleton
            Autenticacao.Instancia.Matricula = 0;
            Autenticacao.Instancia.Cargo = string.Empty;

            if (email == "" || senha == "")
            {
                //Validar Email
                if (email == "" || email == null)
                {
                    ViewBag.Erro = "Informe o seu Email";
                    return View();
                }
                //Validar Email
                if (senha == "" || senha == null)
                {
                    ViewBag.Erro = "Informe sua senha";
                    return View();
                }
            }
            else
            {
                if((email == "") && (senha == ""))
                {
                    ViewBag.Erro = "Informe seu e-mail e senha";
                    return View();
                }                
            }

            //Verificar se o Login e Senha existem e estão corretos
            var login = objLoginBusiness.logar(email, senha);
            if(login.EstadoCon == 1)
            {
                ViewBag.Erro = "Email e/ou Senha não encontrado(s)!";
                return View();
            }
            else
            {
                Autenticacao.Instancia.Matricula = login.Matricula;
                Autenticacao.Instancia.Cargo = login.Cargo;
            }

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Logout()
        {
            Autenticacao.Instancia.Matricula = 0;
            Autenticacao.Instancia.Cargo = string.Empty;
            return RedirectToAction("Index", "Login");
        }

        public ActionResult MudarSenha()
        {           

            Login objLogin = new Login();
            //Buscando dados do usuario com base na matricula e no cargo
            objLogin = objLoginBusiness.buscarDadosLogin(Autenticacao.Instancia.Matricula, Autenticacao.Instancia.Cargo);
            
            return View(objLogin);
        }

        [HttpPost]
        public ActionResult MudarSenha(Login objLogin)
        {
            if(objLogin.Email == "" || objLogin.Senha == "")
            {
                ViewBag.Erro = "Informe um novo Email e Senha";
                return View();
            }
            if (ModelState.IsValid)
            {
                objLoginBusiness.alterar(objLogin);
                ViewBag.Exito = "Sua Senha foi alterada com sucesso!";
            }                        
            return View();
        }
    }
}