using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloDesktop.Controller
{
    public class LoginController
    {

        //Verificar se email ou senha estão vazios
        public bool validarCampos(string email, string senha)
        {
            bool vazio = false;

            if((email == "" || email == null) || (senha == "" || senha == null))
            {
                vazio = true;
            }
            
            return vazio;
        }

        public void Sair()
        {
            Autenticacao.Instancia.Matricula = 0;
            Autenticacao.Instancia.Cargo = string.Empty;
        }
    }
}
