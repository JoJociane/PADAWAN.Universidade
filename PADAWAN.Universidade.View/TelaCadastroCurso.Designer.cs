namespace PADAWAN.Universidade.View
{
    partial class TelaCadastroCurso
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.cbb_Situacao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.btn_Visualizar = new System.Windows.Forms.Button();
            this.list_1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.list_2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(280, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro Curso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Situação:";
            // 
            // txt_Nome
            // 
            this.txt_Nome.Location = new System.Drawing.Point(121, 133);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(267, 31);
            this.txt_Nome.TabIndex = 2;
            // 
            // cbb_Situacao
            // 
            this.cbb_Situacao.FormattingEnabled = true;
            this.cbb_Situacao.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cbb_Situacao.Location = new System.Drawing.Point(142, 184);
            this.cbb_Situacao.Name = "cbb_Situacao";
            this.cbb_Situacao.Size = new System.Drawing.Size(246, 33);
            this.cbb_Situacao.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Materia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Adicionadas";
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.Location = new System.Drawing.Point(142, 403);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(121, 44);
            this.btn_Voltar.TabIndex = 8;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = true;
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.Location = new System.Drawing.Point(315, 403);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(121, 44);
            this.btn_Salvar.TabIndex = 8;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = true;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // btn_Visualizar
            // 
            this.btn_Visualizar.Location = new System.Drawing.Point(489, 403);
            this.btn_Visualizar.Name = "btn_Visualizar";
            this.btn_Visualizar.Size = new System.Drawing.Size(121, 44);
            this.btn_Visualizar.TabIndex = 8;
            this.btn_Visualizar.Text = "Visualizar";
            this.btn_Visualizar.UseVisualStyleBackColor = true;
            // 
            // list_1
            // 
            this.list_1.FormattingEnabled = true;
            this.list_1.ItemHeight = 25;
            this.list_1.Items.AddRange(new object[] {
            "Item1",
            "Item2"});
            this.list_1.Location = new System.Drawing.Point(71, 267);
            this.list_1.Name = "list_1";
            this.list_1.Size = new System.Drawing.Size(192, 104);
            this.list_1.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(323, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 45);
            this.button2.TabIndex = 11;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // list_2
            // 
            this.list_2.FormattingEnabled = true;
            this.list_2.ItemHeight = 25;
            this.list_2.Location = new System.Drawing.Point(454, 267);
            this.list_2.Name = "list_2";
            this.list_2.Size = new System.Drawing.Size(180, 104);
            this.list_2.TabIndex = 12;
            // 
            // TelaCadastroCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 471);
            this.Controls.Add(this.list_2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_1);
            this.Controls.Add(this.btn_Visualizar);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbb_Situacao);
            this.Controls.Add(this.txt_Nome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroCurso";
            this.Text = "TelaCadastroCurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.ComboBox cbb_Situacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Voltar;
        private System.Windows.Forms.Button btn_Salvar;
        private System.Windows.Forms.Button btn_Visualizar;
        private System.Windows.Forms.ListBox list_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox list_2;
    }
}

