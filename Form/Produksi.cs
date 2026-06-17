using AgroWasteNexus.Controllers;
using AgroWasteNexus.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AgroWasteNexus.Forms
{
    public partial class Produksi : Form
    {
        private ProduksiController controller = new ProduksiController();

        public Produksi()
        {
            InitializeComponent();

            btnTambah.Click -= btnTambah_Click;
            btnTambah.Click += btnTambah_Click;

            btnUpdate.Click -= btnUpdate_Click;
            btnUpdate.Click += btnUpdate_Click;

            btnHapus.Click -= btnHapus_Click;
            btnHapus.Click += btnHapus_Click;

            btnKembali.Click -= btnKembali_Click;
            btnKembali.Click += btnKembali_Click;

            dgvDaftarProduksi.CellClick -= dgvDaftarProduksi_CellClick;
            dgvDaftarProduksi.CellClick += dgvDaftarProduksi_CellClick;
        }

        private void Produksi_Load(object sender, EventArgs e)
        {
            LoadStatus();
            LoadProdukDariGrid();
            LoadData();

            txtIdProduksi.ReadOnly = true;
        }

        private void LoadData()
        {
            try
            {
                dgvDaftarProduksi.AutoGenerateColumns = true;
                dgvDaftarProduksi.DataSource = null;
                dgvDaftarProduksi.DataSource = controller.GetDataProduksi();

                if (dgvDaftarProduksi.Columns.Contains("gambar_produk"))
                {
                    dgvDaftarProduksi.Columns["gambar_produk"].Visible = false;
                }

                if (dgvDaftarProduksi.Columns.Contains("foto_produk"))
                {
                    dgvDaftarProduksi.Columns["foto_produk"].HeaderText = "Foto Produk";
                    dgvDaftarProduksi.RowTemplate.Height = 90;

                    DataGridViewImageColumn imgCol =
                        dgvDaftarProduksi.Columns["foto_produk"] as DataGridViewImageColumn;

                    if (imgCol != null)
                    {
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }

                dgvDaftarProduksi.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data produksi!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadStatus()
        {
            try
            {
                cmbStatus.DataSource = null;
                cmbStatus.DataSource = controller.GetStatusProduksi();
                cmbStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat status!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LoadProdukDariGrid()
        {
            try
            {
                var gridData = controller.GetDataProduksi();

                List<ProdukItem> produkList = new List<ProdukItem>();
                HashSet<int> idProdukYangSudahAda = new HashSet<int>();

                foreach (var item in gridData)
                {
                    if (!idProdukYangSudahAda.Contains(item.id_produk))
                    {
                        produkList.Add(new ProdukItem
                        {
                            IdProduk = item.id_produk,
                            NamaProduk = item.nama_produk
                        });

                        idProdukYangSudahAda.Add(item.id_produk);
                    }
                }

                cmbHasilProduksi.DataSource = null;
                cmbHasilProduksi.DataSource = produkList;
                cmbHasilProduksi.DisplayMember = "NamaProduk";
                cmbHasilProduksi.ValueMember = "IdProduk";
                cmbHasilProduksi.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat hasil produksi!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvDaftarProduksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IsiFormDariGrid(e.RowIndex);
        }

        private void dgvDaftarProduksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IsiFormDariGrid(e.RowIndex);
        }

        private void IsiFormDariGrid(int rowIndex)
        {
            if (rowIndex < 0)
                return;

            DataGridViewRow row = dgvDaftarProduksi.Rows[rowIndex];

            txtIdProduksi.Text = row.Cells["id_produksi"].Value?.ToString();
            txtIdBatch.Text = row.Cells["id_batch_asal"].Value?.ToString();
            txtJumlahBahan.Text = row.Cells["bahan_baku_kg"].Value?.ToString();
            txtJumlahHasil.Text = row.Cells["target_hasil_kg"].Value?.ToString();
            txtBiayaProduksi.Text = row.Cells["biaya_produksi"].Value?.ToString();

            if (row.Cells["tanggal_produksi"].Value != null)
            {
                dtpTanggalProduksi.Value =
                    Convert.ToDateTime(row.Cells["tanggal_produksi"].Value);
            }

            cmbStatus.Text = row.Cells["status_produksi"].Value?.ToString();

            if (row.Cells["id_produk"].Value != null)
            {
                cmbHasilProduksi.SelectedValue =
                    Convert.ToInt32(row.Cells["id_produk"].Value);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerResult result = controller.TambahProduksi(
                    txtIdBatch.Text,
                    txtJumlahBahan.Text,
                    txtJumlahHasil.Text,
                    txtBiayaProduksi.Text,
                    cmbHasilProduksi.SelectedValue,
                    cmbStatus.Text,
                    dtpTanggalProduksi.Value
                );

                MessageBox.Show(result.Pesan);

                if (!result.Sukses)
                    return;

                LoadProdukDariGrid();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menambah data!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerResult result = controller.UpdateProduksi(
                    txtIdProduksi.Text,
                    txtIdBatch.Text,
                    txtJumlahBahan.Text,
                    txtJumlahHasil.Text,
                    txtBiayaProduksi.Text,
                    cmbHasilProduksi.SelectedValue,
                    cmbStatus.Text,
                    dtpTanggalProduksi.Value
                );

                MessageBox.Show(result.Pesan);

                if (!result.Sukses)
                    return;

                LoadProdukDariGrid();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal update data!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult konfirmasi = MessageBox.Show(
                    "Yakin ingin menghapus data ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (konfirmasi == DialogResult.No)
                    return;

                ControllerResult result = controller.HapusProduksi(txtIdProduksi.Text);

                MessageBox.Show(result.Pesan);

                if (!result.Sukses)
                    return;

                LoadProdukDariGrid();
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus data!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearForm()
        {
            txtIdProduksi.Clear();
            txtIdBatch.Clear();
            txtJumlahBahan.Clear();
            txtJumlahHasil.Clear();
            txtBiayaProduksi.Clear();

            cmbHasilProduksi.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dtpTanggalProduksi.Value = DateTime.Now;
        }

        private class ProdukItem
        {
            public int IdProduk { get; set; }
            public string NamaProduk { get; set; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblJumlahHasil_Click(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}