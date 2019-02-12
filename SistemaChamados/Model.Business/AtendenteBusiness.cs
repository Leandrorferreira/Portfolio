using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Business
{
    public class AtendenteBusiness
    {
        private AtendenteDao objAtendenteDao;

        public AtendenteBusiness()
        {
            objAtendenteDao = new AtendenteDao();
        }

        public void cadastrar(Atendente objAtendente)
        {
            bool verificacao = true;

            string nome = objAtendente.Nome;
            //Verifica se o campo nome está vazio
            if (nome == null)
            {
                objAtendente.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objAtendente.Nome.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de nome fantasia

            string cpf = objAtendente.Cpf;
            //Verifica se o campo cpf está vazio
            if (cpf == null)
            {
                objAtendente.EstadoCon = 50;
                return;
            }
            else
            {
                cpf = objAtendente.Cpf.Trim();
                verificacao = cpf.Length <= 14 && cpf.Length > 13;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 250;
                    return;
                }

            }
            //final da validação de cpf

            //begin validar função
            string funcao = objAtendente.Funcao;
            if (funcao == null)
            {
                objAtendente.EstadoCon = 60;
                return;
            }
            else
            {
                funcao = objAtendente.Funcao.Trim();
                verificacao = funcao.Length <= 20 && funcao.Length > 0;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 6;
                    return;
                }

            }
            //end validar função

            //begin verificar duplicidade cpf
            Atendente objAtendente1 = new Atendente();
            objAtendente1.Cpf = objAtendente.Cpf;
            verificacao = !objAtendenteDao.buscarAtendentePorCpf(objAtendente1);
            if (!verificacao)
            {
                objAtendente.EstadoCon = 9;
                return;
            }
            //end validar duplicidade cpf                    

            //se nao tem erro
            objAtendente.EstadoCon = 99;
            objAtendenteDao.cadastrar(objAtendente);
            return;
        }

        public void alterar(Atendente objAtendente)
        {
            bool verificacao = true;

            //begin validar nome
            string nome = objAtendente.Nome;
            if (nome == null)
            {
                objAtendente.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objAtendente.Nome.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 2;
                    return;
                }

            }
            //end validar nome

            //begin validar campo cpf 
            string cpf = objAtendente.Cpf;
            if (cpf == null)
            {
                objAtendente.EstadoCon = 50;
                return;
            }
            else
            {
                cpf = objAtendente.Cpf.Trim();
                verificacao = cpf.Length <= 14 && cpf.Length > 13;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 250;
                    return;
                }

            }
            //end validar cpf

            //begin validar função 
            string funcao = objAtendente.Funcao;
            if (funcao == null)
            {
                objAtendente.EstadoCon = 60;
                return;
            }
            else
            {
                funcao = objAtendente.Funcao.Trim();
                verificacao = funcao.Length <= 20 && funcao.Length > 0;
                if (!verificacao)
                {
                    objAtendente.EstadoCon = 6;
                    return;
                }

            }
            //end validar função

            //se nao tem erro
            objAtendente.EstadoCon = 99;
            objAtendenteDao.alterar(objAtendente);
            return;
        }

        public void excluir(Atendente objAtendente)
        {
            bool verificacao = true;
            //verificando se existe
            Atendente objAtendenteAux = new Atendente();
            objAtendenteAux.Matricula = objAtendente.Matricula;
            verificacao = objAtendenteDao.buscar(objAtendenteAux);
            if (!verificacao)
            {
                objAtendente.EstadoCon = 33;
                return;
            }

            //Verifica se o atendente possui algum chamado
            ChamadoDao objChamadoDao = new ChamadoDao();
            if (objChamadoDao.buscarChamadosAtendente(objAtendente.Matricula))
            {
                objAtendente.EstadoCon = 300; //Atendente possui chamados e não pode ser excluido
                return;
            }

            //Se não tem erro
            objAtendente.EstadoCon = 99;
            objAtendenteDao.excluir(objAtendente);

            //Excluir Login relacionado ao atendente que foi excluído
            LoginDao objLogin = new LoginDao();
            objLogin.excluir(objAtendente.Matricula, "Analista");

            return;
        }

        public bool buscar(Atendente objAtendente)
        {
            return objAtendenteDao.buscar(objAtendente);
        }

        public List<Atendente> buscarTudo()
        {
            return objAtendenteDao.buscarTudo();
        }

        public List<Atendente> buscarTudoAtendentes(Atendente objAtendente)
        {
            return objAtendenteDao.buscarTudoAtendente(objAtendente);
        }

        public Atendente buscarPorMatricula(int matricula)
        {
            return objAtendenteDao.buscarPorMatricula(matricula);
        }

        public int buscarMatriculaPorCpf(string cpf)
        {
            int matricula;
            if (cpf == null)
            {
                matricula = -1; //O campo CPF está vazio
            }
            else
            {
                //Atribui a matricula do gerente com base no cpf
                matricula = objAtendenteDao.buscarMatriculaPorCpf(cpf);
            }

            return matricula;
        }
    }
}
