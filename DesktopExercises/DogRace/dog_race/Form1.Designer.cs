namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbjoao = new System.Windows.Forms.RadioButton();
            this.rbalfredo = new System.Windows.Forms.RadioButton();
            this.rbbeto = new System.Windows.Forms.RadioButton();
            this.lbjoao = new System.Windows.Forms.Label();
            this.lbalfredo = new System.Windows.Forms.Label();
            this.lbbeto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nvalor = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ncao = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.pcbcao4 = new System.Windows.Forms.PictureBox();
            this.pcbcao3 = new System.Windows.Forms.PictureBox();
            this.pcbcao2 = new System.Windows.Forms.PictureBox();
            this.pcbcao1 = new System.Windows.Forms.PictureBox();
            this.pcbpista = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvalor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbpista)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.ncao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nvalor);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbbeto);
            this.groupBox1.Controls.Add(this.lbalfredo);
            this.groupBox1.Controls.Add(this.lbjoao);
            this.groupBox1.Controls.Add(this.rbbeto);
            this.groupBox1.Controls.Add(this.rbalfredo);
            this.groupBox1.Controls.Add(this.rbjoao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-1, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 156);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balcão de Apostas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aposta mínima";
            // 
            // rbjoao
            // 
            this.rbjoao.AutoSize = true;
            this.rbjoao.Checked = true;
            this.rbjoao.Location = new System.Drawing.Point(16, 32);
            this.rbjoao.Name = "rbjoao";
            this.rbjoao.Size = new System.Drawing.Size(51, 17);
            this.rbjoao.TabIndex = 1;
            this.rbjoao.TabStop = true;
            this.rbjoao.Text = "João ";
            this.rbjoao.UseVisualStyleBackColor = true;
            // 
            // rbalfredo
            // 
            this.rbalfredo.AutoSize = true;
            this.rbalfredo.Location = new System.Drawing.Point(16, 78);
            this.rbalfredo.Name = "rbalfredo";
            this.rbalfredo.Size = new System.Drawing.Size(58, 17);
            this.rbalfredo.TabIndex = 2;
            this.rbalfredo.Text = "Alfredo";
            this.rbalfredo.UseVisualStyleBackColor = true;
            // 
            // rbbeto
            // 
            this.rbbeto.AutoSize = true;
            this.rbbeto.Location = new System.Drawing.Point(16, 55);
            this.rbbeto.Name = "rbbeto";
            this.rbbeto.Size = new System.Drawing.Size(47, 17);
            this.rbbeto.TabIndex = 3;
            this.rbbeto.Text = "Beto";
            this.rbbeto.UseVisualStyleBackColor = true;
            // 
            // lbjoao
            // 
            this.lbjoao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbjoao.Location = new System.Drawing.Point(320, 32);
            this.lbjoao.Name = "lbjoao";
            this.lbjoao.Size = new System.Drawing.Size(248, 17);
            this.lbjoao.TabIndex = 6;
            this.lbjoao.Text = "Aposta do João";
            // 
            // lbalfredo
            // 
            this.lbalfredo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbalfredo.Location = new System.Drawing.Point(320, 78);
            this.lbalfredo.Name = "lbalfredo";
            this.lbalfredo.Size = new System.Drawing.Size(248, 17);
            this.lbalfredo.TabIndex = 7;
            this.lbalfredo.Text = "Aposta do Alfredo";
            // 
            // lbbeto
            // 
            this.lbbeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbbeto.Location = new System.Drawing.Point(320, 56);
            this.lbbeto.Name = "lbbeto";
            this.lbbeto.Size = new System.Drawing.Size(248, 17);
            this.lbbeto.TabIndex = 8;
            this.lbbeto.Text = "Aposta do Beto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "João";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(78, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Aposta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nvalor
            // 
            this.nvalor.Location = new System.Drawing.Point(159, 128);
            this.nvalor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nvalor.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nvalor.Name = "nvalor";
            this.nvalor.Size = new System.Drawing.Size(68, 20);
            this.nvalor.TabIndex = 11;
            this.nvalor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "reais no cão número:";
            // 
            // ncao
            // 
            this.ncao.Location = new System.Drawing.Point(345, 128);
            this.ncao.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ncao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ncao.Name = "ncao";
            this.ncao.Size = new System.Drawing.Size(68, 20);
            this.ncao.TabIndex = 13;
            this.ncao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(436, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Correr!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pcbcao4
            // 
            this.pcbcao4.Image = global::WindowsFormsApplication1.Properties.Resources.dog;
            this.pcbcao4.Location = new System.Drawing.Point(12, 160);
            this.pcbcao4.Name = "pcbcao4";
            this.pcbcao4.Size = new System.Drawing.Size(76, 21);
            this.pcbcao4.TabIndex = 4;
            this.pcbcao4.TabStop = false;
            // 
            // pcbcao3
            // 
            this.pcbcao3.Image = global::WindowsFormsApplication1.Properties.Resources.dog;
            this.pcbcao3.Location = new System.Drawing.Point(12, 117);
            this.pcbcao3.Name = "pcbcao3";
            this.pcbcao3.Size = new System.Drawing.Size(76, 21);
            this.pcbcao3.TabIndex = 3;
            this.pcbcao3.TabStop = false;
            // 
            // pcbcao2
            // 
            this.pcbcao2.Image = global::WindowsFormsApplication1.Properties.Resources.dog;
            this.pcbcao2.Location = new System.Drawing.Point(12, 67);
            this.pcbcao2.Name = "pcbcao2";
            this.pcbcao2.Size = new System.Drawing.Size(76, 21);
            this.pcbcao2.TabIndex = 2;
            this.pcbcao2.TabStop = false;
            // 
            // pcbcao1
            // 
            this.pcbcao1.Image = global::WindowsFormsApplication1.Properties.Resources.dog;
            this.pcbcao1.Location = new System.Drawing.Point(12, 12);
            this.pcbcao1.Name = "pcbcao1";
            this.pcbcao1.Size = new System.Drawing.Size(76, 21);
            this.pcbcao1.TabIndex = 1;
            this.pcbcao1.TabStop = false;
            // 
            // pcbpista
            // 
            this.pcbpista.Image = global::WindowsFormsApplication1.Properties.Resources.racetrack;
            this.pcbpista.Location = new System.Drawing.Point(-1, 1);
            this.pcbpista.Name = "pcbpista";
            this.pcbpista.Size = new System.Drawing.Size(588, 202);
            this.pcbpista.TabIndex = 0;
            this.pcbpista.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(589, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pcbcao4);
            this.Controls.Add(this.pcbcao3);
            this.Controls.Add(this.pcbcao2);
            this.Controls.Add(this.pcbcao1);
            this.Controls.Add(this.pcbpista);
            this.Name = "Form1";
            this.Text = "Dia de corrida";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nvalor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ncao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbcao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbpista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbpista;
        private System.Windows.Forms.PictureBox pcbcao1;
        private System.Windows.Forms.PictureBox pcbcao2;
        private System.Windows.Forms.PictureBox pcbcao3;
        private System.Windows.Forms.PictureBox pcbcao4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbjoao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbjoao;
        private System.Windows.Forms.RadioButton rbbeto;
        private System.Windows.Forms.RadioButton rbalfredo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown ncao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nvalor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbbeto;
        private System.Windows.Forms.Label lbalfredo;
    }
}

