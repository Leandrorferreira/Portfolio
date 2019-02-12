using Model.Business;
using Model.Entity;
using ModuloDesktop.Controller;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ModuloDesktop.Principal
{
    public partial class FrmEmpresa : Form
    {        
        EmpresaBusiness objEmpresaBusiness;
        EmpresaController objEmpresaController = new EmpresaController();
        Empresa empresa = new Empresa();

        public FrmEmpresa()
        {
            InitializeComponent();          
            objEmpresaBusiness = new EmpresaBusiness();           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            loadAllBusca();
            var listaEmpresas = objEmpresaBusiness.buscarTudo();
            foreach (var s in listaEmpresas)
            {
                cboEmpresas.Items.Add(s.NomeFantasia);
            }

            cboEmpresas.Text = "[Selecione]";
            tpEmpresa.SelectTab("tbBuscar");
        }
            

        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            //Carrega a lista de empresas do banco de dados
            loadAll();
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        //Atualiza a lista de empresas
        public void loadAll()
        {
            datagridListaEmpresas.AutoGenerateColumns = false;
            datagridListaEmpresas.DataSource = objEmpresaBusiness.buscarTudo();           
        }

        //Atualiza a lista de empresas na tela de busca
        public void loadAllBusca()
        {
            datagridListaEmpresas2.AutoGenerateColumns = false;
            datagridListaEmpresas2.DataSource = objEmpresaBusiness.buscarTudo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbExcluir");
            foreach (DataGridViewRow row in datagridListaEmpresas.SelectedRows)
            {
                empresa = ((Empresa)row.DataBoundItem);
            }

            if (empresa == null)
            {
                MessageBox.Show("Selecione uma linha!");
                return;
            }
            //Pesquisando empresa com base no Telefone
            var empresaSelecionada = objEmpresaBusiness.buscarTudo().Where(p => p.Telefone == empresa.Telefone).FirstOrDefault();

            //Preencher os dados do form
            txtNome_Excluir.Text = empresaSelecionada.NomeFantasia;
            txtRazao_Excluir.Text = empresaSelecionada.RazaoSocial;
            txtTelefone_Excluir.Text = empresaSelecionada.Telefone;
            txtCNPJ_Excluir.Text = empresaSelecionada.Cnpj;
            txtLogradouro_Excluir.Text = empresaSelecionada.Logradouro;
            txtComplemento_Excluir.Text = empresaSelecionada.Complemento;
            txtCidade_Excluir.Text = empresaSelecionada.Cidade;
            txtUF_Excluir.Text = empresaSelecionada.Uf;
            tpEmpresa.SelectTab("tbExcluir");
        }
                        
        //Função para limpar os campos do formulário de cadastro após cadastrar empresa
        public void limparCamposCadastro()
        {
            txtCNPJ_Novo.Text = "";
            txtRazaoSocial.Text = "";
            txtNomeFantasia.Text = "";
            txtTelefone.Text = "";
            txtLogradouro.Text = "";
            txtComplemento.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
        }
               
        private void btnVoltar_Detalhes_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            lblEmpresas.Text = "";
            foreach (DataGridViewRow row in datagridListaEmpresas.SelectedRows)
            {
                empresa = ((Empresa)row.DataBoundItem);
            }

            if(empresa.NomeFantasia == null)
            {
                MessageBox.Show("Selecione uma linha!");
                return;
            }
            //Pesquisando empresa com base no Telefone
            var empresaSelecionada = objEmpresaBusiness.buscarTudo().Where(p => p.Telefone == empresa.Telefone).FirstOrDefault();
                       
            //Preencher os dados do form
            txtNome_Detalhes.Text = empresaSelecionada.NomeFantasia;
            txtRazao_Detalhes.Text = empresaSelecionada.RazaoSocial;
            txtTelefone_Detalhes.Text = empresaSelecionada.Telefone;
            txtCnpj_Detalhes.Text = empresaSelecionada.Cnpj;
            txtLogradouro_Detalhes.Text = empresaSelecionada.Logradouro;
            txtComplemento_Detalhes.Text = empresaSelecionada.Complemento;
            txtCidade_Detalhes.Text = empresaSelecionada.Cidade;
            txtUf_Detalhes.Text = empresaSelecionada.Uf;
            lblEmpresas.Text += "Empresa / " + empresaSelecionada.NomeFantasia;
            tpEmpresa.SelectTab("tbDetalhes");
        }

        private void btnVoltar_Excluir_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        private void BtnVoltar_Buscar_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cnpj = txtCNPJ.Text;

            if (nome == "" && cnpj == "")
            {
                MessageBox.Show("Informe um nome ou CNPJ!!!");
            }
            else
            {
                Empresa objEmpresa = new Empresa()
                {
                    NomeFantasia = nome,
                    Cnpj = cnpj
                };

                var lista = objEmpresaBusiness.buscarTudoEmpresas(objEmpresa);
                datagridListaEmpresas2.AutoGenerateColumns = false;
                datagridListaEmpresas2.DataSource = lista;
                txtNome.Text = "";
                txtCNPJ.Text = "";
            }
        }

        private void btnExcluir_Excluir_Click(object sender, EventArgs e)
        {        

            //Excluir a empresa selecionada
            objEmpresaBusiness.excluir(empresa);
                        
            if(empresa.EstadoCon == 99)
            {
                MessageBox.Show("A empresa " + empresa.NomeFantasia + " foi excluída!");
            }
            else
            {
                MessageBox.Show("Erro ao tentar excluir, entre em contato conosco!");
            }
            //Atualiza a lista de empresas
            loadAll();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagridListaEmpresas.SelectedRows)
            {
                empresa = ((Empresa)row.DataBoundItem);
            }

            if (empresa == null)
            {
                MessageBox.Show("Selecione uma linha!");
                return;
            }
            //Pesquisando empresa com base no Telefone
            var empresaSelecionada = objEmpresaBusiness.buscarTudo().Where(p => p.Telefone == empresa.Telefone).FirstOrDefault();

            //Preencher os dados do form
            txtNome_Excluir.Text = empresaSelecionada.NomeFantasia;
            txtRazao_Excluir.Text = empresaSelecionada.RazaoSocial;
            txtTelefone_Excluir.Text = empresaSelecionada.Telefone;
            txtCNPJ_Excluir.Text = empresaSelecionada.Cnpj;
            txtLogradouro_Excluir.Text = empresaSelecionada.Logradouro;
            txtComplemento_Excluir.Text = empresaSelecionada.Complemento;
            txtCidade_Excluir.Text = empresaSelecionada.Cidade;
            txtUF_Excluir.Text = empresaSelecionada.Uf;            
            tpEmpresa.SelectTab("tbExcluir");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datagridListaEmpresas.SelectedRows)
            {
                empresa = ((Empresa)row.DataBoundItem);
            }

            if (empresa == null)
            {
                MessageBox.Show("Selecione uma linha!");
                return;
            }
            //Pesquisando empresa com base no Telefone
            var empresaSelecionada = objEmpresaBusiness.buscarTudo().Where(p => p.Telefone == empresa.Telefone).FirstOrDefault();

            //Preencher os dados do form

            txtMatricula.Text = Convert.ToString(empresaSelecionada.CodEmpresa);
            txtNome_Editar.Text = empresaSelecionada.NomeFantasia;
            txtRazao_Editar.Text = empresaSelecionada.RazaoSocial;
            txtTelefone_Editar.Text = empresaSelecionada.Telefone;
            txtCnpj_Editar.Text = empresaSelecionada.Cnpj;
            txtLogradouro_Editar.Text = empresaSelecionada.Logradouro;
            txtComplemento_Editar.Text = empresaSelecionada.Complemento;
            txtCidade_Editar.Text = empresaSelecionada.Cidade;
            txtUf_Editar.Text = empresaSelecionada.Uf;       
            tpEmpresa.SelectTab("tbEditar");
        }

        private void btnVoltar_Novo_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        private void btnSalvar_Novo_Click(object sender, EventArgs e)
        {
            string cnpj = txtCNPJ_Novo.Text;
            string razaoSocial = txtRazaoSocial.Text;
            string nomeFantasia = txtNomeFantasia.Text;
            string telefone = txtTelefone.Text;
            string logradouro = txtLogradouro.Text;
            string complemento = txtComplemento.Text;
            string cidade = txtCidade.Text;
            string uf = txtUF.Text;

            //Validar campos
            //Se não estiver vazio, tentar cadastrar
            if (!objEmpresaController.validarCampos(cnpj, razaoSocial, nomeFantasia, telefone, logradouro, complemento, cidade, uf))
            {
                //Criando um objeto de empresa e passando valores para as propriedades
                Empresa objEmpresa = new Empresa()
                {
                    Cnpj = cnpj,
                    RazaoSocial = razaoSocial,
                    NomeFantasia = nomeFantasia,
                    Telefone = telefone,
                    Logradouro = logradouro,
                    Complemento = complemento,
                    Cidade = cidade,
                    Uf = uf
                };

                var mensagem = objEmpresaController.cadastrar(objEmpresa);
                //Limpa os campos do formulário
                limparCamposCadastro();

                //Atualiza a lista de empresas
                loadAll();

                //Exibe o retorno da tentativa de cadastro
                MessageBox.Show(mensagem);

            }
            else
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório!");
            }

        }

        private void btnVoltar_Editar_Click(object sender, EventArgs e)
        {
            tpEmpresa.SelectTab("tbListaEmpresa");
        }

        private void btnSalvar_Editar_Click(object sender, EventArgs e)
        {
            int matricula = Convert.ToInt32(txtMatricula.Text); 
            string razaoSocial = txtRazao_Editar.Text;
            string nomeFantasia = txtNome_Editar.Text;
            string cnpj = txtCnpj_Editar.Text;
            string telefone = txtTelefone_Editar.Text;
            string logradouro = txtLogradouro_Editar.Text;
            string complemento = txtComplemento_Editar.Text;
            string cidade = txtCidade_Editar.Text;
            string uf = txtUf_Editar.Text;

            //Validar campos
            //Se não estiver vazio, tentar alterar
            if (!objEmpresaController.validarCampos(cnpj, razaoSocial, nomeFantasia, telefone, logradouro, complemento, cidade, uf))
            {
                //Criando um objeto de empresa e passando valores para as propriedades
                Empresa objEmpresa = new Empresa()
                {
                    CodEmpresa = matricula,
                    Cnpj = cnpj,
                    RazaoSocial = razaoSocial,
                    NomeFantasia = nomeFantasia,
                    Telefone = telefone,
                    Logradouro = logradouro,
                    Complemento = complemento,
                    Cidade = cidade,
                    Uf = uf
                };

                var mensagem = objEmpresaController.alterar(objEmpresa);
                //Limpa os campos do formulário
                limparCamposCadastro();

                //Atualiza a lista de empresas
                loadAll();

                //Exibe o retorno da tentativa de cadastro
                MessageBox.Show(mensagem);
            }
            else
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório!");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparCamposCadastro();
            tpEmpresa.SelectTab("tbCadastrar");
        }

        private void btnBuscar_Lista_Click(object sender, EventArgs e)
        {
            loadAllBusca();
            var listaEmpresas = objEmpresaBusiness.buscarTudo();
            foreach (var s in listaEmpresas)
            {
                cboEmpresas.Items.Add(s.NomeFantasia);
            }

            cboEmpresas.Text = "[Selecione]";
            tpEmpresa.SelectTab("tbBuscar");
        }       
    }
}
