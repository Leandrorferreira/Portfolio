using Model.Dao;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Business
{
    public class EmpresaBusiness
    {
        private EmpresaDao objEmpresaDao;

        public EmpresaBusiness()
        {
            objEmpresaDao = new EmpresaDao();
        }

        public void cadastrar(Empresa objEmpresa)
        {
            bool verificacao = true;

            string nome = objEmpresa.NomeFantasia;
            //Verifica se o campo nome fantasia está vazio
            if (nome == null)
            {
                objEmpresa.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objEmpresa.NomeFantasia.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de nome fantasia

            string razao = objEmpresa.RazaoSocial;
            //Verifica se o campo Razão Social está vazio
            if (razao == null)
            {
                objEmpresa.EstadoCon = 30;
                return;
            }
            else
            {
                razao = objEmpresa.RazaoSocial.Trim();
                verificacao = razao.Length <= 50 && razao.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 3;
                    return;
                }

            }
            //final da validação de razão social
            
            //begin validar telefone retorna estado=7
            string telefone = objEmpresa.Telefone;
            if (telefone == null)
            {
                objEmpresa.EstadoCon = 70;
                return;
            }
            else
            {
                telefone = objEmpresa.Telefone.Trim();
                verificacao = telefone.Length <= 14 && telefone.Length > 7;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 7;
                    return;
                }

            }
            //end validar telefone

            string logradouro = objEmpresa.Logradouro;
            //Verifica se o campo Logradouro está vazio
            if (logradouro == null)
            {
                objEmpresa.EstadoCon = 40;
                return;
            }
            else
            {
                logradouro = objEmpresa.Logradouro.Trim();
                verificacao = logradouro.Length <= 30 && logradouro.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 4;
                    return;
                }

            }
            //final da validação de logradouro

            string complemento = objEmpresa.Complemento;
            //Verifica se o campo complemento está vazio
            if (complemento == null)
            {
                objEmpresa.EstadoCon = 25;
                return;
            }
            else
            {
                complemento = objEmpresa.Complemento.Trim();
                verificacao = complemento.Length <= 40 && complemento.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 52;
                    return;
                }

            }
            //final da validação de complemento

            //Validar cidade retorna estadoCon = 6
            string cidade = objEmpresa.Cidade;
            if (cidade == null)
            {
                objEmpresa.EstadoCon = 60;
                return;
            }
            else
            {
                cidade = objEmpresa.Cidade.Trim();
                verificacao = cidade.Length <= 30 && cidade.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 6;
                    return;
                }
            }
            //end validar cidade

            string uf = objEmpresa.Uf;
            //Verifica se o campo UF está vazio
            if (uf == null)
            {
                objEmpresa.EstadoCon = 32;
                return;
            }
            else
            {
                uf = objEmpresa.Uf.Trim();
                verificacao = uf.Length <= 30 && uf.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 23;
                    return;
                }
            }
            //final da validação de Uf

            //begin verificar duplicidade cnpj retorna estado=8
            Empresa objEmpresa1 = new Empresa();
            objEmpresa1.Cnpj = objEmpresa.Cnpj;
            verificacao = !objEmpresaDao.buscarEmpresaPorCnpj(objEmpresa1);
            if (!verificacao)
            {
                objEmpresa.EstadoCon = 9;
                return;
            }
            //end validar duplicidade cnpj
                   
            //inicio da validação do cnpj
            string cnpj = objEmpresa.Cnpj;
            if (cnpj == null)
            {
                objEmpresa.EstadoCon = 50;
                return;
            }
            else
            {
                cnpj = objEmpresa.Cnpj.Trim();
                verificacao = cnpj.Length <= 18 && cnpj.Length > 17;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 250;
                    return;
                }
            }
            //fim da validação do cnpj
                  
            //se nao tem erro
            objEmpresa.EstadoCon = 99;
            objEmpresaDao.cadastrar(objEmpresa);
            return;
        }

        public void alterar(Empresa objEmpresa)
        {
            bool verificacao = true;

            string nome = objEmpresa.NomeFantasia;
            //Verifica se o campo nome fantasia está vazio
            if (nome == null)
            {
                objEmpresa.EstadoCon = 20;
                return;
            }
            else
            {
                nome = objEmpresa.NomeFantasia.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 2;
                    return;
                }

            }
            //final da validação de nome fantasia

            string razao = objEmpresa.RazaoSocial;
            //Verifica se o campo Razão Social está vazio
            if (razao == null)
            {
                objEmpresa.EstadoCon = 30;
                return;
            }
            else
            {
                razao = objEmpresa.RazaoSocial.Trim();
                verificacao = razao.Length <= 50 && razao.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 3;
                    return;
                }

            }
            //final da validação de razão social

            //begin validar telefone retorna estado=7
            string telefone = objEmpresa.Telefone;
            if (telefone == null)
            {
                objEmpresa.EstadoCon = 70;
                return;
            }
            else
            {
                telefone = objEmpresa.Telefone.Trim();
                verificacao = telefone.Length <= 14 && telefone.Length > 7;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 7;
                    return;
                }

            }
            //end validar telefone

            string logradouro = objEmpresa.Logradouro;
            //Verifica se o campo Logradouro está vazio
            if (logradouro == null)
            {
                objEmpresa.EstadoCon = 40;
                return;
            }
            else
            {
                logradouro = objEmpresa.Logradouro.Trim();
                verificacao = logradouro.Length <= 30 && logradouro.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 4;
                    return;
                }

            }
            //final da validação de logradouro

            string complemento = objEmpresa.Complemento;
            //Verifica se o campo complemento está vazio
            if (complemento == null)
            {
                objEmpresa.EstadoCon = 25;
                return;
            }
            else
            {
                complemento = objEmpresa.Complemento.Trim();
                verificacao = complemento.Length <= 40 && complemento.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 52;
                    return;
                }

            }
            //final da validação de complemento

            //Validar cidade retorna estadoCon = 6
            string cidade = objEmpresa.Cidade;
            if (cidade == null)
            {
                objEmpresa.EstadoCon = 60;
                return;
            }
            else
            {
                cidade = objEmpresa.Cidade.Trim();
                verificacao = cidade.Length <= 30 && cidade.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 6;
                    return;
                }
            }
            //end validar cidade

            string uf = objEmpresa.Uf;
            //Verifica se o campo UF está vazio
            if (uf == null)
            {
                objEmpresa.EstadoCon = 32;
                return;
            }
            else
            {
                uf = objEmpresa.Uf.Trim();
                verificacao = uf.Length <= 30 && uf.Length > 0;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 23;
                    return;
                }
            }
            //final da validação de Uf

            //inicio da validação do cnpj
            string cnpj = objEmpresa.Cnpj;
            if (cnpj == null)
            {
                objEmpresa.EstadoCon = 50;
                return;
            }
            else
            {
                cnpj = objEmpresa.Cnpj.Trim();
                verificacao = cnpj.Length <= 18 && cnpj.Length > 17;
                if (!verificacao)
                {
                    objEmpresa.EstadoCon = 250;
                    return;
                }
            }
            //fim da validação do cnpj


            //se nao tem erro
            objEmpresa.EstadoCon = 99;
            objEmpresaDao.alterar(objEmpresa);
            return;
        }

        public void excluir(Empresa objEmpresa)
        {
            bool verificacao = true;
            //verificando se existe
            Empresa objEmpresaAux = new Empresa();
            objEmpresaAux.CodEmpresa = objEmpresa.CodEmpresa;
            verificacao = objEmpresaDao.buscar(objEmpresaAux);
            if (!verificacao)
            {
                objEmpresa.EstadoCon = 33;
                return;
            }

            //Verifica se a empresa possui algum funcionário (usuário)
            UsuarioDao objUsuarioDao = new UsuarioDao();
            if (objUsuarioDao.buscarEmpresaUsuario(objEmpresa.CodEmpresa))
            {
                objEmpresa.EstadoCon = 300; //Empresa possui funcionários e não pode ser excluido
                return;
            }

            //Se não tem erro
            objEmpresa.EstadoCon = 99;
            objEmpresaDao.excluir(objEmpresa); 
            return;
        }

        public bool buscar(Empresa objEmpresa)
        {
            return objEmpresaDao.buscar(objEmpresa);
        }

        public List<Empresa> buscarTudo()
        {
            return objEmpresaDao.buscarTudo();
        }

        public List<Empresa> buscarTudoEmpresas(Empresa objEmpresa)
        {
            return objEmpresaDao.buscarTudoEmpresa(objEmpresa);
        }

        public string buscarNomeEmpresa(int cod)
        {
            return objEmpresaDao.buscarNomeEmpresa(cod);
        }

        public Empresa buscarEmpresaPorCod(int cod)
        {
            return objEmpresaDao.buscarEmpresaPorCod(cod);
        }
    }
}
