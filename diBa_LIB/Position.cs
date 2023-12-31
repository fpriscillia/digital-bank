using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Position
    {
        private int id;
        private string nama;
        private string keterangan;

        public Position(int id, string nama, string keterangan)
        {
            Id = id;
            Nama = nama;
            Keterangan = keterangan;
        }
        public Position()
        {
            Id = 0;
            Nama = "";
            Keterangan = "";
        }

        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }

        public static List<Position> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from position;";
            else //jika ada filter
                sql = "select * from position where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Position> listData = new List<Position>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(0).ToString()); //ambil isi datareader per kolom
                string nama = hasil.GetValue(1).ToString();
                string keterangan = hasil.GetValue(2).ToString();
                Position k = new Position(id,nama, keterangan); //buat 1 objek kategori
                listData.Add(k); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public static void TambahData(Position p)
        {
            string sql = "insert into position (id,nama, keterangan) values ('" + p.Id + "','" + p.Nama + "','"+p.Keterangan+"');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahData(Position p)
        {
            string sql = "update position set nama='" + p.Nama +"', keterangan= '" +p.Keterangan+"' where id='" + p.Id + "'";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void HapusData(int id)
        {
            string sql = "delete from position where id='" + id + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public override string ToString()
        {
            return nama;
        }
    }
}
