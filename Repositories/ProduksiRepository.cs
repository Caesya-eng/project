using AgrowasteNexus.Database;
using AgroWasteNexus.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AgroWasteNexus.Repositories
{
    public class ProduksiRepository
    {
        public List<ProduksiGrid> GetGrid()
        {
            List<ProduksiGrid> list = new List<ProduksiGrid>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_produksi,
                        id_batch_asal,
                        id_produk,
                        id_pengguna,
                        asal_pabrik_limbah,
                        tanggal_produksi,
                        bahan_baku_kg,
                        target_hasil_kg,
                        biaya_produksi,
                        status_produksi,
                        nama_produk,
                        gambar_produk
                    FROM v_grid_produksi
                    ORDER BY id_produksi";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProduksiGrid data = new ProduksiGrid();

                        data.id_produksi = Convert.ToInt32(reader["id_produksi"]);
                        data.id_batch_asal = Convert.ToInt32(reader["id_batch_asal"]);
                        data.id_produk = Convert.ToInt32(reader["id_produk"]);
                        data.id_pengguna = Convert.ToInt32(reader["id_pengguna"]);
                        data.asal_pabrik_limbah = reader["asal_pabrik_limbah"].ToString();
                        data.tanggal_produksi = Convert.ToDateTime(reader["tanggal_produksi"]);
                        data.bahan_baku_kg = Convert.ToDecimal(reader["bahan_baku_kg"]);
                        data.target_hasil_kg = Convert.ToDecimal(reader["target_hasil_kg"]);
                        data.biaya_produksi = Convert.ToDecimal(reader["biaya_produksi"]);
                        data.status_produksi = reader["status_produksi"].ToString();
                        data.nama_produk = reader["nama_produk"].ToString();

                        data.gambar_produk = reader["gambar_produk"] == DBNull.Value
                            ? ""
                            : reader["gambar_produk"].ToString();

                        data.foto_produk = LoadFotoProduk(data.gambar_produk);

                        list.Add(data);
                    }
                }
            }

            return list;
        }

        private Image LoadFotoProduk(string namaFile)
        {
            if (string.IsNullOrWhiteSpace(namaFile))
                return null;

            string path = Path.Combine(
                Application.StartupPath,
                "Images",
                "Produk",
                namaFile
            );

            if (!File.Exists(path))
                return null;

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Image img = Image.FromStream(fs);
                return new Bitmap(img, new Size(80, 80));
            }
        }

        public List<string> GetStatusProduksi()
        {
            List<string> list = new List<string>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT enumlabel
                    FROM pg_enum
                    WHERE enumtypid = 'enum_status_produksi'::regtype
                    ORDER BY enumsortorder";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }
            }

            return list;
        }

        public void Insert(Produksi data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO produksi
                    (
                        jumlah_bahan,
                        jumlah_hasil,
                        biaya_produksi,
                        tanggal_produksi,
                        status,
                        batch_limbah_id_batch,
                        pengguna_id_pengguna,
                        produk_id_produk
                    )
                    VALUES
                    (
                        @jumlahBahan,
                        @jumlahHasil,
                        @biayaProduksi,
                        @tanggalProduksi,
                        @status::enum_status_produksi,
                        @idBatch,
                        @idPengguna,
                        @idProduk
                    )";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jumlahBahan", data.JumlahBahan);
                    cmd.Parameters.AddWithValue("@jumlahHasil", data.JumlahHasil);
                    cmd.Parameters.AddWithValue("@biayaProduksi", data.BiayaProduksi);
                    cmd.Parameters.AddWithValue("@tanggalProduksi", data.TanggalProduksi.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@idBatch", data.IdBatch);
                    cmd.Parameters.AddWithValue("@idPengguna", data.IdPengguna);
                    cmd.Parameters.AddWithValue("@idProduk", data.IdProduk);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Produksi data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryUpdate = @"
                    UPDATE produksi SET
                        jumlah_bahan = @jumlahBahan,
                        jumlah_hasil = @jumlahHasil,
                        biaya_produksi = @biayaProduksi,
                        tanggal_produksi = @tanggalProduksi,
                        batch_limbah_id_batch = @idBatch,
                        pengguna_id_pengguna = @idPengguna,
                        produk_id_produk = @idProduk
                    WHERE id_produksi = @idProduksi";

                        using (var cmd = new NpgsqlCommand(queryUpdate, conn))
                        {
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@idProduksi", data.IdProduksi);
                            cmd.Parameters.AddWithValue("@jumlahBahan", data.JumlahBahan);
                            cmd.Parameters.AddWithValue("@jumlahHasil", data.JumlahHasil);
                            cmd.Parameters.AddWithValue("@biayaProduksi", data.BiayaProduksi);
                            cmd.Parameters.AddWithValue("@tanggalProduksi", data.TanggalProduksi.Date);
                            cmd.Parameters.AddWithValue("@idBatch", data.IdBatch);
                            cmd.Parameters.AddWithValue("@idPengguna", data.IdPengguna);
                            cmd.Parameters.AddWithValue("@idProduk", data.IdProduk);

                            cmd.ExecuteNonQuery();
                        }

                        string queryStatus = @"
                    CALL sp_atur_status_produksi(
                        @idProduksi,
                        CAST(@status AS enum_status_produksi)
                    )";

                        using (var cmd = new NpgsqlCommand(queryStatus, conn))
                        {
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@idProduksi", data.IdProduksi);
                            cmd.Parameters.AddWithValue("@status", data.Status);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(int idProduksi)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM produksi WHERE id_produksi = @idProduksi";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idProduksi", idProduksi);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}