using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class BankLain
    {
        private int id;
        private string nama;

        #region CONSTRUCTORS
        public BankLain(int id, string nama)
        {
            Id = id;
            Nama = nama;
        }
        public BankLain()
        {
            Id = 0;
            Nama = "";
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region METHODS
        public static List<BankLain> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from bankLain;";
            else //jika ada filter
                sql = "select * from bankLain where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<BankLain> listData = new List<BankLain>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(0).ToString()); //ambil isi datareader per kolom
                string nama = hasil.GetValue(1).ToString();
                BankLain k = new BankLain(id, nama); //buat 1 objek kategori
                listData.Add(k); //tambahkan objek kategori ke list
            }
            return listData;
        }
        public static void TambahData(BankLain b)
        {
            Koneksi kon = new Koneksi();
            string sql = "insert into bankLain (id,nama) values ('" + b.Id + "','" + b.Nama + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahData(BankLain b)
        {
            Koneksi kon = new Koneksi();
            string sql = "update bankLain set nama='" + b.Nama + "' where id='" + b.Id + "'";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void HapusData(string id)
        {
            Koneksi kon = new Koneksi();
            string sql = "delete from bankLain where id='" + id + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        #endregion
    }
}
