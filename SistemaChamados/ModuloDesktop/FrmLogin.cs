using ModuloDesktop.Controller;
using System;
using System.Windows.Forms;
using ModuloDesktop.Principal;
using Model.Business;
using Model.Entity;

namespace ModuloDesktop
{
    public partial class FrmLogin : Form
    {
        LoginController objLoginController;
        LoginBusiness objLoginBusiness;

        public FrmLogin()
        {
            InitializeComponent();
            objLoginController = new LoginController();
            objLoginBusiness = new LoginBusiness();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Iniciando variaveis da classe Singleton
            Autenticacao.Instancia.Matricula = 0;
            Autenticacao.Instancia.Cargo = string.Empty;

            //criando instancia do formulário principal
            MDIParentPrincipal frm = new MDIParentPrincipal();

            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            //Metodo para verificar se algum campo não foi preenchido
            if(objLoginController.validarCampos(email, senha))
            {
                //Se algum dos campos estiver vazio
                MessageBox.Show("Informe seu e-mail e senha!");
                //Habilitando labels de aviso
                lblAvisoEmail.Visible = true;
                lblAvisoSenha.Visible = true;

                return;
            }
            else
            {
                //Verificar se o Login e Senha existem e estão corretos
                var login = objLoginBusiness.logar(email, senha);
                if (login.EstadoCon == 1)
                {
                    MessageBox.Show("Email e/ou Senha não encontrado(s)!");
                    return;
                }
                else
                {
                    Autenticacao.Instancia.Matricula = login.Matricula;
                    Autenticacao.Instancia.Cargo = login.Cargo;
                    //Chamando formulário principal
                    frm.Show();
                    //Esconde o formulário de login
                    this.Visible = false;              
                }          

            }
             
        }      

    }
}
