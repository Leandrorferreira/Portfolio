using Model.Business;
using Model.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBusiness objUsuarioBusiness;

        public UsuarioController()
        {
            objUsuarioBusiness = new UsuarioBusiness();
        }
        public ActionResult Index()
        {
            
            List<Usuario> lista= objUsuarioBusiness.findAll();

            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            //Cria uma lista com o nome de cada empresa
            List<Empresa> listaEmpresa = new List<Empresa>();
            foreach (var item in lista)
            {
                listaEmpresa.Add(objEmpresaBusiness.buscarEmpresaPorCod(item.CodEmpresa));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaEmpresa = listaEmpresa;
            
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;
            mensagemInicioRegistrar();
            //Informa que é a primeira vez que a pagina esta carregando
            return View();
        }
        [HttpPost]
        public ActionResult Create(Usuario objUsuario)
        {
            mensagemInicioRegistrar();
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;
            objUsuarioBusiness.cadastrar(objUsuario);
            MensagemErroRegistrar(objUsuario);
            return View("Create");
        }

        //mensaje de error
        public void MensagemErroRegistrar(Usuario objUsuario)
        {
            ViewBag.Modal = "Habilitar";
            switch (objUsuario.EstadoCon)
            {
                                               
                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do Usuário";
                    break;

                case 2://error de nome
                    ViewBag.MensagemErro = "Digite um nome até 50 caracteres";
                    break;

                case 30://campo preco unitario vazio
                    ViewBag.MensagemErro = "Insira o número do ramal";
                    break;

                case 3://erro de preco Unitario
                    ViewBag.MensagemErro = "Número de Ramal Inválido";
                    break;

                case 40://categoria vazia
                    ViewBag.MensagemErro = "CPF Vazio";
                    break;

                case 4://erro na categoria
                    ViewBag.MensagemErro = "CPF Inválido";
                    break;

                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Usuário " + objUsuario.Cpf + " já está inserido no Sistema";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensagemExito = "Usuário " + objUsuario.Nome + " foi registrado no Sistema";
                    break;
            }

        }

        public void mensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os Dados do Usuário";
        }

        public ActionResult Update(int id)
        {
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;
            Usuario objUsuario = new Usuario(id);
            objUsuarioBusiness.buscar(objUsuario);
            mensagemInicioAtualizar();
            return View(objUsuario);
        }

        [HttpPost]
        public ActionResult Update(Usuario objUsuario)
        {
            mensagemInicioAtualizar();
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;
            objUsuarioBusiness.alterar(objUsuario);
            MensagemErroAtualizar(objUsuario);
            return View();
        }

        //mensaje de error
        public void MensagemErroAtualizar(Usuario objUsuario)
        {
            ViewBag.Modal = "Habilitar";
            switch (objUsuario.EstadoCon)
            {

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira o nome do Usuário";
                    break;

                case 2://error de nome
                    ViewBag.MensagemErro = "Digite um nome até 50 caracteres";
                    break;

                case 30://campo preco unitario vazio
                    ViewBag.MensagemErro = "Insira o número do ramal";
                    break;

                case 3://erro de preco Unitario
                    ViewBag.MensagemErro = "Número de Ramal Inválido";
                    break;

                case 40://categoria vazia
                    ViewBag.MensagemErro = "CPF Vazio";
                    break;

                case 4://erro na categoria
                    ViewBag.MensagemErro = "CPF Inválido";
                    break;

                case 99://atualizada com exito
                    ViewBag.MensagemExito = "Dados do Usuário " + objUsuario.Nome + " Foram Modificados";
                    break;

            }

        }
        public void mensagemInicioAtualizar()
        {
            ViewBag.MensagemInicio = "Insira os dados para Atualizar";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensagemInicialEliminar();
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();  
            Usuario objUsuario = new Usuario(id);
            objUsuarioBusiness.buscar(objUsuario);
            //Retorna o nome da empresa do usuário com base no codigo da empresa            
            string empresa = objEmpresaBusiness.buscarNomeEmpresa(objUsuario.CodEmpresa);
            //Passa o nome da empresa para um ViewBag que irá mostrar o valor na View
            ViewBag.Empresa = empresa;

            return View(objUsuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario objUsuario)
        {
            mensagemInicialEliminar();
            objUsuarioBusiness.delete(objUsuario);
            mostrarMensagemEliminar(objUsuario);
            Usuario objUsuario2 = new Usuario();
            return View(objUsuario2);            
        }

        //mensagem ao excluir
        private void mostrarMensagemEliminar(Usuario objUsuario)
        {
            ViewBag.Modal = "Habilitar";
            switch (objUsuario.EstadoCon)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Usuário [" + objUsuario.Matricula + "] Não existe no Sistema ";
                    break;

                case 33://PRODUTO NAO EXISTE
                    ViewBag.MensagemErro = "O Produto: [" + objUsuario.Nome + "] Já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode excluir o Usuário [" + objUsuario.Nome + "] por ter chamados relacionados!!!";
                    break;

                case 300:
                    ViewBag.MensagemErro = "O usuário " + objUsuario.Nome + " não pode ser excluído sem excluir os chamados que ele solicitou!";
                    break;

                case 99: //EXITO
                    ViewBag.MensagemExito = "Usuário [" + objUsuario.Nome + "] Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulário de Exclusão";
        }

        public ActionResult Find(int id)
        {
            Usuario objUsuario = new Usuario(id);
            objUsuarioBusiness.buscar(objUsuario);
            //Retorna o nome da empresa do usuário com base no codigo da empresa
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            string empresa = objEmpresaBusiness.buscarNomeEmpresa(objUsuario.CodEmpresa);
            //Passa o nome da empresa para um ViewBag que irá mostrar o valor na View
            ViewBag.Empresa = empresa;
            return View(objUsuario);
        }

        [HttpGet]
        public ActionResult BuscarUsuarios()
        {
        
            List<Usuario> lista = objUsuarioBusiness.findAll();
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            //Cria uma lista com o nome de cada empresa
            List<Empresa> listaEmpresa = new List<Empresa>();
            foreach (var item in lista)
            {
                listaEmpresa.Add(objEmpresaBusiness.buscarEmpresaPorCod(item.CodEmpresa));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaEmpresa = listaEmpresa;
            //Lista para mostrar itens em um DropDown
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista2 = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista2;

            return View(lista);
        }

        [HttpPost]
        public ActionResult BuscarUsuarios(string txtnome, string txtcpf, int ListaEmpresas = 0)
        {

            if (txtnome == "")
            {
                txtnome = "-1";
            }   
            if(txtcpf == "")
            {
                txtcpf = "-1";
            }
            if (ListaEmpresas == 0)
            {
                ListaEmpresas = -1;
            }

            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;

            List<Usuario> lista2 = objUsuarioBusiness.findAll();
            EmpresaBusiness objEmpresaBusiness2 = new EmpresaBusiness();
            //Cria uma lista com o nome de cada empresa
            List<Empresa> listaEmpresa = new List<Empresa>();
            foreach (var item in lista2)
            {
                listaEmpresa.Add(objEmpresaBusiness2.buscarEmpresaPorCod(item.CodEmpresa));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaEmpresa = listaEmpresa;

            Usuario objUsuario = new Usuario();
            objUsuario.Nome = txtnome;
            objUsuario.Cpf = txtcpf;
            objUsuario.CodEmpresa = ListaEmpresas;

            List<Usuario> Usuario = objUsuarioBusiness.findAllUsuarios(objUsuario);
            mensagemErroServidor(objUsuario);
            return View(Usuario);
        }

        public void mensagemErroServidor(Usuario objUsuario)
        {
            switch (objUsuario.EstadoCon)
            {
                case 1000:
                    ViewBag.MensajeError = "Erro no Banco de Dados, Contate o Suporte Técnico!";
                    break;
            }
        }

        [HttpGet]
        public ActionResult BuscarUsuariosPorEmpresa()
        {
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;
            List<Usuario> Usuario = objUsuarioBusiness.findAll();
            return View(Usuario);
        }

        [HttpPost]
        public ActionResult BuscarUsuariosPorEmpresa(int ListaEmpresas)
        {
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            List<Empresa> data = objEmpresaBusiness.buscarTudo();
            SelectList lista = new SelectList(data, "CodEmpresa", "NomeFantasia");
            ViewBag.ListaEmpresas = lista;

            Usuario objUsuario = new Usuario();
            objUsuario.CodEmpresa = ListaEmpresas;
            List<Usuario> Usuario = objUsuarioBusiness.findAllUsuariosPorEmpresa(objUsuario);
            mensagemErroServidor(objUsuario);
            return View(Usuario);
        }
    }
}
