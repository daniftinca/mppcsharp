namespace lab_csharp
{
    partial class Form2
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
            this.dataGridViewParticipantiScoruri = new System.Windows.Forms.DataGridView();
            this.comboBoxProbe = new System.Windows.Forms.ComboBox();
            this.textBoxNota = new System.Windows.Forms.TextBox();
            this.labelNota = new System.Windows.Forms.Label();
            this.buttonAddNota = new System.Windows.Forms.Button();
            this.comboBoxParticipanti = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantiScoruri)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewParticipantiScoruri
            // 
            this.dataGridViewParticipantiScoruri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParticipantiScoruri.Location = new System.Drawing.Point(11, 11);
            this.dataGridViewParticipantiScoruri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewParticipantiScoruri.Name = "dataGridViewParticipantiScoruri";
            this.dataGridViewParticipantiScoruri.RowTemplate.Height = 24;
            this.dataGridViewParticipantiScoruri.Size = new System.Drawing.Size(602, 344);
            this.dataGridViewParticipantiScoruri.TabIndex = 0;
            this.dataGridViewParticipantiScoruri.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParticipantiScoruri_CellContentClick);
            // 
            // comboBoxProbe
            // 
            this.comboBoxProbe.FormattingEnabled = true;
            this.comboBoxProbe.Location = new System.Drawing.Point(620, 11);
            this.comboBoxProbe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxProbe.Name = "comboBoxProbe";
            this.comboBoxProbe.Size = new System.Drawing.Size(132, 21);
            this.comboBoxProbe.TabIndex = 1;
            this.comboBoxProbe.SelectedIndexChanged += new System.EventHandler(this.comboBoxProbe_SelectedIndexChanged);
            // 
            // textBoxNota
            // 
            this.textBoxNota.Location = new System.Drawing.Point(620, 178);
            this.textBoxNota.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNota.Name = "textBoxNota";
            this.textBoxNota.Size = new System.Drawing.Size(82, 20);
            this.textBoxNota.TabIndex = 2;
            this.textBoxNota.TextChanged += new System.EventHandler(this.textBoxNota_TextChanged);
            // 
            // labelNota
            // 
            this.labelNota.AutoSize = true;
            this.labelNota.Location = new System.Drawing.Point(617, 149);
            this.labelNota.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNota.Name = "labelNota";
            this.labelNota.Size = new System.Drawing.Size(68, 13);
            this.labelNota.TabIndex = 3;
            this.labelNota.Text = "Adauga nota";
            // 
            // buttonAddNota
            // 
            this.buttonAddNota.Location = new System.Drawing.Point(620, 250);
            this.buttonAddNota.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddNota.Name = "buttonAddNota";
            this.buttonAddNota.Size = new System.Drawing.Size(56, 19);
            this.buttonAddNota.TabIndex = 4;
            this.buttonAddNota.Text = "Add";
            this.buttonAddNota.UseVisualStyleBackColor = true;
            this.buttonAddNota.Click += new System.EventHandler(this.buttonAddNota_Click);
            // 
            // comboBoxParticipanti
            // 
            this.comboBoxParticipanti.FormattingEnabled = true;
            this.comboBoxParticipanti.Location = new System.Drawing.Point(620, 214);
            this.comboBoxParticipanti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxParticipanti.Name = "comboBoxParticipanti";
            this.comboBoxParticipanti.Size = new System.Drawing.Size(212, 21);
            this.comboBoxParticipanti.TabIndex = 5;
            this.comboBoxParticipanti.SelectedIndexChanged += new System.EventHandler(this.comboBoxParticipanti_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(708, 176);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 366);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBoxParticipanti);
            this.Controls.Add(this.buttonAddNota);
            this.Controls.Add(this.labelNota);
            this.Controls.Add(this.textBoxNota);
            this.Controls.Add(this.comboBoxProbe);
            this.Controls.Add(this.dataGridViewParticipantiScoruri);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParticipantiScoruri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewParticipantiScoruri;
        private System.Windows.Forms.ComboBox comboBoxProbe;
        private System.Windows.Forms.TextBox textBoxNota;
        private System.Windows.Forms.Label labelNota;
        private System.Windows.Forms.Button buttonAddNota;
        private System.Windows.Forms.ComboBox comboBoxParticipanti;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}