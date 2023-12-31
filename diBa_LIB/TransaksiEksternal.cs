using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class TransaksiEksternal
    {
        private Tabungan rekInternal;
        private int id;
        private Jenis_Transaksi jenis;
        private BankLain idBank;
        private TabunganEksternal rekEksternal;
        private DateTime tglTransaksi;
        private double nominal;
        private string keterangan;

        #region CONSTRUCTORS
        public TransaksiEksternal(Tabungan rekInternal, int id, Jenis_Transaksi jenis, BankLain idBank, TabunganEksternal rekEksternal, DateTime tglTransaksi, double nominal, string keterangan)
        {
            RekInternal = rekInternal;
            Id = id;
            Jenis = jenis;
            IdBank = idBank;
            RekEksternal = rekEksternal;
            TglTransaksi = tglTransaksi;
            Nominal = nominal;
            Keterangan = keterangan;
        }

        public TransaksiEksternal()
        {
            RekInternal = new Tabungan();
            Id = 0;
            Jenis = new Jenis_Transaksi();
            IdBank = new BankLain();
            RekEksternal = new TabunganEksternal();
            TglTransaksi = DateTime.Now;
            Nominal = 0;
            Keterangan = "";
        }
        #endregion

        #region PROPERTIES
        public Tabungan RekInternal { get => rekInternal; set => rekInternal = value; }
        public int Id { get => id; set => id = value; }
        public Jenis_Transaksi Jenis { get => jenis; set => jenis = value; }
        public TabunganEksternal RekEksternal { get => rekEksternal; set => rekEksternal = value; }
        public DateTime TglTransaksi { get => tglTransaksi; set => tglTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public BankLain IdBank { get => idBank; set => idBank = value; }
        #endregion

        #region METHODS
        public static int GenerateIdTransaksi(Tabungan sumber)
        {
            int id;
            string sql;
            sql = "select id_transaksi from transaksieksternal where rekening_internal = '" + sumber.NoRekening + "' order by id_transaksi desc limit 1;";
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

        public static void TambahData(TransaksiEksternal t)
        {
            if (t.RekInternal.Status == "aktif")
            {
                string sql = "insert into transaksieksternal(rekening_internal, id_transaksi, id_jenis_transaksi, id_bank," +
                "rekening_eksternal, tgl_transaksi, nominal, keterangan) values ('" + t.RekInternal.NoRekening + "','" +
                GenerateIdTransaksi(t.RekInternal) + "','" + t.Jenis.Id_Jenis_Transaksi + "','" + t.IdBank.Id + "','" + t.RekEksternal.NoRekening +
                "','" + t.TglTransaksi.ToString("yyyy-MM-dd") + "','" + t.Nominal + "','" + t.Keterangan + "');";
                Koneksi.JalankanPerintahNonQuery(sql);
            }
            else
            {
                throw new Exception("Akun Anda belum aktif atau terblokir, Anda tidak dapat melakukan transaksi.\nHarap hubungi pegawai DiBa.");
            }
        }

        public static List<TransaksiEksternal> BacaData(string norek, string jenis = "", string tglMulai = "", string tglAkhir = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (jenis == "" && tglMulai == "")
                sql = "select * from transaksieksternal where rekening_internal = '" + norek + "' order by id_transaksi;";
            else if (jenis == "")
                sql = "select * from transaksieksternal where rekening_internal = '" + norek + "' and tgl_transaksi between '" 
                    + tglMulai + "' and '" + tglAkhir + "' order by id_transaksi;";
            else
                sql = "select * from transaksieksternal where rekening_internal = '" + norek + "' and tgl_transaksi between '"
                    + tglMulai + "' and '" + tglAkhir + "' and id_jenis_transaksi = " + jenis + " order by id_transaksi;";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<TransaksiEksternal> listData = new List<TransaksiEksternal>();
            while (hasil.Read() == true)
            {
                TransaksiEksternal te = new TransaksiEksternal(); //buat 1 objek kategori

                te.RekInternal = Tabungan.BacaData("no_rekening",hasil.GetValue(0).ToString())[0];
                te.Id = int.Parse(hasil.GetValue(1).ToString());
                te.Jenis = Jenis_Transaksi.BacaData("id_jenis_transaksi", hasil.GetValue(2).ToString())[0];
                te.IdBank = BankLain.BacaData("id",hasil.GetValue(3).ToString())[0];
                te.RekEksternal = TabunganEksternal.BacaData(hasil.GetValue(4).ToString());
                te.TglTransaksi = DateTime.Parse(hasil.GetValue(5).ToString());
                te.nominal = double.Parse(hasil.GetValue(6).ToString());
                te.Keterangan = hasil.GetValue(7).ToString();
                listData.Add(te); //tambahkan objek kategori ke list
            }
            return listData;
        }
        #endregion
    }
}
