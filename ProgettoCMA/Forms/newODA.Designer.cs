namespace ProgettoCMA
{
    partial class newODA
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
            this.creaButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.forzaButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.forzaCreaButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // creaButton
            // 
            this.creaButton.Location = new System.Drawing.Point(11, 56);
            this.creaButton.Name = "creaButton";
            this.creaButton.Size = new System.Drawing.Size(261, 46);
            this.creaButton.TabIndex = 2;
            this.creaButton.Text = "Crea Ordine di acquisto";
            this.creaButton.UseVisualStyleBackColor = true;
            this.creaButton.Click += new System.EventHandler(this.creaButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selezionare la RDO di riferimento";
            // 
            // forzaButton
            // 
            this.forzaButton.Location = new System.Drawing.Point(11, 108);
            this.forzaButton.Name = "forzaButton";
            this.forzaButton.Size = new System.Drawing.Size(261, 23);
            this.forzaButton.TabIndex = 2;
            this.forzaButton.Text = "Forza creazione";
            this.forzaButton.UseVisualStyleBackColor = true;
            this.forzaButton.Click += new System.EventHandler(this.forzaButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 67);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Specificare ragione (tassativo)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.forzaCreaButton);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(8, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 123);
            this.panel1.TabIndex = 7;
            // 
            // forzaCreaButton
            // 
            this.forzaCreaButton.Location = new System.Drawing.Point(3, 95);
            this.forzaCreaButton.Name = "forzaCreaButton";
            this.forzaCreaButton.Size = new System.Drawing.Size(261, 23);
            this.forzaCreaButton.TabIndex = 8;
            this.forzaCreaButton.Text = "Crea";
            this.forzaCreaButton.UseVisualStyleBackColor = true;
            this.forzaCreaButton.Click += new System.EventHandler(this.forzaCreaButton_Click);
            // 
            // newODA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 274);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.forzaButton);
            this.Controls.Add(this.creaButton);
            this.Name = "newODA";
            this.Text = "newODA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creaButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button forzaButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button forzaCreaButton;
    }
}