namespace Rename
{
    partial class Rename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rename));
            this.btnIniciarRenomeacao = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIniciarRenomeacao
            // 
            this.btnIniciarRenomeacao.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnIniciarRenomeacao, "btnIniciarRenomeacao");
            this.btnIniciarRenomeacao.Name = "btnIniciarRenomeacao";
            this.btnIniciarRenomeacao.UseVisualStyleBackColor = true;
            this.btnIniciarRenomeacao.Click += new System.EventHandler(this.btnIniciarRenomeacao_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            resources.ApplyResources(this.tutorialToolStripMenuItem, "tutorialToolStripMenuItem");
            this.tutorialToolStripMenuItem.Click += new System.EventHandler(this.Tutorial);
            // 
            // Rename
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnIniciarRenomeacao);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Name = "Rename";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarRenomeacao;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
    }
}

