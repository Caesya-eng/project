using AgrowasteNexus.Database;
using AgroWasteNexus.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace AgroWasteNexus.Repositories
{
    public class JadwalPengangkutanRepository : BaseRepository<JadwalPengangkutan>
    {
        public List<PetugasCombo> GetPetugas()
        {
            List<PetugasCombo> list = new List<PetugasCombo>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT id_petugas, nama_petugas
            FROM petugas
            ORDER BY nama_petugas";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PetugasCombo
                        {
                            IdPetugas = Convert.ToInt32(reader["id_petugas"]),
                            NamaPetugas = reader["nama_petugas"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public List<KendaraanCombo> GetKendaraan()
        {
            List<KendaraanCombo> list = new List<KendaraanCombo>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT id_kendaraan, nama_kendaraan
            FROM kendaraan
            ORDER BY nama_kendaraan";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KendaraanCombo
                        {
                            IdKendaraan = Convert.ToInt32(reader["id_kendaraan"]),
                            NamaKendaraan = reader["nama_kendaraan"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public override List<JadwalPengangkutan> GetAll()
        {
            List<JadwalPengangkutan> list = new List<JadwalPengangkutan>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT *
                    FROM jadwal_pengangkutan
                    ORDER BY id_jadwal";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JadwalPengangkutan data = new JadwalPengangkutan();

                        data.IdJadwal = Convert.ToInt32(reader["id_jadwal"]);
                        data.TanggalPengangkutan = Convert.ToDateTime(reader["tanggal_pengangkutan"]);
                        data.Status = reader["status"].ToString();
                        data.Catatan = reader["catatan"].ToString();
                        data.IdPetugas = Convert.ToInt32(reader["petugas_id_petugas"]);
                        data.IdKendaraan = Convert.ToInt32(reader["kendaraan_id_kendaraan"]);

                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public List<JadwalPengangkutanGrid> GetGrid()
        {
            List<JadwalPengangkutanGrid> list = new List<JadwalPengangkutanGrid>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        id_jadwal,
                        petugas_id_petugas,
                        kendaraan_id_kendaraan,
                        tanggal_pengangkutan,
                        status_pengangkutan,
                        catatan,
                        nama_driver,
                        kontak_driver,
                        nama_kendaraan,
                        kapasitas_maksimal
                    FROM v_grid_jadwal_pengangkutan
                    ORDER BY id_jadwal";

                using (var cmd = new NpgsqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JadwalPengangkutanGrid data = new JadwalPengangkutanGrid();

                        data.id_jadwal = Convert.ToInt32(reader["id_jadwal"]);
                        data.petugas_id_petugas = Convert.ToInt32(reader["petugas_id_petugas"]);
                        data.kendaraan_id_kendaraan = Convert.ToInt32(reader["kendaraan_id_kendaraan"]);
                        data.tanggal_pengangkutan = Convert.ToDateTime(reader["tanggal_pengangkutan"]);
                        data.status_pengangkutan = reader["status_pengangkutan"].ToString();
                        data.catatan = reader["catatan"].ToString();
                        data.nama_driver = reader["nama_driver"].ToString();
                        data.kontak_driver = reader["kontak_driver"].ToString();
                        data.nama_kendaraan = reader["nama_kendaraan"].ToString();
                        data.kapasitas_maksimal = reader["kapasitas_maksimal"].ToString();

                        list.Add(data);
                    }
                }
            }

            return list;
        }

        public List<string> GetStatusJadwal()
        {
            List<string> list = new List<string>();

            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT enumlabel
                    FROM pg_enum
                    WHERE enumtypid = 'enum_status_jadwal'::regtype
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

        public void UpdateStatusJadwal(int idJadwal, string statusBaru)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            CALL sp_atur_status_jadwal(
                                @idJadwal,
                                CAST(@statusBaru AS enum_status_jadwal)
                            )";

                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("@idJadwal", idJadwal);
                            cmd.Parameters.AddWithValue("@statusBaru", statusBaru);
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
        public override void Insert(JadwalPengangkutan data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    INSERT INTO jadwal_pengangkutan
                    (
                        tanggal_pengangkutan,
                        status,
                        catatan,
                        petugas_id_petugas,
                        kendaraan_id_kendaraan
                    )
                    VALUES
                    (
                        @tanggal,
                        @status::enum_status_jadwal,
                        @catatan,
                        @idPetugas,
                        @idKendaraan
                    )";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tanggal", data.TanggalPengangkutan.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@catatan",
                        string.IsNullOrWhiteSpace(data.Catatan)
                        ? (object)DBNull.Value
                        : data.Catatan);
                    cmd.Parameters.AddWithValue("@idPetugas", data.IdPetugas);
                    cmd.Parameters.AddWithValue("@idKendaraan", data.IdKendaraan);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Update(JadwalPengangkutan data)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE jadwal_pengangkutan SET
                        tanggal_pengangkutan = @tanggal,
                        status = @status::enum_status_jadwal,
                        catatan = @catatan,
                        petugas_id_petugas = @idPetugas,
                        kendaraan_id_kendaraan = @idKendaraan
                    WHERE id_jadwal = @idJadwal";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idJadwal", data.IdJadwal);
                    cmd.Parameters.AddWithValue("@tanggal", data.TanggalPengangkutan.Date);
                    cmd.Parameters.AddWithValue("@status", data.Status);
                    cmd.Parameters.AddWithValue("@catatan",
                        string.IsNullOrWhiteSpace(data.Catatan)
                        ? (object)DBNull.Value
                        : data.Catatan);
                    cmd.Parameters.AddWithValue("@idPetugas", data.IdPetugas);
                    cmd.Parameters.AddWithValue("@idKendaraan", data.IdKendaraan);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public override void Delete(int id)
        {
            using (var conn = DbConnectionHelper.GetConnection())
            {
                conn.Open();

                string query = @"
                    DELETE FROM jadwal_pengangkutan
                    WHERE id_jadwal = @idJadwal";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idJadwal", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}