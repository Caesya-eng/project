using AgroWasteNexus.Repositories;
using System;
using System.Windows.Forms;
using DistribusiModel = AgroWasteNexus.Models.Distribusi;

namespace AgroWasteNexus.Forms
{
    public partial class Distribusi : Form
    {
        private DistribusiRepository repository = new DistribusiRepository();

        public Distribusi()
        {
            InitializeComponent();

            this.Load -= Distribusi_Load;
            this.Load += Distribusi_Load;

            btnTambah.Click -= btnTambah_Click;
            btnTambah.Click += btnTambah_Click;

            btnUpdate.Click -= btnUpdate_Click;
            btnUpdate.Click += btnUpdate_Click;

            btnHapus.Click -= btnHapus_Click;
            btnHapus.Click += btnHapus_Click;

            dgvDaftarDistribusii.CellClick -= dgvDaftarDistribusii_CellClick;
            dgvDaftarDistribusii.CellClick += dgvDaftarDistribusii_CellClick;
        }

        private void Distribusi_Load(object sender, EventArgs e)
        {
            LoadStatus();
            LoadDataGrid();

            txtIdDistribusi.ReadOnly = true;
            txtIdDistribusi.Clear();
        }

        private void LoadDataGrid()
        {
            try
            {
                dgvDaftarDistribusii.AutoGenerateColumns = true;
                dgvDaftarDistribusii.DataSource = null;
                dgvDaftarDistribusii.DataSource = repository.GetGrid();
                dgvDaftarDistribusii.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDaftarDistribusii.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan DataGridView:\n\n" + ex.Message,
                    "Error DataGridView",
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
                cmbStatus.DataSource = repository.GetStatusDistribusi();
                cmbStatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat status:\n\n" + ex.Message,
                    "Error Status",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private bool AmbilDataDariForm(out DistribusiModel data, bool pakaiIdDistribusi)
        {
            data = new DistribusiModel();

            if (pakaiIdDistribusi)
            {
                if (!int.TryParse(txtIdDistribusi.Text, out int idDistribusi))
                {
                    MessageBox.Show("Pilih data distribusi terlebih dahulu.");
                    return false;
                }

                data.IdDistribusi = idDistribusi;
            }

            if (!int.TryParse(txtIdProduksi.Text, out int idProduk))
            {
                MessageBox.Show("ID Produk harus berupa angka.");
                return false;
            }

            if (!int.TryParse(txtIdpenerima.Text, out int idPenerima))
            {
                MessageBox.Show("ID Penerima harus berupa angka.");
                return false;
            }

            if (!decimal.TryParse(txtJumlahProduk.Text, out decimal jumlahProduk))
            {
                MessageBox.Show("Jumlah produk harus berupa angka.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Pilih status terlebih dahulu.");
                return false;
            }

            data.IdProduk = idProduk;
            data.IdPenerima = idPenerima;
            data.JumlahProduk = jumlahProduk;
            data.TanggalDistribusi = dtpTanggalPemeriksaan.Value;
            data.Status = cmbStatus.Text;

            return true;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            try
            {
                if (!AmbilDataDariForm(out DistribusiModel data, false))
                    return;

                repository.Insert(data);

                MessageBox.Show("Data distribusi berhasil ditambahkan.");

                LoadDataGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal tambah data:\n\n" + ex.Message,
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
                if (!AmbilDataDariForm(out DistribusiModel data, true))
                    return;

                repository.Update(data);

                MessageBox.Show("Data distribusi berhasil diupdate.");

                LoadDataGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal update data:\n\n" + ex.Message,
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
                if (!int.TryParse(txtIdDistribusi.Text, out int idDistribusi))
                {
                    MessageBox.Show("Pilih data distribusi yang akan dihapus.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Yakin ingin menghapus data ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                    return;

                repository.Delete(idDistribusi);

                MessageBox.Show("Data distribusi berhasil dihapus.");

                LoadDataGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal hapus data:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvDaftarDistribusii_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IsiFormDariGrid(e.RowIndex);
        }

        private void dgvDaftarDistribusii_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IsiFormDariGrid(e.RowIndex);
        }

        private void IsiFormDariGrid(int rowIndex)
        {
            if (rowIndex < 0)
                return;

            DataGridViewRow row = dgvDaftarDistribusii.Rows[rowIndex];

            txtIdDistribusi.Text = row.Cells["id_distribusi"].Value?.ToString();
            txtIdProduksi.Text = row.Cells["id_produk"].Value?.ToString();
            txtIdpenerima.Text = row.Cells["id_penerima"].Value?.ToString();
            txtJumlahProduk.Text = row.Cells["jumlah_keluar_kg"].Value?.ToString();

            if (row.Cells["tanggal_distribusi"].Value != null &&
                row.Cells["tanggal_distribusi"].Value != DBNull.Value)
            {
                dtpTanggalPemeriksaan.Value =
                    Convert.ToDateTime(row.Cells["tanggal_distribusi"].Value);
            }

            cmbStatus.Text = row.Cells["status_distribusi"].Value?.ToString();
        }

        private void ClearForm()
        {
            txtIdDistribusi.Clear();
            txtIdProduksi.Clear();
            txtIdpenerima.Clear();
            txtJumlahProduk.Clear();

            cmbStatus.SelectedIndex = -1;
            dtpTanggalPemeriksaan.Value = DateTime.Now;
        }

        private void lblDistribusi_Click(object sender, EventArgs e)
        {

        }

        private void lblIdProduks_Click(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}