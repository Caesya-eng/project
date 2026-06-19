using AgrowasteNexus.Database;
using AgroWasteNexus.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AgroWasteNexus.Repositories
{
  
    public class DistribusiRepository : BaseRepository<Distribusi>
    {
       
        public override List<Distribusi> GetAll()
        {
            
            return new List<Distribusi>();
        }

        public List<DistribusiGrid> GetGrid()
        {
            List<DistribusiGrid> list = new List<DistribusiGrid>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_distribusi,
                        id_produk,
                        id_penerima,
                        tanggal_distribusi,
                        jumlah_keluar_kg,
                        status_distribusi,
                        nama_produk,
                        satuan,
                        nama_distributor,
                        alamat_tujuan
                    FROM v_grid_distribusi
                    ORDER BY id_distribusi";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DistribusiGrid data = new DistribusiGrid();

                        data.id_distribusi = Convert.ToInt32(reader["id_distribusi"]);
                        data.id_produk = Convert.ToInt32(reader["id_produk"]);
                        data.id_penerima = Convert.ToInt32(reader["id_penerima"]);
                        data.tanggal_distribusi = Convert.ToDateTime(reader["tanggal_distribusi"]);
                        data.jumlah_keluar_kg = Convert.ToDecimal(reader["jumlah_keluar_kg"]);
                        data.status_distribusi = reader["status_distribusi"].ToString();
                        data.nama_produk = reader["nama_produk"].ToString();
                        data.satuan = reader["satuan"].ToString();
                        data.nama_distributor = reader["nama_distributor"].ToString();
                        data.alamat_tujuan = reader["alamat_tujuan"].ToString();

                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public List<string> GetStatusDistribusi()
        {
            List<string> list = new List<string>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT enumlabel
                    FROM pg_enum
                    WHERE enumtypid = 'enum_status_distribusi'::regtype
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

        public override void Insert(Distribusi data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO distribusi
                    (
                        jumlah_produk,
                        tanggal_distribusi,
                        status,
                        produk_id_produk,
                        penerima_id_penerima
                    )
                    VALUES
                    (
                        @jumlahProduk,
                        @tanggalDistribusi,
                        @status::enum_status_distribusi,
                        @idProduk,
                        @idPenerima
                    )";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jumlahProduk", data.JumlahProduk);
                    cmd.Parameters.AddWithValue("@tanggalDistribusi", data.TanggalDistribusi.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@idProduk", data.IdProduk);
                    cmd.Parameters.AddWithValue("@idPenerima", data.IdPenerima);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Update(Distribusi data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE distribusi SET
                        jumlah_produk = @jumlahProduk,
                        tanggal_distribusi = @tanggalDistribusi,
                        status = @status::enum_status_distribusi,
                        produk_id_produk = @idProduk,
                        penerima_id_penerima = @idPenerima
                    WHERE id_distribusi = @idDistribusi";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idDistribusi", data.IdDistribusi);
                    cmd.Parameters.AddWithValue("@jumlahProduk", data.JumlahProduk);
                    cmd.Parameters.AddWithValue("@tanggalDistribusi", data.TanggalDistribusi.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@idProduk", data.IdProduk);
                    cmd.Parameters.AddWithValue("@idPenerima", data.IdPenerima);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM distribusi WHERE id_distribusi = @idDistribusi";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                  
                    cmd.Parameters.AddWithValue("@idDistribusi", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}