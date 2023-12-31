using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Tabungan
    {
        private string noRekening;
        private Pengguna pemilik;
        private double saldo;
        private string status;
        private string keterangan;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Employee verifikator;

        #region CONSTRUCTORS
        public Tabungan(string noRekening, Pengguna pemilik, double saldo, string status, string keterangan, 
            DateTime tglBuat, DateTime tglPerubahan, Employee verifikator)
        {
            NoRekening = noRekening;
            Pemilik = pemilik;
            Saldo = saldo;
            Status = status;
            Keterangan = keterangan;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            Verifikator = verifikator;
        }
        public Tabungan()
        {
            NoRekening = "";
            Pemilik = new Pengguna();
            Saldo = 0;
            Status = "unverified";
            Keterangan = "";
            TglBuat = DateTime.Now;
            TglPerubahan = DateTime.Now;
            Verifikator = new Employee();
        }
        #endregion

        #region PROPERTIES
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public Pengguna Pemilik { get => pemilik; set => pemilik = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee Verifikator { get => verifikator; set => verifikator = value; }
        #endregion

        #region METHODS 
        public static string GenerateNoRek()
        {
            string noRek;
            string sql;
            sql = "select no_rekening from tabunganinternal where tgl_buat = current_date order by no_rekening desc limit 1;";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            if (hasil.Read() == true)
            {
                int kode = int.Parse(hasil.GetValue(0).ToString().Substring(6, 4)) + 1;
                noRek = DateTime.Now.ToString("yyMMdd") + kode.ToString().PadLeft(4, '0');
            }
            else
            {
                noRek = DateTime.Now.ToString("yyMMdd") + "0001";
            }
            return noRek;
        }

        public static Tabungan CekLogin(Pengguna userLogin)
        {
            string sql = "select * from tabunganinternal where id_pengguna = '" + userLogin.Nik + "';";

            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            Tabungan tabLogin = new Tabungan();

            if (hasil.Read() == true)
            {   //urutan GetValue(0) adalah sesuai dengan SQL yang sudah disusun
                //jika menggunakan select * maka urutan sesuai dengan urutan dalam tabel yang dituju
                tabLogin.NoRekening = hasil.GetValue(0).ToString(); //ambil isi datareader per kolom
                tabLogin.Pemilik = userLogin;
                tabLogin.Saldo = double.Parse(hasil.GetValue(2).ToString());
                tabLogin.Status = hasil.GetValue(3).ToString();
                tabLogin.Keterangan = hasil.GetValue(4).ToString();
                tabLogin.TglBuat = DateTime.Parse(hasil.GetValue(5).ToString());
                tabLogin.TglPerubahan = DateTime.Parse(hasil.GetValue(6).ToString());
                tabLogin.Verifikator = Employee.BacaData("e.id", hasil.GetValue(7).ToString())[0];
            }
            else
            {
                tabLogin = null;
            }
            return tabLogin;
        }

        public static void TambahData(Tabungan t)
        {
            string sql = "INSERT INTO tabunganinternal(no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, tgl_perubahan, verifikator) VALUES ('" + 
                t.NoRekening + "', '" + t.pemilik.Nik + "', '" + t.Saldo + "', '" + t.Status + "', '" + t.Keterangan + "', '" + t.TglBuat.ToString("yyyy-MM-dd") + "', '" + t.TglPerubahan.ToString("yyyy-MM-dd") + "', '1');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public override string ToString()
        {
            return NoRekening.ToString();
        }

        public static void UbahStatus(Employee verifikator , string norek)
        {
            string sql = "update tabunganinternal set status = 'aktif', verifikator = '" + verifikator.Id +
                "', tgl_perubahan = current_date where no_rekening='" + norek + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void StatusSuspend(string status, string norek)
        {
            string sql = "update tabunganinternal set status = '" + status + "', tgl_perubahan = current_date where no_rekening='" + norek + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahSaldo(string noRek, double nominal)
        {
            if (Tabungan.BacaData("no_rekening", noRek)[0].Saldo + nominal >= 0)
            {
                string sql = "update tabunganinternal set saldo = saldo + '" + nominal +
                "', tgl_perubahan = current_date where no_rekening='" + noRek + "';";
                Koneksi.JalankanPerintahNonQuery(sql);
            }
            else
            {
                throw new Exception("Saldo anda tidak cukup");
            }
        }

        public static void HapusData(string norek)
        {
            string sql = "delete from tabunganinternal where no_rekening ='" + norek + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static List<Tabungan> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query (butuh inner join karena harus ambil nama jabatan)
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from tabunganinternal;";
            else //jika ada filter
                sql = "select * from tabunganinternal where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Tabungan> listData = new List<Tabungan>();
            while (hasil.Read() == true)
            {
                Tabungan t = new Tabungan();
                t.NoRekening = hasil.GetValue(0).ToString(); //ambil isi datareader per kolom
                t.Pemilik = Pengguna.BacaData("p.nik", hasil.GetValue(1).ToString())[0];
                t.Saldo = double.Parse(hasil.GetValue(2).ToString());
                t.Status = hasil.GetValue(3).ToString();
                t.Keterangan = hasil.GetValue(4).ToString();
                t.TglBuat = DateTime.Parse(hasil.GetValue(5).ToString());
                t.TglPerubahan = DateTime.Parse(hasil.GetValue(6).ToString());
                t.Verifikator = Employee.BacaData("e.id", hasil.GetValue(7).ToString())[0];

                listData.Add(t); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public static Tabungan BacaRekening(string norek)
        {
            string sql;
            sql = "SELECT * from tabunganinternal where no_rekening = '" + norek + "';";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            Tabungan t = new Tabungan();
            if (hasil.Read() == true)
            {
                t.NoRekening = hasil.GetValue(0).ToString();
                t.Pemilik = Pengguna.BacaData("p.nik", hasil.GetValue(1).ToString())[0];
                t.Saldo = double.Parse(hasil.GetValue(2).ToString());
                t.Status = hasil.GetValue(3).ToString();
                t.Keterangan = hasil.GetValue(4).ToString();
                t.TglBuat = DateTime.Parse(hasil.GetValue(5).ToString());
                t.TglPerubahan = DateTime.Parse(hasil.GetValue(6).ToString());
                t.Verifikator = Employee.BacaData("e.id", hasil.GetValue(7).ToString())[0];
            }
            return t;
        }
        #endregion
    }
}
