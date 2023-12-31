using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class TabunganEksternal
    {
        private BankLain idBank;
        private string noRekening;
        private string nama;

        public BankLain IdBank { get => idBank; set => idBank = value; }
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public string Nama { get => nama; set => nama = value; }

        public TabunganEksternal(BankLain idBank, string noRekening, string nama)
        {
            IdBank = idBank;
            NoRekening = noRekening;
            Nama = nama;
        }

        public TabunganEksternal()
        {
            IdBank = new BankLain();
            NoRekening = "";
            Nama = "";
        }

        public static TabunganEksternal BacaData(string norek)
        {
            string sql;
            sql = "SELECT * from tabunganeksternal where no_rekening = '" + norek + "';";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            TabunganEksternal te = new TabunganEksternal();
            if (hasil.Read() == true)
            {
                te.NoRekening = hasil.GetValue(1).ToString();
                te.Nama = hasil.GetValue(2).ToString();
                te.IdBank = BankLain.BacaData("id", hasil.GetValue(0).ToString())[0];
            }
            return te;
        }
        //public static void TambahData(TabunganEksternal t)
        //{
        //    string sql = "INSERT INTO tabunganEksternal(id_bank, no_rekening, nama_pemilik) VALUES ('" +
        //        t.IdBank + "', '" + t.NoRekening + "', '" + t.Nama + "');";
        //    Koneksi.JalankanPerintahNonQuery(sql);
        //}
    }
}
