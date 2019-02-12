using System.Collections.Generic;
using Model.Dao;
using Model.Entity;

namespace Model.Business
{
    public class ChamadoBusiness
    {
        private ChamadoDao objChamadoDao;

        public ChamadoBusiness()
        {
            objChamadoDao = new ChamadoDao();
        } 

        public bool buscarPorProtocolo(Chamado objChamado)
        {
            return objChamadoDao.buscarPorProtocolo(objChamado);
        }
               
        public List<Chamado> buscarChamadosAbertos()
        {
            return objChamadoDao.buscarChamadosAbertos();
        }

        public List<Chamado> chamadosAbertosAtendente(int matricula)
        {
            return objChamadoDao.chamadosAbertosAtendente(matricula);
        }

        public List<Chamado> buscarChamadosFinalizados()
        {
            return objChamadoDao.buscarChamadosFinalizados();
        }

        public void abrirChamado(Chamado objChamado)
        {
            bool verificacao = true;

            string descricao = objChamado.DescChamado;
            //Verifica se o campo descricao está vazio
            if (descricao == null)
            {
                objChamado.EstadoCon = 20;
                return;
            }
            else
            {
                descricao = objChamado.DescChamado.Trim();
                verificacao = descricao.Length <= 50 && descricao.Length > 0;
                if (!verificacao)
                {
                    objChamado.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de descrição do chamado

            int usuario = objChamado.Cliente;
            //Verifica se o campo código do cliente está vazio
            if (usuario <= 0)
            {
                objChamado.EstadoCon = 50;
                return;
            }
            //final da validação 


            //se nao tem erro
            objChamado.EstadoCon = 99;
                       
            objChamadoDao.abrirChamado(objChamado);
            return;
        }

        public void finalizarChamado(Chamado objChamado)
        {
            bool verificacao = true;

            string descricao = objChamado.DescSolucao;
            //Verifica se o campo descricao está vazio
            if (descricao == null)
            {
                objChamado.EstadoCon = 20;
                return;
            }
            else
            {
                descricao = objChamado.DescSolucao.Trim();
                verificacao = descricao.Length <= 50 && descricao.Length > 0;
                if (!verificacao)
                {
                    objChamado.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de descrição do chamado

            //se nao tem erro
            objChamado.EstadoCon = 99;                       
            objChamadoDao.finalizarChamado(objChamado);
            return;
        }

        public bool buscarFinalizadoPorProtocolo(Chamado objChamado)
        {
            return objChamadoDao.buscarFinalizadoPorProtocolo(objChamado);
        }

        public List<Chamado> chamadosFinalizadosAtendente(int matricula)
        {
            return objChamadoDao.chamadosFinalizadosAtendente(matricula);
        }
        
        public void alterar(Chamado objChamado)
        {
            bool verificacao;

            //begin validar campo descrição do chamado
            string desc = objChamado.DescChamado;
            if (desc == null)
            {
                objChamado.EstadoCon = 50;
                return;
            }
            else
            {
                desc = objChamado.DescChamado.Trim();
                verificacao = desc.Length <= 50 && desc.Length > 0;
                if (!verificacao)
                {
                    objChamado.EstadoCon = 250;
                    return;
                }

            }
            //end validar descrição do chamado

            //se nao tem erro
            objChamado.EstadoCon = 99;
            objChamadoDao.alterar(objChamado);
            return;
        }
    }
}
