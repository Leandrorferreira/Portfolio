using Model.Business;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ModuloWeb.Controllers
{
    public class ChamadoController : Controller
    {
        //Declaração dos objetos da classe de regras de negócio
        UsuarioBusiness objUsuarioBusiness;
        AtendenteBusiness objAtendenteBusiness;
        ChamadoBusiness objChamadoBusiness;

        //Metodo Construtor inicializando objetos da classe de regras de negócio
        public ChamadoController()
        {
            objUsuarioBusiness = new UsuarioBusiness();
            objChamadoBusiness = new ChamadoBusiness();
            objAtendenteBusiness = new AtendenteBusiness();
        }

        [HttpPost]
        public ActionResult Selecionar(string cpf)
        {
            cpf = cpf.Trim();
            Usuario objUsuario = new Usuario();
            objUsuario = objUsuarioBusiness.findUsuarioCpf(cpf);

            //Buscar Nome da Empresa com base no Código
            EmpresaBusiness objEmpresaBusiness = new EmpresaBusiness();
            string nomeEmpresa = objEmpresaBusiness.buscarNomeEmpresa(objUsuario.CodEmpresa);

            //Criando uma variavel para retornar os dados via JSON
            var resultado = new
            {      
                Empresa =   nomeEmpresa,
                NomeUsuario = objUsuario.Nome,  
                Matricula = objUsuario.Matricula,
                Ramal_Usuario = objUsuario.Ramal
       
            };          
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AbrirChamado()
        {            
            return View();
        }

        public ActionResult ConsultarChamado()
        {
            //Buscando uma lista de chamados abertos de um determinado atendente com base na matricula
            List<Chamado> lista = objChamadoBusiness.chamadosAbertosAtendente(Autenticacao.Instancia.Matricula);
           
            UsuarioBusiness objUsuarioBusiness = new UsuarioBusiness();
            List<Usuario> listaCliente = new List<Usuario>();
            foreach (var item in lista)
            {
                listaCliente.Add(objUsuarioBusiness.buscarPorMatricula(item.Cliente));
            }
            //Retorna uma lista de clientes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaCliente = listaCliente;

            AtendenteBusiness objAtendenteBusiness = new AtendenteBusiness();
            List<Atendente> listaAtendente = new List<Atendente>();
            foreach (var item in lista)
            {
                listaAtendente.Add(objAtendenteBusiness.buscarPorMatricula(item.Atendente));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaAtendente = listaAtendente;
           
            return View(lista);
        }

        [HttpPost]
        public ActionResult SalvarChamado(string Descricao, string IdUsuario)
        {
            string mensagem = "";
            int idusuario = 0;           

            if (Descricao == "" || IdUsuario == "")
            {
                mensagem = "Informe a Descrição da Solução!";
            }
            else
            {           
                //Convertendo o valor da matricula do usuário
                idusuario = Convert.ToInt32(IdUsuario);
               
                //REGISTRO
                Chamado objChamado = new Chamado();
                objChamado.Atendente = Autenticacao.Instancia.Matricula;
                objChamado.Cliente = idusuario;
                objChamado.DescChamado = Descricao;
                objChamado.DescSolucao = "";
                objChamado.Estatus = "Aberto";
                objChamado.DataAbertura = DateTime.Now;
                try
                {
                    objChamadoBusiness.abrirChamado(objChamado);
                    mensagem = "Chamado aberto com Sucesso!";                 
                }
                catch
                {
                    mensagem = "Erro ao tentar finalizar!";
                 
                }
                
            }
            return Json(mensagem);

        }

        [HttpGet]
        public ActionResult Finalizar(int id)
        {          

            Chamado objChamado = new Chamado(id);            
            objChamadoBusiness.buscarPorProtocolo(objChamado);

            List<Usuario> data = objUsuarioBusiness.findAll();
            SelectList Cliente = new SelectList(data, "Matricula", "Nome");
            ViewBag.Cliente = Cliente;
                        
            List<Atendente> data2 = objAtendenteBusiness.buscarTudo();
            SelectList Atendente = new SelectList(data2, "Matricula", "Nome");
            ViewBag.Atendente = Atendente;

            return View(objChamado); //Retorna um chamado com base no Protocolo
        }

  
        [HttpPost]
        public ActionResult Finalizar(Chamado objChamado)
        {
            List<Usuario> data = objUsuarioBusiness.findAll();
            SelectList Cliente = new SelectList(data, "Matricula", "Nome");
            ViewBag.Cliente = Cliente;

            List<Atendente> data2 = objAtendenteBusiness.buscarTudo();
            SelectList Atendente = new SelectList(data2, "Matricula", "Nome");
            ViewBag.Atendente = Atendente;

            if (objChamado.DescSolucao == null)
            {
                ViewBag.MensagemErro = "Informe a solução do chamado!";
            }
            else
            {

                try
                {
                    var chamado = objChamadoBusiness.buscarPorProtocolo(objChamado);
                    objChamado.Estatus = "Fechado";
                    objChamado.DataFinalizacao = DateTime.Now;
                    objChamadoBusiness.finalizarChamado(objChamado);
                    ViewBag.MensagemExito = "O chamado foi finalizado com sucesso!";
                }
                catch
                {
                    ViewBag.MensagemErro = "Erro ao tentar finalizar o chamado!";
                }
            }
                      
            return View(objChamado);
        }

        public ActionResult ConsultarChamadoAberto()
        {
            List<Chamado> lista = null;
            //Se o usuário for um gerente, pode consultar todos os chamados abertos
            if (Autenticacao.Instancia.Cargo == "Gerente" || Autenticacao.Instancia.Cargo == "Adm")
            {
                lista = objChamadoBusiness.buscarChamadosAbertos();
            }
            else
            {
                lista = objChamadoBusiness.chamadosAbertosAtendente(Autenticacao.Instancia.Matricula);
            }

            UsuarioBusiness objUsuarioBusiness = new UsuarioBusiness();
            List<Usuario> listaCliente = new List<Usuario>();
            foreach (var item in lista)
            {
                listaCliente.Add(objUsuarioBusiness.buscarPorMatricula(item.Cliente));
            }                        
            //Retorna uma lista de clientes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaCliente = listaCliente;

            AtendenteBusiness objAtendenteBusiness = new AtendenteBusiness();
            List<Atendente> listaAtendente = new List<Atendente>();
            foreach (var item in lista)
            {
                listaAtendente.Add(objAtendenteBusiness.buscarPorMatricula(item.Atendente));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaAtendente = listaAtendente;

            return View(lista);
        }

        public ActionResult ConsultarChamadoFechado()
        {
            List<Chamado> lista = null;
            //Se o usuário for um gerente, pode consultar todos os chamados abertos
            if (Autenticacao.Instancia.Cargo == "Gerente" || Autenticacao.Instancia.Cargo == "Adm")
            {
                lista = objChamadoBusiness.buscarChamadosFinalizados();
            }
            else
            {
                lista = objChamadoBusiness.chamadosFinalizadosAtendente(Autenticacao.Instancia.Matricula);
            }
                        
            UsuarioBusiness objUsuarioBusiness = new UsuarioBusiness();
            List<Usuario> listaCliente = new List<Usuario>();
            foreach (var item in lista)
            {
                //Adiciona um cliente com base na matricula a uma lista de clientes
                listaCliente.Add(objUsuarioBusiness.buscarPorMatricula(item.Cliente));
            }
            //Retorna uma lista de clientes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaCliente = listaCliente;

            AtendenteBusiness objAtendenteBusiness = new AtendenteBusiness();
            List<Atendente> listaAtendente = new List<Atendente>();
            foreach (var item in lista)
            {
                listaAtendente.Add(objAtendenteBusiness.buscarPorMatricula(item.Atendente));
            }
            //Retorna uma lista de atendentes com base na matricula cadastrada em cada chamado aberto
            ViewBag.ListaAtendente = listaAtendente;

            return View(lista);
        }

        //Retorna uma lista de detalhes do chamado finalizado
        [HttpGet]
        public ActionResult Detalhes(int id)
        {

            Chamado objChamado = new Chamado(id);
            objChamadoBusiness.buscarFinalizadoPorProtocolo(objChamado);

            Usuario Cliente = objUsuarioBusiness.buscarPorMatricula(objChamado.Cliente);
            ViewBag.Cliente = Cliente.Nome;

            Atendente Atendente = objAtendenteBusiness.buscarPorMatricula(objChamado.Atendente);            
            ViewBag.Atendente = Atendente.Nome;

            return View(objChamado); //Retorna um chamado com base no Protocolo
        }

        [HttpGet]
        public ActionResult Update(int id)
        {           
            Chamado objChamado = new Chamado(id);
            objChamadoBusiness.buscarPorProtocolo(objChamado);
            return View(objChamado);
        }

        [HttpPost]
        public ActionResult Update(Chamado objChamado)
        {
            
            objChamadoBusiness.alterar(objChamado);
            MensagemErroAtualizar(objChamado);
            return View();

        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Chamado objChamado)
        {
            switch (objChamado.EstadoCon)
            {                

                case 50://campo vazio
                    ViewBag.MensagemErro = "Informe uma descrição";
                    break;

                case 250://quantidade de números do campo cpf
                    ViewBag.MensagemErro = "O campo Descrição deve ter até 50 caracteres!";
                    break;

                case 99://Atualizado com sucesso
                    ViewBag.MensagemExito = "Dados do chamado Nº " + objChamado.Protocolo + " foram atualizados!";
                    break;
            }

        }
    }
}