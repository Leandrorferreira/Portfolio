using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Business
{
    public class GerenteBusiness
    {
        private GerenteDao objGerenteDao;

        public GerenteBusiness()
        {
            objGerenteDao = new GerenteDao();
        }

        public void cadastrar(Gerente objGerente)
        {
            bool verificacao = true;

            string nome = objGerente.Nome;
            //Verifica se o campo nome está vazio
            if (nome == null)
            {
                objGerente.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objGerente.Nome.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objGerente.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de nome fantasia

            string cpf = objGerente.Cpf;
            //Verifica se o campo cpf está vazio
            if (cpf == null)
            {
                objGerente.EstadoCon = 50;
                return;
            }
            else
            {
                cpf = objGerente.Cpf.Trim();
                verificacao = cpf.Length <= 14 && cpf.Length > 13;
                if (!verificacao)
                {
                    objGerente.EstadoCon = 250;
                    return;
                }

            }
            //final da validação de cpf


            //begin verificar duplicidade cpf
            Gerente objGerente1 = new Gerente();
            objGerente1.Cpf = objGerente.Cpf;
            verificacao = !objGerenteDao.buscarGerentePorCpf(objGerente1);
            if (!verificacao)
            {
                objGerente.EstadoCon = 9;
                return;
            }
            //end validar duplicidade cpf                    

            //se nao tem erro
            objGerente.EstadoCon = 99;
            objGerenteDao.cadastrar(objGerente);
            return;
        }

        public void alterar(Gerente objGerente)
        {
            bool verificacao = true;

            //begin validar nome
            string nome = objGerente.Nome;
            if (nome == null)
            {
                objGerente.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objGerente.Nome.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objGerente.EstadoCon = 2;
                    return;
                }
            }
            //end validar nome

            //begin validar campo cpf 
            string cpf = objGerente.Cpf;
            if (cpf == null)
            {
                objGerente.EstadoCon = 50;
                return;
            }
            else
            {
                cpf = objGerente.Cpf.Trim();
                verificacao = cpf.Length <= 14 && cpf.Length > 13;
                if (!verificacao)
                {
                    objGerente.EstadoCon = 250;
                    return;
                }

            }
            //end validar cpf

            //se nao tem erro
            objGerente.EstadoCon = 99;
            objGerenteDao.alterar(objGerente);
            return;
        }

        public void excluir(Gerente objGerente)
        {
            bool verificacao = true;
            //verificando se existe
            Gerente objGerenteAux = new Gerente();
            objGerenteAux.Matricula = objGerente.Matricula;
            verificacao = objGerenteDao.buscar(objGerenteAux);
            if (!verificacao)
            {
                objGerente.EstadoCon = 33;
                return;
            }
            //Se não tem erro
            objGerente.EstadoCon = 99;
            objGerenteDao.excluir(objGerente);

            //Excluir Login relacionado ao gerente que foi excluído
            LoginDao objLogin = new LoginDao();
            objLogin.excluir(objGerente.Matricula, "Gerente");

            return;
        }

        public bool buscar(Gerente objGerente)
        {
            return objGerenteDao.buscar(objGerente);
        }

        public List<Gerente> buscarTudo()
        {
            return objGerenteDao.buscarTudo();
        }

        public List<Gerente> buscarTudoGerentes(Gerente objGerente)
        {
            return objGerenteDao.buscarTudoGerente(objGerente);
        }

        public int buscarMatriculaPorCpf(string cpf)
        {
            int matricula;
            if(cpf == null)
            {
                matricula = -1; //O campo CPF está vazio
            }
            else
            {
                //Atribui a matricula do gerente com base no cpf
                matricula = objGerenteDao.buscarMatriculaPorCpf(cpf);
            }

            return matricula;
        }
    }
}
