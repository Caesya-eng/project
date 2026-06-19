using AgrowasteNexus.Database;
using AgroWasteNexus.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AgroWasteNexus.Repositories
{
    public class BatchLimbahRepository : BaseRepository<BatchLimbah>
    {
        public override List<BatchLimbah> GetAll()
        {
       
            return new List<BatchLimbah>();
        }

   
        public List<BatchLimbahGrid> GetGrid()
        {
            List<BatchLimbahGrid> list = new List<BatchLimbahGrid>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_batch,
                        pabrik_id_pabrik,
                        jadwal_pengangkutan_id_jadwal,
                        volume_kg,
                        tanggal_masuk,
                        status_batch,
                        keterangan,
                        nama_pabrik,
                        alamat_pabrik,
                        kontak_pabrik
                    FROM v_grid_batch_limbah
                    ORDER BY id_batch";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BatchLimbahGrid data = new BatchLimbahGrid();

                        data.id_batch = Convert.ToInt32(reader["id_batch"]);
                        data.pabrik_id_pabrik = Convert.ToInt32(reader["pabrik_id_pabrik"]);

                        if (reader["jadwal_pengangkutan_id_jadwal"] == DBNull.Value)
                            data.jadwal_pengangkutan_id_jadwal = null;
                        else
                            data.jadwal_pengangkutan_id_jadwal = Convert.ToInt32(reader["jadwal_pengangkutan_id_jadwal"]);

                        data.volume_kg = Convert.ToDecimal(reader["volume_kg"]);
                        data.tanggal_masuk = Convert.ToDateTime(reader["tanggal_masuk"]);
                        data.status_batch = reader["status_batch"].ToString();
                        data.keterangan = reader["keterangan"].ToString();
                        data.nama_pabrik = reader["nama_pabrik"].ToString();
                        data.alamat_pabrik = reader["alamat_pabrik"].ToString();
                        data.kontak_pabrik = reader["kontak_pabrik"].ToString();

                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public List<string> GetStatusBatch()
        {
            List<string> list = new List<string>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT enumlabel
                    FROM pg_enum
                    WHERE enumtypid = 'enum_status_batch'::regtype
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

        public override void Insert(BatchLimbah data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO batch_limbah
                    (
                        jumlah,
                        tanggal_masuk,
                        status,
                        gambar_barang,
                        keterangan,
                        pabrik_id_pabrik,
                        jadwal_pengangkutan_id_jadwal
                    )
                    VALUES
                    (
                        @jumlah,
                        @tanggalMasuk,
                        @status::enum_status_batch,
                        @gambarBarang,
                        @keterangan,
                        @idPabrik,
                        @idJadwal
                    )";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jumlah", data.Jumlah);
                    cmd.Parameters.AddWithValue("@tanggalMasuk", data.TanggalMasuk.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@gambarBarang", string.IsNullOrWhiteSpace(data.GambarBarang) ? (object)DBNull.Value : data.GambarBarang);
                    cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(data.Keterangan) ? (object)DBNull.Value : data.Keterangan);
                    cmd.Parameters.AddWithValue("@idPabrik", data.IdPabrik);
                    cmd.Parameters.AddWithValue("@idJadwal", data.IdJadwal.HasValue ? (object)data.IdJadwal.Value : DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Update(BatchLimbah data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE batch_limbah SET
                        jumlah = @jumlah,
                        tanggal_masuk = @tanggalMasuk,
                        status = @status::enum_status_batch,
                        gambar_barang = @gambarBarang,
                        keterangan = @keterangan,
                        pabrik_id_pabrik = @idPabrik,
                        jadwal_pengangkutan_id_jadwal = @idJadwal
                    WHERE id_batch = @idBatch";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idBatch", data.IdBatch);
                    cmd.Parameters.AddWithValue("@jumlah", data.Jumlah);
                    cmd.Parameters.AddWithValue("@tanggalMasuk", data.TanggalMasuk.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@gambarBarang", string.IsNullOrWhiteSpace(data.GambarBarang) ? (object)DBNull.Value : data.GambarBarang);
                    cmd.Parameters.AddWithValue("@keterangan", string.IsNullOrWhiteSpace(data.Keterangan) ? (object)DBNull.Value : data.Keterangan);
                    cmd.Parameters.AddWithValue("@idPabrik", data.IdPabrik);
                    cmd.Parameters.AddWithValue("@idJadwal", data.IdJadwal.HasValue ? (object)data.IdJadwal.Value : DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = "DELETE FROM batch_limbah WHERE id_batch = @idBatch";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idBatch", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}