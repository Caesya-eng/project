namespace AgroWasteNexus.Forms
{
    partial class Distribusi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distribusi));
            this.label1 = new System.Windows.Forms.Label();
            this.lblDistribusi = new System.Windows.Forms.Label();
            this.grpDataDistribusi = new System.Windows.Forms.GroupBox();
            this.txtIdpenerima = new System.Windows.Forms.TextBox();
            this.lblIdPenerima = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpTanggalPemeriksaan = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblJumlahProduk = new System.Windows.Forms.Label();
            this.txtJumlahProduk = new System.Windows.Forms.TextBox();
            this.lblTanggalDistribusi = new System.Windows.Forms.Label();
            this.txtIdProduksi = new System.Windows.Forms.TextBox();
            this.lblIdProduks = new System.Windows.Forms.Label();
            this.lblIdDistribusi = new System.Windows.Forms.Label();
            this.txtIdDistribusi = new System.Windows.Forms.TextBox();
            this.grpDaftaRDistribusi = new System.Windows.Forms.GroupBox();
            this.dgvDaftarDistribusii = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnKembali = new System.Windows.Forms.Button();
            this.grpDataDistribusi.SuspendLayout();
            this.grpDaftaRDistribusi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarDistribusii)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(202, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 8);
            this.label1.TabIndex = 0;
            this.label1.Text = "DISTRIBUSI";
            // 
            // lblDistribusi
            // 
            this.lblDistribusi.BackColor = System.Drawing.Color.Transparent;
            this.lblDistribusi.Font = new System.Drawing.Font("Century", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistribusi.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblDistribusi.Location = new System.Drawing.Point(180, 52);
            this.lblDistribusi.Name = "lblDistribusi";
            this.lblDistribusi.Size = new System.Drawing.Size(361, 61);
            this.lblDistribusi.TabIndex = 1;
            this.lblDistribusi.Text = "DISTRIBUSI";
            this.lblDistribusi.Click += new System.EventHandler(this.lblDistribusi_Click);
            // 
            // grpDataDistribusi
            // 
            this.grpDataDistribusi.BackColor = System.Drawing.Color.Transparent;
            this.grpDataDistribusi.Controls.Add(this.txtIdpenerima);
            this.grpDataDistribusi.Controls.Add(this.lblIdPenerima);
            this.grpDataDistribusi.Controls.Add(this.cmbStatus);
            this.grpDataDistribusi.Controls.Add(this.dtpTanggalPemeriksaan);
            this.grpDataDistribusi.Controls.Add(this.lblStatus);
            this.grpDataDistribusi.Controls.Add(this.lblJumlahProduk);
            this.grpDataDistribusi.Controls.Add(this.txtJumlahProduk);
            this.grpDataDistribusi.Controls.Add(this.lblTanggalDistribusi);
            this.grpDataDistribusi.Controls.Add(this.txtIdProduksi);
            this.grpDataDistribusi.Controls.Add(this.lblIdProduks);
            this.grpDataDistribusi.Controls.Add(this.lblIdDistribusi);
            this.grpDataDistribusi.Controls.Add(this.txtIdDistribusi);
            this.grpDataDistribusi.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDataDistribusi.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpDataDistribusi.Location = new System.Drawing.Point(12, 150);
            this.grpDataDistribusi.Name = "grpDataDistribusi";
            this.grpDataDistribusi.Size = new System.Drawing.Size(823, 237);
            this.grpDataDistribusi.TabIndex = 2;
            this.grpDataDistribusi.TabStop = false;
            this.grpDataDistribusi.Text = "📋 DATA DISTRIBUSI";
            // 
            // txtIdpenerima
            // 
            this.txtIdpenerima.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdpenerima.Location = new System.Drawing.Point(203, 136);
            this.txtIdpenerima.Name = "txtIdpenerima";
            this.txtIdpenerima.Size = new System.Drawing.Size(200, 29);
            this.txtIdpenerima.TabIndex = 12;
            // 
            // lblIdPenerima
            // 
            this.lblIdPenerima.AutoSize = true;
            this.lblIdPenerima.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdPenerima.ForeColor = System.Drawing.Color.Black;
            this.lblIdPenerima.Location = new System.Drawing.Point(6, 145);
            this.lblIdPenerima.Name = "lblIdPenerima";
            this.lblIdPenerima.Size = new System.Drawing.Size(115, 20);
            this.lblIdPenerima.TabIndex = 11;
            this.lblIdPenerima.Text = "ID Penerima";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(593, 98);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(204, 31);
            this.cmbStatus.TabIndex = 10;
            // 
            // dtpTanggalPemeriksaan
            // 
            this.dtpTanggalPemeriksaan.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTanggalPemeriksaan.Location = new System.Drawing.Point(203, 183);
            this.dtpTanggalPemeriksaan.Name = "dtpTanggalPemeriksaan";
            this.dtpTanggalPemeriksaan.Size = new System.Drawing.Size(200, 27);
            this.dtpTanggalPemeriksaan.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(413, 93);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status ";
            // 
            // lblJumlahProduk
            // 
            this.lblJumlahProduk.AutoSize = true;
            this.lblJumlahProduk.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlahProduk.ForeColor = System.Drawing.Color.Black;
            this.lblJumlahProduk.Location = new System.Drawing.Point(413, 50);
            this.lblJumlahProduk.Name = "lblJumlahProduk";
            this.lblJumlahProduk.Size = new System.Drawing.Size(174, 20);
            this.lblJumlahProduk.TabIndex = 6;
            this.lblJumlahProduk.Text = "Jumlah Produk (kg)";
            // 
            // txtJumlahProduk
            // 
            this.txtJumlahProduk.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlahProduk.Location = new System.Drawing.Point(593, 45);
            this.txtJumlahProduk.Name = "txtJumlahProduk";
            this.txtJumlahProduk.Size = new System.Drawing.Size(204, 29);
            this.txtJumlahProduk.TabIndex = 5;
            // 
            // lblTanggalDistribusi
            // 
            this.lblTanggalDistribusi.AutoSize = true;
            this.lblTanggalDistribusi.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggalDistribusi.ForeColor = System.Drawing.Color.Black;
            this.lblTanggalDistribusi.Location = new System.Drawing.Point(0, 190);
            this.lblTanggalDistribusi.Name = "lblTanggalDistribusi";
            this.lblTanggalDistribusi.Size = new System.Drawing.Size(166, 20);
            this.lblTanggalDistribusi.TabIndex = 4;
            this.lblTanggalDistribusi.Text = "Tanggal Distribusi";
            // 
            // txtIdProduksi
            // 
            this.txtIdProduksi.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProduksi.Location = new System.Drawing.Point(203, 93);
            this.txtIdProduksi.Name = "txtIdProduksi";
            this.txtIdProduksi.Size = new System.Drawing.Size(200, 29);
            this.txtIdProduksi.TabIndex = 3;
            // 
            // lblIdProduks
            // 
            this.lblIdProduks.AutoSize = true;
            this.lblIdProduks.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdProduks.ForeColor = System.Drawing.Color.Black;
            this.lblIdProduks.Location = new System.Drawing.Point(6, 98);
            this.lblIdProduks.Name = "lblIdProduks";
            this.lblIdProduks.Size = new System.Drawing.Size(95, 20);
            this.lblIdProduks.TabIndex = 2;
            this.lblIdProduks.Text = "ID Produk";
            this.lblIdProduks.Click += new System.EventHandler(this.lblIdProduks_Click);
            // 
            // lblIdDistribusi
            // 
            this.lblIdDistribusi.AutoSize = true;
            this.lblIdDistribusi.Font = new System.Drawing.Font("Century", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDistribusi.ForeColor = System.Drawing.Color.Black;
            this.lblIdDistribusi.Location = new System.Drawing.Point(6, 45);
            this.lblIdDistribusi.Name = "lblIdDistribusi";
            this.lblIdDistribusi.Size = new System.Drawing.Size(118, 20);
            this.lblIdDistribusi.TabIndex = 1;
            this.lblIdDistribusi.Text = "ID Distribusi";
            // 
            // txtIdDistribusi
            // 
            this.txtIdDistribusi.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdDistribusi.Location = new System.Drawing.Point(203, 45);
            this.txtIdDistribusi.Name = "txtIdDistribusi";
            this.txtIdDistribusi.Size = new System.Drawing.Size(200, 29);
            this.txtIdDistribusi.TabIndex = 0;
            // 
            // grpDaftaRDistribusi
            // 
            this.grpDaftaRDistribusi.BackColor = System.Drawing.Color.Transparent;
            this.grpDaftaRDistribusi.Controls.Add(this.dgvDaftarDistribusii);
            this.grpDaftaRDistribusi.Font = new System.Drawing.Font("Century", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDaftaRDistribusi.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpDaftaRDistribusi.Location = new System.Drawing.Point(12, 403);
            this.grpDaftaRDistribusi.Name = "grpDaftaRDistribusi";
            this.grpDaftaRDistribusi.Size = new System.Drawing.Size(823, 267);
            this.grpDaftaRDistribusi.TabIndex = 4;
            this.grpDaftaRDistribusi.TabStop = false;
            this.grpDaftaRDistribusi.Text = "📋 DAFTAR DISTRIBUSI";
            // 
            // dgvDaftarDistribusii
            // 
            this.dgvDaftarDistribusii.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDaftarDistribusii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaftarDistribusii.Location = new System.Drawing.Point(6, 31);
            this.dgvDaftarDistribusii.Name = "dgvDaftarDistribusii";
            this.dgvDaftarDistribusii.RowHeadersWidth = 62;
            this.dgvDaftarDistribusii.RowTemplate.Height = 28;
            this.dgvDaftarDistribusii.Size = new System.Drawing.Size(802, 227);
            this.dgvDaftarDistribusii.TabIndex = 0;
            this.dgvDaftarDistribusii.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDaftarDistribusii_CellContentClick);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.Green;
            this.btnTambah.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.Color.Ivory;
            this.btnTambah.Location = new System.Drawing.Point(11, 676);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(122, 36);
            this.btnTambah.TabIndex = 5;
            this.btnTambah.Text = "➕Tambah";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnUpdate.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Ivory;
            this.btnUpdate.Location = new System.Drawing.Point(139, 676);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(122, 36);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "✏️Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.DarkRed;
            this.btnHapus.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.Color.Ivory;
            this.btnHapus.Location = new System.Drawing.Point(267, 676);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(122, 36);
            this.btnHapus.TabIndex = 7;
            this.btnHapus.Text = "🗑️Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            // 
            // btnKembali
            // 
            this.btnKembali.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(713, 676);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(148, 36);
            this.btnKembali.TabIndex = 8;
            this.btnKembali.Text = " ⬅Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // Distribusi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1046, 743);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.grpDaftaRDistribusi);
            this.Controls.Add(this.grpDataDistribusi);
            this.Controls.Add(this.lblDistribusi);
            this.Controls.Add(this.label1);
            this.Name = "Distribusi";
            this.Text = "Distribusi";
            this.grpDataDistribusi.ResumeLayout(false);
            this.grpDataDistribusi.PerformLayout();
            this.grpDaftaRDistribusi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaftarDistribusii)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDistribusi;
        private System.Windows.Forms.GroupBox grpDataDistribusi;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpTanggalPemeriksaan;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblJumlahProduk;
        private System.Windows.Forms.TextBox txtJumlahProduk;
        private System.Windows.Forms.Label lblTanggalDistribusi;
        private System.Windows.Forms.TextBox txtIdProduksi;
        private System.Windows.Forms.Label lblIdProduks;
        private System.Windows.Forms.Label lblIdDistribusi;
        private System.Windows.Forms.TextBox txtIdDistribusi;
        private System.Windows.Forms.TextBox txtIdpenerima;
        private System.Windows.Forms.Label lblIdPenerima;
        private System.Windows.Forms.GroupBox grpDaftaRDistribusi;
        private System.Windows.Forms.DataGridView dgvDaftarDistribusii;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnKembali;
    }
}