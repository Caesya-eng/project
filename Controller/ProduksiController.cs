using AgroWasteNexus.Models;
using AgroWasteNexus.Repositories;
using System;
using System.Collections.Generic;

namespace AgroWasteNexus.Controllers
{
    public class ProduksiController
    {
        private ProduksiRepository repository = new ProduksiRepository();

        public List<ProduksiGrid> GetDataProduksi()
        {
            return repository.GetGrid();
        }

        public List<string> GetStatusProduksi()
        {
            return repository.GetStatusProduksi();
        }

        public ControllerResult TambahProduksi(
            string idBatchText,
            string jumlahBahanText,
            string jumlahHasilText,
            string biayaProduksiText,
            object selectedValueProduk,
            string status,
            DateTime tanggalProduksi)
        {
            if (!int.TryParse(idBatchText, out int idBatch))
                return ControllerResult.Gagal("ID Batch harus berupa angka.");

            if (!decimal.TryParse(jumlahBahanText, out decimal jumlahBahan))
                return ControllerResult.Gagal("Jumlah bahan harus berupa angka.");

            if (!decimal.TryParse(jumlahHasilText, out decimal jumlahHasil))
                return ControllerResult.Gagal("Jumlah hasil harus berupa angka.");

            if (!decimal.TryParse(biayaProduksiText, out decimal biayaProduksi))
                return ControllerResult.Gagal("Biaya produksi harus berupa angka.");

            if (selectedValueProduk == null)
                return ControllerResult.Gagal("Pilih hasil produksi terlebih dahulu.");

            if (string.IsNullOrWhiteSpace(status))
                return ControllerResult.Gagal("Pilih status terlebih dahulu.");

            Produksi data = new Produksi
            {
                JumlahBahan = jumlahBahan,
                JumlahHasil = jumlahHasil,
                BiayaProduksi = biayaProduksi,
                TanggalProduksi = tanggalProduksi,
                Status = status,
                IdBatch = idBatch,
                IdProduk = Convert.ToInt32(selectedValueProduk),
                IdPengguna = 1
            };

            repository.Insert(data);

            return ControllerResult.Berhasil("Data produksi berhasil ditambahkan.");
        }

        public ControllerResult UpdateProduksi(
            string idProduksiText,
            string idBatchText,
            string jumlahBahanText,
            string jumlahHasilText,
            string biayaProduksiText,
            object selectedValueProduk,
            string status,
            DateTime tanggalProduksi)
        {
            if (!int.TryParse(idProduksiText, out int idProduksi))
                return ControllerResult.Gagal("Pilih data produksi yang akan diupdate.");

            if (!int.TryParse(idBatchText, out int idBatch))
                return ControllerResult.Gagal("ID Batch harus berupa angka.");

            if (!decimal.TryParse(jumlahBahanText, out decimal jumlahBahan))
                return ControllerResult.Gagal("Jumlah bahan harus berupa angka.");

            if (!decimal.TryParse(jumlahHasilText, out decimal jumlahHasil))
                return ControllerResult.Gagal("Jumlah hasil harus berupa angka.");

            if (!decimal.TryParse(biayaProduksiText, out decimal biayaProduksi))
                return ControllerResult.Gagal("Biaya produksi harus berupa angka.");

            if (selectedValueProduk == null)
                return ControllerResult.Gagal("Pilih hasil produksi terlebih dahulu.");

            if (string.IsNullOrWhiteSpace(status))
                return ControllerResult.Gagal("Pilih status terlebih dahulu.");

            Produksi data = new Produksi
            {
                IdProduksi = idProduksi,
                JumlahBahan = jumlahBahan,
                JumlahHasil = jumlahHasil,
                BiayaProduksi = biayaProduksi,
                TanggalProduksi = tanggalProduksi,
                Status = status,
                IdBatch = idBatch,
                IdProduk = Convert.ToInt32(selectedValueProduk),
                IdPengguna = 1
            };

            repository.Update(data);

            return ControllerResult.Berhasil("Data produksi berhasil diupdate.");
        }

        public ControllerResult HapusProduksi(string idProduksiText)
        {
            if (!int.TryParse(idProduksiText, out int idProduksi))
                return ControllerResult.Gagal("Pilih data produksi yang akan dihapus.");

            repository.Delete(idProduksi);

            return ControllerResult.Berhasil("Data produksi berhasil dihapus.");
        }
    }
}