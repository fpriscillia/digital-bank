using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Deposito
    {
        private string id_deposito;
        private Tabungan no_rekening;
        private string jatuh_tempo;
        private double nominal;
        private double bunga;
        private string status;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private Employee vBuka;
        private Employee vCair;

        #region CONSTRUCTORS
        public Deposito(string id_deposito, Tabungan no_rekening, string jatuh_tempo, double nominal, double bunga, string status, DateTime tgl_buat, DateTime tgl_perubahan, Employee vBuka, Employee vCair)
        {
            Id_deposito = id_deposito;
            No_rekening = no_rekening;
            Jatuh_tempo = jatuh_tempo;
            Nominal = nominal;
            Bunga = bunga;
            Status = status;
            Tgl_buat = tgl_buat;
            Tgl_perubahan = tgl_perubahan;
            VBuka = vBuka;
            VCair = vCair;
        }
        public Deposito()
        {
            Id_deposito = "";
            No_rekening = new Tabungan();
            Jatuh_tempo = "";
            Nominal = 0;
            Bunga = 0;
            Status = "";
            Tgl_buat = DateTime.Now;
            Tgl_perubahan = DateTime.Now;
            VBuka = new Employee();
            VCair = new Employee();
        }
        #endregion

        #region PROPERTIES
        public string Id_deposito { get => id_deposito; set => id_deposito = value; }
        public Tabungan No_rekening { get => no_rekening; set => no_rekening = value; }
        public string Jatuh_tempo { get => jatuh_tempo; set => jatuh_tempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double Bunga { get => bunga; set => bunga = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee VBuka { get => vBuka; set => vBuka = value; }
        public Employee VCair { get => vCair; set => vCair = value; }
        #endregion

        #region METHODS
        public static void TambahData(Deposito d,Tabungan t)
        {
            string sql = "INSERT INTO deposito (id_deposito, no_rekening, jatuh_tempo, nominal, bunga, status, tgl_buat, tgl_perubahan, verifikator_buka, verifikator_cair) " +
                "VALUES('" + d.Id_deposito + "', '" + d.No_rekening.NoRekening + "', '" + d.Jatuh_tempo + "', '" + d.Nominal + "', '" + d.Bunga + "', 'unverified', current_date, current_date, '1', '1');";
            
            Tabungan.UbahSaldo(t.NoRekening,-1 * d.Nominal);
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public override string ToString()
        {
            return No_rekening.ToString();
        }

        public static string GenerateNoDeposit(Tabungan t)
        {
            string noNota;
            string sql;
            sql = "select id_deposito from deposito where tgl_buat = current_date order by id_deposito desc limit 1;";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);
            
            string kodeNoRek = t.NoRekening.Substring(6, 4);

            if (hasil.Read() == true)
            {
                int kode = int.Parse(hasil.GetValue(0).ToString().Substring(16, 4)) + 1;
                noNota = DateTime.Now.ToString("yyyy/MM/dd") + "/" + kodeNoRek + "/" + kode.ToString().PadLeft(4, '0');

            }
            else
                noNota = DateTime.Now.ToString("yyyy/MM/dd") + "/" + kodeNoRek + "/" + "0001";
            return noNota;
        }

        public static List<Deposito> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "SELECT * FROM deposito;";
            else //jika ada filter
                sql = "SELECT * FROM deposito where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Deposito> listData = new List<Deposito>();
            while (hasil.Read() == true)
            {
                Deposito d = new Deposito(); //buat 1 objek kategori              

                d.Id_deposito = hasil.GetValue(0).ToString();
                d.No_rekening = Tabungan.BacaData("no_rekening", hasil.GetValue(1).ToString())[0];
                d.Jatuh_tempo = hasil.GetValue(2).ToString();
                d.Nominal = double.Parse(hasil.GetValue(3).ToString());
                d.Bunga = double.Parse(hasil.GetValue(4).ToString());
                d.Status = hasil.GetValue(5).ToString();
                d.Tgl_buat = DateTime.Parse(hasil.GetValue(6).ToString());
                d.Tgl_perubahan = DateTime.Parse(hasil.GetValue(7).ToString());
                d.VBuka = Employee.BacaData("e.id", hasil.GetValue(8).ToString())[0];
                d.VCair = Employee.BacaData("e.id", hasil.GetValue(9).ToString())[0];

                listData.Add(d); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public static void Verif(string pID, Employee e)
        {
            string sql = "update deposito set status = 'aktif', verifikator_buka = '" + e.Id + "', tgl_perubahan = current_date where id_deposito='" + pID+"';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void RequestCair(string pID)
        {
            string sql = "update deposito set status = 'cair' where id_deposito='" + pID + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static bool CekPencairan(Deposito d, DateTime tanggalPencairan)
        {
            DateTime tgl_JatuhTempo = DateTime.Now;
            if (d.Jatuh_tempo == "1 bulan")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddMonths(1);
            }
            else if (d.Jatuh_tempo == "3 bulan")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddMonths(3);
            }
            else if (d.Jatuh_tempo == "6 bulan")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddMonths(6);
            }
            else if (d.Jatuh_tempo == "1 tahun")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddYears(1);
            }
            else if (d.Jatuh_tempo == "2 tahun")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddYears(2);
            }
            else if (d.Jatuh_tempo == "3 tahun")
            {
                tgl_JatuhTempo = d.Tgl_perubahan.AddYears(3);
            }

            if (tgl_JatuhTempo > tanggalPencairan)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
        public static void Pencairan(Deposito d, Tabungan t, DateTime tanggalPencairan, Employee e)
        {
            string sql = "update deposito set status = 'nonaktif', verifikator_cair = '" + e.Id + "', tgl_perubahan = current_date where id_deposito='" + d.Id_deposito + "';";
            Koneksi.JalankanPerintahNonQuery(sql);

            double nominal = d.Nominal;
            if (CekPencairan(d, tanggalPencairan))
            {
                nominal = d.nominal + (d.Nominal * (d.Bunga / 100));
            }
            else
            {
                nominal = d.nominal - (d.Nominal * 0.05);
            }
            Tabungan.UbahSaldo(t.NoRekening, nominal);
        }
        #endregion
    }
}
