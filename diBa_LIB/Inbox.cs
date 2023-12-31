using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Inbox
    {
        Pengguna user;
        int id;
        string pesan;
        DateTime tglKirim;
        string status;
        DateTime tglPerubahan;

        #region PROPERTIES
        public Pengguna User { get => user; set => user = value; }
        public int Id { get => id; set => id = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime TglKirim { get => tglKirim; set => tglKirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region CONSTRUCTORS
        public Inbox()
        {
            User = new Pengguna();
            Id = 0;
            Pesan = "";
            TglKirim = DateTime.Now;
            Status = "";
            TglPerubahan = DateTime.Now;
        }

        public Inbox(Pengguna user, int id, string pesan, DateTime tglKirim, string status, DateTime tglUbah)
        {
            User = user;
            Id = id;
            Pesan = pesan;
            TglKirim = tglKirim;
            Status = status;
            TglPerubahan = tglUbah;
        }
        #endregion

        #region METHODS
        public static List<Inbox> BacaData(string pengguna = "", string tgl = "")
        {
            // STEP 1. susun perintah query (butuh inner join karena harus ambil nama jabatan)
            string sql;
            if (tgl == "") //jika user tidak memberikan filter
                sql = "select i.*, p.nama_depan, p.nama_keluarga from inbox i inner join pengguna p on i.id_pengguna=p.nik where i.id_pengguna = '" +
                    pengguna + "' order by id_pesan DESC;";
            else //jika ada filter
                sql = "select i.*, p.nama_depan, p.nama_keluarga from inbox i inner join pengguna p on i.id_pengguna=p.nik where i.id_pengguna = '" + 
                    pengguna + "' AND tanggal_kirim = '" + tgl + "' order by id_pesan DESC;";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Inbox> listData = new List<Inbox>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(1).ToString());
                string pesan = hasil.GetValue(2).ToString();
                DateTime tglKirim = DateTime.Parse(hasil.GetValue(3).ToString());
                string status = hasil.GetValue(4).ToString();
                DateTime tglUbah = DateTime.Parse(hasil.GetValue(5).ToString());

                Pengguna user = new Pengguna();
                user.Nik = hasil.GetValue(0).ToString();
                user.NamaDepan = hasil.GetValue(6).ToString();
                user.NamaKeluarga = hasil.GetValue(7).ToString();

                Inbox i = new Inbox(user, id, pesan, tglKirim, status, tglUbah);
                listData.Add(i); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public static int GenerateIdPesan(Pengguna pengguna)
        {
            int id;
            string sql;
            sql = "select id_pesan from inbox where id_pengguna = '" + pengguna.Nik + "' order by id_pesan desc limit 1;";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            if (hasil.Read() == true)
            {
                id = int.Parse(hasil.GetValue(0).ToString()) + 1;
            }
            else
            {
                id = 1;
            }
            return id;
        }

        public static void TambahData(Pengguna p, string pesan)
        {
            string sql = "INSERT INTO inbox (id_pengguna, id_pesan, pesan, tanggal_kirim, status, tgl_perubahan) VALUES('" + 
                p.Nik + "', '" + GenerateIdPesan(p) + "', '" + pesan + "', current_date, 'diterima', current_date);";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahStatus(Pengguna user, int pID, string status)
        {
            string sql = "update inbox set status='" + status + "', tgl_perubahan = current_date where id_pesan= '" + pID + "' and id_pengguna = '" + user.Nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        #endregion
    }
}
