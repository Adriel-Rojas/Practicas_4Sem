namespace Practicas.Practica_4
{
    partial class HilosConc
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.lblTiempoSecuencial = new System.Windows.Forms.Label();
            this.lblResultadoConcurrente = new System.Windows.Forms.Label();
            this.lblTiempoConcurrente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero Limite:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(99, 272);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(102, 39);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(90, 223);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(120, 22);
            this.txtLimite.TabIndex = 2;
            // 
            // lblTiempoSecuencial
            // 
            this.lblTiempoSecuencial.AutoSize = true;
            this.lblTiempoSecuencial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoSecuencial.Location = new System.Drawing.Point(759, 278);
            this.lblTiempoSecuencial.Name = "lblTiempoSecuencial";
            this.lblTiempoSecuencial.Size = new System.Drawing.Size(27, 25);
            this.lblTiempoSecuencial.TabIndex = 3;
            this.lblTiempoSecuencial.Text = "...";
            // 
            // lblResultadoConcurrente
            // 
            this.lblResultadoConcurrente.AutoSize = true;
            this.lblResultadoConcurrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoConcurrente.Location = new System.Drawing.Point(759, 169);
            this.lblResultadoConcurrente.Name = "lblResultadoConcurrente";
            this.lblResultadoConcurrente.Size = new System.Drawing.Size(27, 25);
            this.lblResultadoConcurrente.TabIndex = 5;
            this.lblResultadoConcurrente.Text = "...";
            // 
            // lblTiempoConcurrente
            // 
            this.lblTiempoConcurrente.AutoSize = true;
            this.lblTiempoConcurrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoConcurrente.Location = new System.Drawing.Point(759, 223);
            this.lblTiempoConcurrente.Name = "lblTiempoConcurrente";
            this.lblTiempoConcurrente.Size = new System.Drawing.Size(27, 25);
            this.lblTiempoConcurrente.TabIndex = 6;
            this.lblTiempoConcurrente.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(360, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Suma Total de Numero Primos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(360, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tiempo de Ejecucion Concurrente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tiempo de Ejecucion Secuencial:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(588, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Practica 4. Concurrencia. Numeros Primos";
            // 
            // HilosConc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 511);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTiempoConcurrente);
            this.Controls.Add(this.lblResultadoConcurrente);
            this.Controls.Add(this.lblTiempoSecuencial);
            this.Controls.Add(this.txtLimite);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.label1);
            this.Name = "HilosConc";
            this.Text = "Concurrencia. Numeros Primos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtLimite;
        private System.Windows.Forms.Label lblTiempoSecuencial;
        private System.Windows.Forms.Label lblResultadoConcurrente;
        private System.Windows.Forms.Label lblTiempoConcurrente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}