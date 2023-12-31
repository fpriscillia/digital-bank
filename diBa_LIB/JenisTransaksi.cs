using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 

namespace diBa_LIB
{
    public class Jenis_Transaksi
    {
        private int id_Jenis_Transaksi;
        private string kode;
        private string nama;

        public Jenis_Transaksi(int id_Jenis_Transaksi, string kode, string nama)
        {
            Id_Jenis_Transaksi = id_Jenis_Transaksi;
            Kode = kode;
            Nama = nama;
        }
        public Jenis_Transaksi()
        {
            Id_Jenis_Transaksi = 0;
            Kode = "";
            Nama = "";
        }

        public int Id_Jenis_Transaksi { get => id_Jenis_Transaksi; set => id_Jenis_Transaksi = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }


        public static List<Jenis_Transaksi> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from jenisTransaksi;";
            else //jika ada filter
                sql = "select * from jenisTransaksi where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Jenis_Transaksi> listData = new List<Jenis_Transaksi>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(0).ToString());
                string kode = hasil.GetValue(1).ToString(); //ambil isi datareader per kolom
                string nama = hasil.GetValue(2).ToString();
                Jenis_Transaksi jenisTransaksi = new Jenis_Transaksi(id,kode, nama); //buat 1 objek kategori
                listData.Add(jenisTransaksi); //tambahkan objek kategori ke list
            }
            return listData;
        }
        public static void TambahData(Jenis_Transaksi jenisTransaksi)
        {
            string sql = "insert into jenisTransaksi (id_jenis_transaksi,kode,nama) values ('" + jenisTransaksi.Id_Jenis_Transaksi + "','" + jenisTransaksi.Kode +"','"
                + jenisTransaksi.Nama +"');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahData(Jenis_Transaksi jenisTransaksi)
        {
            string sql = "update jenisTransaksi set nama='" + jenisTransaksi.Nama+"',kode='" +jenisTransaksi.Kode+ "' where id_jenis_transaksi='" + jenisTransaksi.Id_Jenis_Transaksi + "'";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void HapusData(string id)
        {
            string sql = "delete from jenisTransaksi where id_jenis_transaksi='" + id + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public override string ToString()
        {
            return Nama;
        }
    }
}
