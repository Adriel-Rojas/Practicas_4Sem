namespace Practicas
{
    partial class Practica3
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
            this.customButtonTextBox1 = new BibliotecaRojas3.CustomButtonTextBox();
            this.SuspendLayout();
            // 
            // customButtonTextBox1
            // 
            this.customButtonTextBox1.Location = new System.Drawing.Point(140, 58);
            this.customButtonTextBox1.Name = "customButtonTextBox1";
            this.customButtonTextBox1.Size = new System.Drawing.Size(551, 129);
            this.customButtonTextBox1.TabIndex = 0;
            // 
            // Practica3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 322);
            this.Controls.Add(this.customButtonTextBox1);
            this.Name = "Practica3";
            this.Text = "Componenetes y librerias";
            this.ResumeLayout(false);

        }

        #endregion

        private BibliotecaRojas3.CustomButtonTextBox customButtonTextBox1;
    }
}