namespace ModuloDesktop.Principal
{
    partial class MDIParentPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParentPrincipal));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsOpcoes = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirChamadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalizarChamadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsQuemSomos = new System.Windows.Forms.ToolStripMenuItem();
            this.cHAMADOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuLateral = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLateralPrincipal = new System.Windows.Forms.ToolStripButton();
            this.btnLateralAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnLateralFinalizar = new System.Windows.Forms.ToolStripButton();
            this.subLateralChamados = new System.Windows.Forms.ToolStripDropDownButton();
            this.subItemAbertos = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemFinalizados = new System.Windows.Forms.ToolStripMenuItem();
            this.subLateralAdm = new System.Windows.Forms.ToolStripDropDownButton();
            this.subItemAtendente = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.subItemGerentes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip.SuspendLayout();
            this.tsMenuLateral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpcoes,
            this.tsInicio,
            this.tsQuemSomos,
            this.cHAMADOSToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip.ShowItemToolTips = true;
            this.menuStrip.Size = new System.Drawing.Size(738, 60);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsOpcoes
            // 
            this.tsOpcoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.abrirChamadoToolStripMenuItem,
            this.finalizarChamadoToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.tsOpcoes.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsOpcoes.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsOpcoes.Image = global::ModuloDesktop.Properties.Resources._17;
            this.tsOpcoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsOpcoes.Name = "tsOpcoes";
            this.tsOpcoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsOpcoes.Size = new System.Drawing.Size(40, 56);
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D9)));
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // abrirChamadoToolStripMenuItem
            // 
            this.abrirChamadoToolStripMenuItem.Name = "abrirChamadoToolStripMenuItem";
            this.abrirChamadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.abrirChamadoToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.abrirChamadoToolStripMenuItem.Text = "Abrir Chamado";
            this.abrirChamadoToolStripMenuItem.Click += new System.EventHandler(this.abrirChamadoToolStripMenuItem_Click);
            // 
            // finalizarChamadoToolStripMenuItem
            // 
            this.finalizarChamadoToolStripMenuItem.Name = "finalizarChamadoToolStripMenuItem";
            this.finalizarChamadoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.finalizarChamadoToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.finalizarChamadoToolStripMenuItem.Text = "Finalizar Chamado";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.D0)));
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // tsInicio
            // 
            this.tsInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsInicio.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.tsInicio.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsInicio.Image = global::ModuloDesktop.Properties.Resources._12;
            this.tsInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsInicio.Name = "tsInicio";
            this.tsInicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsInicio.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.tsInicio.Size = new System.Drawing.Size(90, 56);
            this.tsInicio.Text = "INICIO";
            // 
            // tsQuemSomos
            // 
            this.tsQuemSomos.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.tsQuemSomos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tsQuemSomos.Image = global::ModuloDesktop.Properties.Resources._12;
            this.tsQuemSomos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsQuemSomos.Name = "tsQuemSomos";
            this.tsQuemSomos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsQuemSomos.Size = new System.Drawing.Size(142, 56);
            this.tsQuemSomos.Text = "QUEM SOMOS";
            // 
            // cHAMADOSToolStripMenuItem
            // 
            this.cHAMADOSToolStripMenuItem.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.cHAMADOSToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cHAMADOSToolStripMenuItem.Image = global::ModuloDesktop.Properties.Resources._13;
            this.cHAMADOSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cHAMADOSToolStripMenuItem.Name = "cHAMADOSToolStripMenuItem";
            this.cHAMADOSToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cHAMADOSToolStripMenuItem.Size = new System.Drawing.Size(128, 56);
            this.cHAMADOSToolStripMenuItem.Text = "CHAMADOS";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolStripMenuItem1.Image = global::ModuloDesktop.Properties.Resources._44;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 56);
            this.toolStripMenuItem1.Text = "INFOTECH";
            // 
            // tsMenuLateral
            // 
            this.tsMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsMenuLateral.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tsMenuLateral.ImageScalingSize = new System.Drawing.Size(200, 40);
            this.tsMenuLateral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnLateralPrincipal,
            this.btnLateralAbrir,
            this.btnLateralFinalizar,
            this.subLateralChamados,
            this.subLateralAdm,
            this.toolStripSeparator2});
            this.tsMenuLateral.Location = new System.Drawing.Point(0, 60);
            this.tsMenuLateral.Name = "tsMenuLateral";
            this.tsMenuLateral.Size = new System.Drawing.Size(214, 393);
            this.tsMenuLateral.TabIndex = 1;
            this.tsMenuLateral.Text = "ToolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // btnLateralPrincipal
            // 
            this.btnLateralPrincipal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLateralPrincipal.Image = global::ModuloDesktop.Properties.Resources.principal;
            this.btnLateralPrincipal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLateralPrincipal.Name = "btnLateralPrincipal";
            this.btnLateralPrincipal.Size = new System.Drawing.Size(211, 44);
            this.btnLateralPrincipal.Text = "Principal";
            this.btnLateralPrincipal.Click += new System.EventHandler(this.btnLateralPrincipal_Click);
            // 
            // btnLateralAbrir
            // 
            this.btnLateralAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLateralAbrir.Image = global::ModuloDesktop.Properties.Resources.abrir;
            this.btnLateralAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLateralAbrir.Name = "btnLateralAbrir";
            this.btnLateralAbrir.Size = new System.Drawing.Size(211, 44);
            this.btnLateralAbrir.Text = "Abrir Chamado";
            this.btnLateralAbrir.Click += new System.EventHandler(this.btnLateralAbrir_Click);
            // 
            // btnLateralFinalizar
            // 
            this.btnLateralFinalizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLateralFinalizar.Image = global::ModuloDesktop.Properties.Resources.finalizar;
            this.btnLateralFinalizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLateralFinalizar.Name = "btnLateralFinalizar";
            this.btnLateralFinalizar.Size = new System.Drawing.Size(211, 44);
            this.btnLateralFinalizar.Text = "Fechar Chamado";
            // 
            // subLateralChamados
            // 
            this.subLateralChamados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subLateralChamados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemAbertos,
            this.subItemFinalizados});
            this.subLateralChamados.Image = global::ModuloDesktop.Properties.Resources.chamados;
            this.subLateralChamados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subLateralChamados.Name = "subLateralChamados";
            this.subLateralChamados.Size = new System.Drawing.Size(211, 44);
            this.subLateralChamados.Text = "Chamados";
            // 
            // subItemAbertos
            // 
            this.subItemAbertos.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemAbertos.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemAbertos.Image = global::ModuloDesktop.Properties.Resources._23;
            this.subItemAbertos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemAbertos.Name = "subItemAbertos";
            this.subItemAbertos.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.subItemAbertos.Size = new System.Drawing.Size(217, 36);
            this.subItemAbertos.Text = "Abertos";
            // 
            // subItemFinalizados
            // 
            this.subItemFinalizados.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemFinalizados.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemFinalizados.Image = global::ModuloDesktop.Properties.Resources._14;
            this.subItemFinalizados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemFinalizados.Name = "subItemFinalizados";
            this.subItemFinalizados.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.subItemFinalizados.Size = new System.Drawing.Size(217, 36);
            this.subItemFinalizados.Text = "Finalizados";
            // 
            // subLateralAdm
            // 
            this.subLateralAdm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.subLateralAdm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subItemAtendente,
            this.subItemEmpresas,
            this.subItemUsuarios,
            this.subItemGerentes});
            this.subLateralAdm.Image = global::ModuloDesktop.Properties.Resources.adm;
            this.subLateralAdm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.subLateralAdm.Name = "subLateralAdm";
            this.subLateralAdm.Size = new System.Drawing.Size(211, 44);
            this.subLateralAdm.Text = "Administração";
            // 
            // subItemAtendente
            // 
            this.subItemAtendente.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemAtendente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemAtendente.Image = global::ModuloDesktop.Properties.Resources._22;
            this.subItemAtendente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemAtendente.Name = "subItemAtendente";
            this.subItemAtendente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
            this.subItemAtendente.Size = new System.Drawing.Size(212, 36);
            this.subItemAtendente.Text = "Atendente";
            // 
            // subItemEmpresas
            // 
            this.subItemEmpresas.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemEmpresas.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemEmpresas.Image = global::ModuloDesktop.Properties.Resources._22;
            this.subItemEmpresas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemEmpresas.Name = "subItemEmpresas";
            this.subItemEmpresas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D6)));
            this.subItemEmpresas.Size = new System.Drawing.Size(212, 36);
            this.subItemEmpresas.Text = "Empresas";
            this.subItemEmpresas.Click += new System.EventHandler(this.subItemEmpresas_Click);
            // 
            // subItemUsuarios
            // 
            this.subItemUsuarios.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemUsuarios.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemUsuarios.Image = global::ModuloDesktop.Properties.Resources._22;
            this.subItemUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemUsuarios.Name = "subItemUsuarios";
            this.subItemUsuarios.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D7)));
            this.subItemUsuarios.Size = new System.Drawing.Size(212, 36);
            this.subItemUsuarios.Text = "Usuários";
            // 
            // subItemGerentes
            // 
            this.subItemGerentes.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold);
            this.subItemGerentes.ForeColor = System.Drawing.SystemColors.Highlight;
            this.subItemGerentes.Image = global::ModuloDesktop.Properties.Resources._22;
            this.subItemGerentes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subItemGerentes.Name = "subItemGerentes";
            this.subItemGerentes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D8)));
            this.subItemGerentes.Size = new System.Drawing.Size(212, 36);
            this.subItemGerentes.Text = "Gerentes";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // MDIParentPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 453);
            this.Controls.Add(this.tsMenuLateral);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParentPrincipal";
            this.Text = "INFOTECH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParentPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MDIParentPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tsMenuLateral.ResumeLayout(false);
            this.tsMenuLateral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip tsMenuLateral;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsInicio;
        private System.Windows.Forms.ToolStripMenuItem tsQuemSomos;
        private System.Windows.Forms.ToolStripMenuItem tsOpcoes;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton subLateralAdm;
        private System.Windows.Forms.ToolStripMenuItem subItemAtendente;
        private System.Windows.Forms.ToolStripMenuItem subItemEmpresas;
        private System.Windows.Forms.ToolStripMenuItem subItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem subItemGerentes;
        private System.Windows.Forms.ToolStripButton btnLateralPrincipal;
        private System.Windows.Forms.ToolStripButton btnLateralAbrir;
        private System.Windows.Forms.ToolStripButton btnLateralFinalizar;
        private System.Windows.Forms.ToolStripDropDownButton subLateralChamados;
        private System.Windows.Forms.ToolStripMenuItem subItemAbertos;
        private System.Windows.Forms.ToolStripMenuItem subItemFinalizados;
        private System.Windows.Forms.ToolStripMenuItem abrirChamadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalizarChamadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHAMADOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}



