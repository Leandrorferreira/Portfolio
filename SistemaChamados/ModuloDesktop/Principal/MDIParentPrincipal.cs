using Model.Entity;
using ModuloDesktop.Controller;
using System;
using System.Windows.Forms;

namespace ModuloDesktop.Principal
{
    public partial class MDIParentPrincipal : Form
    {
       // private int childFormNumber = 0;

        //Criando objetos de formulários
        FrmPrincipal frmPrincipal;
        FrmAbrirChamado frmAbrirChamado;
        FrmEmpresa frmEmpresa;

        public MDIParentPrincipal()
        {
            InitializeComponent();
            
            //instanciando formularios
            frmPrincipal = new FrmPrincipal();
            frmPrincipal.WindowState = FormWindowState.Maximized; 

            frmAbrirChamado = new FrmAbrirChamado();
            frmAbrirChamado.WindowState = FormWindowState.Maximized;

            frmEmpresa = new FrmEmpresa();
            frmEmpresa.WindowState = FormWindowState.Maximized;
        }
                
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cria um objeto que possui o metodo de sair
            LoginController obj = new LoginController();
            obj.Sair(); //metodo para sair            
            Application.Exit();
        }

        private void abrirChamadoToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            //Chamando o formulario dentro deste MDI             
            frmAbrirChamado.MdiParent = this;
            frmAbrirChamado.Show();
        }

        private void btnLateralAbrir_Click(object sender, EventArgs e)
        {            
            //Chamando o formulario dentro deste MDI 
            frmAbrirChamado.MdiParent = this;
            frmAbrirChamado.Show();
        }

        private void MDIParentPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //Desabilitando controles
            abrirChamadoToolStripMenuItem.Visible = false;
            finalizarChamadoToolStripMenuItem.Visible = false;
            btnLateralAbrir.Visible = false;
            btnLateralFinalizar.Visible = false;
            subItemGerentes.Visible = false;
            subItemAtendente.Visible = false;

            if (Autenticacao.Instancia.Cargo == "Analista" || Autenticacao.Instancia.Cargo == "Adm")
            {
                //Habilitando se tiver permissão de Analista ou Adm
                abrirChamadoToolStripMenuItem.Visible = true;
                finalizarChamadoToolStripMenuItem.Visible = true;
                btnLateralAbrir.Visible = true;
                btnLateralFinalizar.Visible = true;
            }
            if (Autenticacao.Instancia.Cargo == "Gerente" || Autenticacao.Instancia.Cargo == "Adm")
            {
                //Habilitando se tiver permissão de Gerente ou Adm
                subItemAtendente.Visible = true;
            }
            if(Autenticacao.Instancia.Cargo == "Adm")
            {
                subItemGerentes.Visible = true; 
            }

            frmPrincipal.MdiParent = this;
            frmPrincipal.WindowState = FormWindowState.Maximized;
            frmPrincipal.Show();
        }

        private void btnLateralPrincipal_Click(object sender, EventArgs e)
        {
            //Escondendo formularios abertos
            frmAbrirChamado.Hide();
            frmEmpresa.Hide();
            //Mostrando formulário
            frmPrincipal.MdiParent = this;
            frmPrincipal.Show();
        }

        private void MDIParentPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cria um objeto que possui o metodo de sair
            LoginController obj = new LoginController();
            obj.Sair(); //metodo para sair     
            Application.Exit();
        }

        private void subItemEmpresas_Click(object sender, EventArgs e)
        {
            frmAbrirChamado.Hide();
            frmPrincipal.Hide();
            frmEmpresa.MdiParent = this;
            frmEmpresa.Show();  
            
        }             
    }  
}
