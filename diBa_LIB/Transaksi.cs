using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.Drawing;
using System.IO;

namespace diBa_LIB
{
    public class Transaksi
    {
        private Tabungan rekSumber;
        private int id;
        private Jenis_Transaksi jenis;
        private DateTime tglTransaksi;
        private Tabungan rekTujuan;
        private double nominal;
        private string keterangan;

        #region CONSTRUCTORS
        public Transaksi()
        {
            RekSumber = new Tabungan();
            Id = 0;
            Jenis = new Jenis_Transaksi();
            TglTransaksi = DateTime.Now;
            RekTujuan = new Tabungan();
            Nominal = 0;
            Keterangan = "";
        }

        public Transaksi(Tabungan pSumber, int pId, Jenis_Transaksi pJenis, DateTime pTglTrx, Tabungan pTujuan, double pNominal, string pKeterangan)
        {
            RekSumber = pSumber;
            Id = pId;
            Jenis = pJenis;
            TglTransaksi = pTglTrx;
            RekTujuan = pTujuan;
            Nominal = pNominal;
            Keterangan = pKeterangan;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public DateTime TglTransaksi { get => tglTransaksi; set => tglTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public Tabungan RekSumber { get => rekSumber; set => rekSumber = value; }
        public Jenis_Transaksi Jenis { get => jenis; set => jenis = value; }
        public Tabungan RekTujuan { get => rekTujuan; set => rekTujuan = value; }
        #endregion

        #region METHODS
        public static int GenerateIdTransaksi(Tabungan sumber)
        {
            int id;
            string sql;
            sql = "select id_transaksi from transaksiinternal where rekening_sumber = '" + sumber.NoRekening + "' order by id_transaksi desc limit 1;";
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

        public static void TambahData(Transaksi t)
        {
            if (t.RekSumber.Status == "aktif")
            {
                string sql = "select sum(nominal) from transaksiinternal where rekening_sumber = '" + t.RekSumber.NoRekening + "' and id_jenis_transaksi = 1 and tgl_transaksi = current_date;";
                MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

                hasil.Read();
                string uang = hasil.GetValue(0).ToString();
                double tf = 0;
                if (uang != "")
                {
                    tf = double.Parse(uang);
                    
                }
                double limit = t.RekSumber.Pemilik.JenisPngguna.LimitTransfer;
                if (tf + t.Nominal > limit)
                {
                    throw new Exception("\nAnda telah mencapai limit transfer harian.\nLimit transfer harian Anda adalah Rp" + limit);
                }
                else
                {
                    string sql1 = "insert into transaksiinternal(rekening_sumber, id_transaksi, tgl_transaksi, id_jenis_transaksi," +
                    "rekening_tujuan, nominal, keterangan) values ('" + t.RekSumber.NoRekening + "','" +
                    GenerateIdTransaksi(t.RekSumber) + "','" + t.TglTransaksi.ToString("yyyy-MM-dd") + "','" + t.Jenis.Id_Jenis_Transaksi +
                    "','" + t.RekTujuan.NoRekening + "','" + t.Nominal + "','" + t.Keterangan + "');";
                    Koneksi.JalankanPerintahNonQuery(sql1);
                }
            }
            else
            {
                throw new Exception("\nAkun Anda belum aktif atau terblokir, Anda tidak dapat melakukan transaksi.\nHarap hubungi pegawai DiBa untuk mengaktifkan.");
            }
        }

        public static List<Transaksi> BacaData(string norek, string jenis = "", string tglMulai = "", string tglAkhir = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (jenis == "" && tglMulai == "")
                sql = "select * from transaksiinternal where rekening_sumber = '" + norek + "' or rekening_tujuan = '" + norek + "' order by id_transaksi;";
            else if (jenis == "")
                sql = "select * from transaksiinternal where (rekening_sumber = '" + norek + "' or rekening_tujuan = '" + norek + 
                    "') and tgl_transaksi between '" + tglMulai + "' and '" + tglAkhir + "' order by id_transaksi;";
            else if (jenis == "1")
                sql = "select * from transaksiinternal where (rekening_sumber = '" + norek + "') and tgl_transaksi between '" 
                    + tglMulai + "' and '" + tglAkhir + "' order by id_transaksi;";
            else
                sql = "select * from transaksiinternal where (rekening_tujuan = '" + norek + "') and tgl_transaksi between '"
                    + tglMulai + "' and '" + tglAkhir + "' order by id_transaksi;";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Transaksi> listData = new List<Transaksi>();
            while (hasil.Read() == true)
            {
                Transaksi ti = new Transaksi(); //buat 1 objek kategori
                ti.RekSumber = Tabungan.BacaData("no_rekening",hasil.GetValue(0).ToString())[0];
                ti.Id = int.Parse(hasil.GetValue(1).ToString());
                if (norek != ti.RekSumber.NoRekening)
                {
                    ti.Jenis = Jenis_Transaksi.BacaData("kode", "CRT")[0];
                }
                else
                {
                    ti.Jenis = Jenis_Transaksi.BacaData("id_jenis_transaksi", hasil.GetValue(2).ToString())[0];
                }
                ti.TglTransaksi = DateTime.Parse(hasil.GetValue(3).ToString());
                ti.RekTujuan = Tabungan.BacaData("no_rekening", hasil.GetValue(4).ToString())[0];
                ti.nominal = double.Parse(hasil.GetValue(5).ToString());
                ti.Keterangan = hasil.GetValue(6).ToString();

                listData.Add(ti); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public static void CetakTransaksi(Tabungan t, string jenis, string tglMulai, string tglAkhir)
        {
            //step 1 tentukan tipe font            
            Font tipeFont = new Font("Lucida Console", 10);

            //step 2 tentukan data yang akan dicetak
            List<Transaksi> listData = Transaksi.BacaData(t.NoRekening, jenis, tglMulai, tglAkhir);
            List<TransaksiEksternal> listData2 = TransaksiEksternal.BacaData(t.NoRekening, jenis, tglMulai, tglAkhir);

            //step 3 buat filetext
            string namaFile = "[MUTASI] " + t.NoRekening + "_" + DateTime.Now.ToString("yyyyMMdd");
            StreamWriter fileCetak = new StreamWriter(namaFile);
            
            fileCetak.WriteLine("");
            fileCetak.WriteLine("MUTASI TRANSAKSI\n");
            fileCetak.WriteLine("Nomor Rekening\t: " + t.NoRekening + "\n");
            fileCetak.WriteLine("Nama\t\t\t: " + t.Pemilik.NamaDepan + " " + t.Pemilik.NamaKeluarga + "\n");
            fileCetak.WriteLine("Periode\t\t: " + tglMulai + " - " + tglAkhir + "\n");
            fileCetak.WriteLine("=".PadRight(90, '='));
            fileCetak.Write("Tanggal".PadRight(10) + "\t");
            fileCetak.Write("Jenis\t");
            fileCetak.Write("Rekening".PadRight(35));
            fileCetak.Write("Nominal".PadRight(15));
            fileCetak.Write("Keterangan");
            fileCetak.WriteLine("");
            fileCetak.WriteLine("=".PadRight(90, '='));
            fileCetak.WriteLine("");
            foreach (Transaksi trx in listData)
            {
                string nama;
                string norek;
                if (trx.RekSumber.NoRekening == t.NoRekening)
                {
                    nama = trx.RekTujuan.Pemilik.NamaDepan + " " + trx.RekTujuan.Pemilik.NamaKeluarga;
                    norek = trx.RekTujuan.NoRekening;
                }
                else
                {
                    nama = trx.RekSumber.Pemilik.NamaDepan + " " + trx.RekSumber.Pemilik.NamaKeluarga;
                    norek = trx.RekSumber.NoRekening;
                }

                fileCetak.WriteLine(trx.TglTransaksi.ToString("dd/MM/yyyy") + "\t" + trx.Jenis.Kode.PadRight(5) + "\t" +
                    norek + "  " + nama.PadRight(20) + "   Rp" + trx.Nominal.ToString().PadRight(13) + trx.Keterangan.PadRight(20) + "\n");
            }
            foreach(TransaksiEksternal trex in listData2)
            {
                fileCetak.WriteLine(trex.TglTransaksi.ToString("dd/MM/yyyy") + "\t" + trex.Jenis.Kode.PadRight(5) + "\t" +
                    trex.RekEksternal.NoRekening + "  " + trex.RekEksternal.Nama.PadRight(20) + "   Rp" + 
                    trex.Nominal.ToString().PadRight(13) + trex.Keterangan.PadRight(20) + "\n");
            }
            fileCetak.WriteLine("=".PadRight(90, '='));
            fileCetak.WriteLine("");
            fileCetak.WriteLine("Dicetak tanggal\t: " + DateTime.Now.ToString("dd/MM/yyyy"));
            fileCetak.Close();

            CustomPrint p = new CustomPrint(tipeFont, namaFile, 30, 10, 30, 10);
            p.KirimkePrinter();
        }
        #endregion

    }
}
