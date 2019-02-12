using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class LoginBusiness
    {
        private LoginDao objLoginDao;

        public LoginBusiness()
        {
            objLoginDao = new LoginDao();
        }

        public void alterar(Login objLogin)
        {
            
            //Validando campo senha
            string senha = objLogin.Senha;
            if(senha == null)
            {
                objLogin.EstadoCon = 20; //Campo senha está vazio
                return;
            }

            objLoginDao.alterar(objLogin);
            return;         
        }

        public Login logar(string email, string senha)
        {
            Login objLogin = new Login();

            if(email == null)
            {
                objLogin.EstadoCon = 10; //Campo email está vazio
                return objLogin;
            }

            if(senha == null)
            {
                objLogin.EstadoCon = 20; //Campo senha está vazio
                return objLogin;
            }
                        
            return objLoginDao.logar(email, senha);
        }

        public void cadastrar(Login objLogin)
        {
            
            //Validando campo Email
            string email = objLogin.Email;
            if (email == null)
            {
                objLogin.EstadoCon = 10; //Campo email está vazio
                return;
            }
            
            //Validando campo senha
            string senha = objLogin.Senha;
            if (senha == null)
            {
                objLogin.EstadoCon = 20; //Campo senha está vazio
                return;
            }

            //Se estiver tudo certo, chama o metodo cadastrar
            objLoginDao.cadastrar(objLogin);
            return;
        }

        public Login buscarDadosLogin(int matricula, string cargo)
        {
            return objLoginDao.buscarDadosLogin(matricula, cargo);
        }
    }
}
