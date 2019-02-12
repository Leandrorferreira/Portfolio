using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Business
{
    public class UsuarioBusiness
    {
        private UsuarioDao objUsuarioDao;
       
        //Metodo Construtor
        public UsuarioBusiness()
        {
            //Instanciando objeto
            objUsuarioDao = new UsuarioDao();
        }

        public void cadastrar(Usuario objUsuario)
        {
            bool verificacao = true;

            //inicio verificacion de nome estado=2
            string nome = objUsuario.Nome;
            if (nome == null)
            {
                objUsuario.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objUsuario.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 50;
                if (!verificacao)
                {
                    objUsuario.EstadoCon = 2;
                    return;
                }
            }
            //fim 

            //inicio verificacao de cpf 
            string cpf = objUsuario.Cpf;
            if (cpf == null)
            {
                objUsuario.EstadoCon = 40;
                return;
            }
            else
            {
                cpf = objUsuario.Cpf.Trim();
                verificacao = cpf.Length > 13 && cpf.Length <= 14;
                if (!verificacao)
                {
                    objUsuario.EstadoCon = 4;
                    return;
                }
            }
            //fim
            string ramal = objUsuario.Ramal;
            if (ramal == null)
            {
                objUsuario.EstadoCon = 30;
                return;
            }
            else
            {
                ramal = objUsuario.Ramal.Trim();
                verificacao = ramal.Length > 0 && ramal.Length <= 12;
                if (!verificacao)
                {
                    objUsuario.EstadoCon = 3;
                    return;
                }
            }
            //fim 

            //verificacao de duplicidade
            Usuario objUsuarioAux = new Usuario();
            objUsuarioAux.Cpf = objUsuario.Cpf;
            verificacao = !objUsuarioDao.buscarCpf(objUsuarioAux);
            if (!verificacao)
            {
                objUsuario.EstadoCon = 8;
                return;
            }
            //fim

            //se tudo tiver ok salva
            objUsuario.EstadoCon = 99;
            objUsuarioDao.cadastrar(objUsuario);
            return;
        }

        public void alterar(Usuario objUsuario)
        {
            bool verificacao = true;

            //inicio verificacion de nome
            string nome = objUsuario.Nome;
            if (nome == null)
            {
                objUsuario.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objUsuario.Nome.Trim();
                verificacao = nome.Length > 0 && nome.Length <= 50;
                if (!verificacao)
                {
                    objUsuario.EstadoCon = 2;
                    return;
                }
            }
            //fim 
                       
            //inicio verificacao de cpf
            string cpf = objUsuario.Cpf;
            if (cpf == null)
            {
                objUsuario.EstadoCon = 40;
                return;
            }
            else
            {
                cpf = objUsuario.Cpf.Trim();
                verificacao = cpf.Length > 13 && cpf.Length <= 14;
                if (!verificacao)
                {
                    objUsuario.EstadoCon = 4;
                    return;
                }
            }
            //fim

            //tudo ok edite
            objUsuario.EstadoCon = 99;
            objUsuarioDao.alterar(objUsuario);
            return;
        }

        public void delete(Usuario objUsuario)
        {
            bool verificacao = true;
            //verificão de existencia
            Usuario objUsuarioAux = new Usuario();
            objUsuarioAux.Matricula = objUsuario.Matricula;
            verificacao = objUsuarioDao.buscar(objUsuarioAux);
            if (!verificacao)
            {
                objUsuario.EstadoCon = 33;
                return;
            }

            //Verifica se o usuário possui algum chamado
            ChamadoDao objChamadoDao = new ChamadoDao();
            if (objChamadoDao.buscarChamadosUsuario(objUsuario.Matricula))
            {
                objUsuario.EstadoCon = 300; //Usuário possui chamados e não pode ser excluido
                return;
            }

            //tudo ok
            objUsuario.EstadoCon = 99;
            objUsuarioDao.excluir(objUsuario);
            return;

        }

        public bool buscar(Usuario objUsuario)
        {
            return objUsuarioDao.buscar(objUsuario);
        }

        public List<Usuario> findAll()
        {
            return objUsuarioDao.buscarTudo();
        }

        public List<Usuario> findUsuarioPorCpf(Usuario objUsuario)
        {
            return objUsuarioDao.findUsuarioPorCpf(objUsuario);
        }

        public Usuario findUsuarioCpf(string cpf)
        {
            return objUsuarioDao.findUsuarioCpf(cpf);
        }

        public List<Usuario> findAllUsuarios(Usuario objUsuario)
        {
            return objUsuarioDao.findAllUsuarios(objUsuario);
        }

        public List<Usuario> findAllUsuariosPorEmpresa(Usuario objUsuario)
        {
            return objUsuarioDao.findAllUsuariosPorEmpresa(objUsuario);
        }

        public Usuario buscarPorMatricula(int matricula)
        {
            return objUsuarioDao.buscarPorMatricula(matricula);
        }
    }
}
