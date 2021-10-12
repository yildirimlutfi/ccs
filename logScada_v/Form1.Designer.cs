
namespace logScada
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonMain = new System.Windows.Forms.Button();
            this.buttonCrane = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.maskedTextBoxBaslangic = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxBitis = new System.Windows.Forms.MaskedTextBox();
            this.buttonFiltre = new System.Windows.Forms.Button();
            this.labelDosyaAdresi = new System.Windows.Forms.Label();
            this.buttonFiltreIptal = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Zaman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelButton = new System.Windows.Forms.Panel();
            this.buttonEksenHesaplama = new System.Windows.Forms.Button();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelButton.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMain
            // 
            this.buttonMain.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonMain.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.buttonMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.buttonMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMain.Location = new System.Drawing.Point(3, 3);
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.Size = new System.Drawing.Size(147, 29);
            this.buttonMain.TabIndex = 3;
            this.buttonMain.Text = "Saha Dosyası Oku";
            this.buttonMain.UseVisualStyleBackColor = true;
            this.buttonMain.Click += new System.EventHandler(this.buttonMain_Click);
            // 
            // buttonCrane
            // 
            this.buttonCrane.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonCrane.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCrane.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.buttonCrane.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.buttonCrane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrane.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrane.Location = new System.Drawing.Point(157, 3);
            this.buttonCrane.Name = "buttonCrane";
            this.buttonCrane.Size = new System.Drawing.Size(147, 29);
            this.buttonCrane.TabIndex = 4;
            this.buttonCrane.Text = "Vinç Dosyası Oku";
            this.buttonCrane.UseVisualStyleBackColor = true;
            this.buttonCrane.Click += new System.EventHandler(this.buttonCrane_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonReset.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(311, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(147, 29);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // maskedTextBoxBaslangic
            // 
            this.maskedTextBoxBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxBaslangic.Location = new System.Drawing.Point(465, 5);
            this.maskedTextBoxBaslangic.Mask = "00:00:00";
            this.maskedTextBoxBaslangic.Name = "maskedTextBoxBaslangic";
            this.maskedTextBoxBaslangic.Size = new System.Drawing.Size(100, 24);
            this.maskedTextBoxBaslangic.TabIndex = 7;
            this.maskedTextBoxBaslangic.Text = "000000";
            // 
            // maskedTextBoxBitis
            // 
            this.maskedTextBoxBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxBitis.Location = new System.Drawing.Point(572, 5);
            this.maskedTextBoxBitis.Mask = "00:00:00";
            this.maskedTextBoxBitis.Name = "maskedTextBoxBitis";
            this.maskedTextBoxBitis.Size = new System.Drawing.Size(100, 24);
            this.maskedTextBoxBitis.TabIndex = 8;
            this.maskedTextBoxBitis.Text = "235959";
            // 
            // buttonFiltre
            // 
            this.buttonFiltre.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFiltre.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonFiltre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.buttonFiltre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.buttonFiltre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltre.Location = new System.Drawing.Point(679, 3);
            this.buttonFiltre.Name = "buttonFiltre";
            this.buttonFiltre.Size = new System.Drawing.Size(107, 29);
            this.buttonFiltre.TabIndex = 9;
            this.buttonFiltre.Text = "Filtre Uygula";
            this.buttonFiltre.UseVisualStyleBackColor = true;
            this.buttonFiltre.Click += new System.EventHandler(this.buttonFiltre_Click);
            // 
            // labelDosyaAdresi
            // 
            this.labelDosyaAdresi.AutoSize = true;
            this.labelDosyaAdresi.Location = new System.Drawing.Point(926, 11);
            this.labelDosyaAdresi.Name = "labelDosyaAdresi";
            this.labelDosyaAdresi.Size = new System.Drawing.Size(10, 13);
            this.labelDosyaAdresi.TabIndex = 11;
            this.labelDosyaAdresi.Text = ".";
            this.labelDosyaAdresi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonFiltreIptal
            // 
            this.buttonFiltreIptal.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFiltreIptal.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonFiltreIptal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.buttonFiltreIptal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen;
            this.buttonFiltreIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltreIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltreIptal.Location = new System.Drawing.Point(793, 3);
            this.buttonFiltreIptal.Name = "buttonFiltreIptal";
            this.buttonFiltreIptal.Size = new System.Drawing.Size(126, 29);
            this.buttonFiltreIptal.TabIndex = 12;
            this.buttonFiltreIptal.Text = "Hepsini Göster";
            this.buttonFiltreIptal.UseVisualStyleBackColor = true;
            this.buttonFiltreIptal.Click += new System.EventHandler(this.buttonFiltreIptal_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Zaman});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1584, 728);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.Visible = false;
            // 
            // Zaman
            // 
            this.Zaman.Frozen = true;
            this.Zaman.HeaderText = "Zaman";
            this.Zaman.Name = "Zaman";
            this.Zaman.ReadOnly = true;
            this.Zaman.Width = 60;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.buttonEksenHesaplama);
            this.panelButton.Controls.Add(this.buttonReset);
            this.panelButton.Controls.Add(this.buttonMain);
            this.panelButton.Controls.Add(this.buttonCrane);
            this.panelButton.Controls.Add(this.buttonFiltreIptal);
            this.panelButton.Controls.Add(this.maskedTextBoxBaslangic);
            this.panelButton.Controls.Add(this.labelDosyaAdresi);
            this.panelButton.Controls.Add(this.maskedTextBoxBitis);
            this.panelButton.Controls.Add(this.buttonFiltre);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButton.Location = new System.Drawing.Point(0, 0);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1584, 33);
            this.panelButton.TabIndex = 15;
            // 
            // buttonEksenHesaplama
            // 
            this.buttonEksenHesaplama.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEksenHesaplama.Location = new System.Drawing.Point(1471, 0);
            this.buttonEksenHesaplama.Name = "buttonEksenHesaplama";
            this.buttonEksenHesaplama.Size = new System.Drawing.Size(113, 33);
            this.buttonEksenHesaplama.TabIndex = 13;
            this.buttonEksenHesaplama.Text = "Eksen Hesaplama";
            this.buttonEksenHesaplama.UseVisualStyleBackColor = true;
            this.buttonEksenHesaplama.Visible = false;
            this.buttonEksenHesaplama.Click += new System.EventHandler(this.buttonEksenHesaplama_Click);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.Controls.Add(this.dataGridView1);
            this.panelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGrid.Location = new System.Drawing.Point(0, 33);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(1584, 728);
            this.panelDataGrid.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "İsdemir - Tovs PLC Log Okuma Yazılımı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonMain;
        private System.Windows.Forms.Button buttonCrane;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBaslangic;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBitis;
        private System.Windows.Forms.Button buttonFiltre;
        private System.Windows.Forms.Label labelDosyaAdresi;
        private System.Windows.Forms.Button buttonFiltreIptal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zaman;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.Button buttonEksenHesaplama;
    }
}

