namespace Practicas
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.practicasSemestre4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practica1GestionDeContactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practica2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.practicasSemestre4ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // practicasSemestre4ToolStripMenuItem
            // 
            this.practicasSemestre4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.practica1GestionDeContactosToolStripMenuItem,
            this.practica2ToolStripMenuItem});
            this.practicasSemestre4ToolStripMenuItem.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.practicasSemestre4ToolStripMenuItem.Name = "practicasSemestre4ToolStripMenuItem";
            this.practicasSemestre4ToolStripMenuItem.Size = new System.Drawing.Size(258, 31);
            this.practicasSemestre4ToolStripMenuItem.Text = "Practicas Semestre 4";
            // 
            // practica1GestionDeContactosToolStripMenuItem
            // 
            this.practica1GestionDeContactosToolStripMenuItem.Name = "practica1GestionDeContactosToolStripMenuItem";
            this.practica1GestionDeContactosToolStripMenuItem.Size = new System.Drawing.Size(510, 32);
            this.practica1GestionDeContactosToolStripMenuItem.Text = "Practica 1 (Gestion de Contactos)";
            this.practica1GestionDeContactosToolStripMenuItem.Click += new System.EventHandler(this.practica1GestionDeContactosToolStripMenuItem_Click);
            // 
            // practica2ToolStripMenuItem
            // 
            this.practica2ToolStripMenuItem.Name = "practica2ToolStripMenuItem";
            this.practica2ToolStripMenuItem.Size = new System.Drawing.Size(510, 32);
            this.practica2ToolStripMenuItem.Text = "Practica 2 (Interfaz Grafica Dinamica)";
            this.practica2ToolStripMenuItem.Click += new System.EventHandler(this.practica2ToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem practicasSemestre4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practica1GestionDeContactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practica2ToolStripMenuItem;
    }
}