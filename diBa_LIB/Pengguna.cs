using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Pengguna
    {
        private string nik;
        private string namaDepan;
        private string namaKeluarga;
        private string alamat;
        private string email;
        private string noTelepon;
        private string password;
        private string pin;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private JenisPengguna jenisPngguna;
        private double reward;
        private List<AddressBookInternal> listAddressBookInternal;
        private List<AddressBookEksternal> listAddressBookEksternal;

        #region CONSTRUCTORS

        public Pengguna()
        {
            Nik = "";
            NamaDepan = "";
            NamaKeluarga = "";
            Alamat = "";
            Email = "";
            NoTelepon = "";
            Password = "";
            Pin = "0";
            TglBuat = DateTime.Now;
            TglPerubahan = DateTime.Now;
            JenisPngguna = new JenisPengguna();
            Reward = 0;
            ListAddressBookInternal = new List<AddressBookInternal>();
            listAddressBookEksternal = new List<AddressBookEksternal>();
        }

        public Pengguna(string nik, string namaDepan, string namaKeluarga, string alamat, string email,
            string noTelepon, string password, string pin, DateTime tglBuat, DateTime tglPerubahan, JenisPengguna jenis, double reward)
        {
            Nik = nik;
            NamaDepan = namaDepan;
            NamaKeluarga = namaKeluarga;
            Alamat = alamat;
            Email = email;
            NoTelepon = noTelepon;
            Password = password;
            Pin = pin;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            JenisPngguna = jenis;
            Reward = reward;
        }
        #endregion

        #region PROPERTIES
        public string Nik { get => nik; set => nik = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelepon { get => noTelepon; set => noTelepon = value; }
        public string Password { get => password; set => password = value; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public JenisPengguna JenisPngguna { get => jenisPngguna; set => jenisPngguna = value; }
        public double Reward { get => reward; set => reward = value; }
        public List<AddressBookInternal> ListAddressBookInternal { get => listAddressBookInternal; private set => listAddressBookInternal = value; }
        public List<AddressBookEksternal> ListAddressBookEksternal { get => listAddressBookEksternal; private set => listAddressBookEksternal = value; }
        #endregion

        #region METHODS PENGGUNA
        public static Pengguna CekLogin(string emailnohp, string pwd)
        {   
            //STEP 1. SUSUN SQL UNTUK CEK LOGIN
            string sql = "select * from pengguna p inner join jenisPengguna j on p.jenis_pengguna = j.id where (email='" + emailnohp + "' OR no_telepon='" + emailnohp + " ') and password=SHA2('" + pwd + "',512);";
            
            // STEP 2. JALANKAN perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. JIKA USERNAME DAN PWD TERDAFTAR, MASUKKAN KE OBJ PEGAWAI
            Pengguna userLogin = new Pengguna();

            if (hasil.Read() == true)
            {   //urutan GetValue(0) adalah sesuai dengan SQL yang sudah disusun
                //jika menggunakan select * maka urutan sesuai dengan urutan dalam tabel yang dituju
                userLogin.Nik = hasil.GetValue(0).ToString(); //ambil isi datareader per kolom
                userLogin.NamaDepan = hasil.GetValue(1).ToString();
                userLogin.NamaKeluarga = hasil.GetValue(2).ToString();
                userLogin.Alamat = hasil.GetValue(3).ToString();
                userLogin.Email = hasil.GetValue(4).ToString();
                userLogin.NoTelepon = hasil.GetValue(5).ToString();
                userLogin.Password = hasil.GetValue(6).ToString();
                userLogin.Pin = hasil.GetValue(7).ToString();
                userLogin.TglBuat = DateTime.Parse(hasil.GetValue(8).ToString());
                userLogin.TglPerubahan = DateTime.Parse(hasil.GetValue(9).ToString());
                userLogin.Reward = double.Parse(hasil.GetValue(11).ToString());

                JenisPengguna j = new JenisPengguna();
                j.Id = int.Parse(hasil.GetValue(12).ToString());
                j.Nama = hasil.GetValue(13).ToString();
                j.LimitTransfer = double.Parse(hasil.GetValue(14).ToString());
                j.BtsAtasReward = double.Parse(hasil.GetValue(15).ToString());
                userLogin.JenisPngguna = j;
            }
            else //jika username dan pwd tdk terdaftar, kembalikan null
            {
                userLogin = null;
            }
            return userLogin;
        }

        public static void TambahData(Pengguna p)
        {
            string sql = "insert into pengguna values ('" + p.Nik + "','" + p.NamaDepan + "','" + p.NamaKeluarga + "','" + p.Alamat + "','" + p.Email
                + "','" + p.NoTelepon + "', SHA2('" + p.Password + "',512), '" + p.Pin + "','" + p.TglBuat.ToString("yyyy-MM-dd") + "','" + p.TglPerubahan.ToString("yyyy-MM-dd") + "','" + p.JenisPngguna.Id + "','" + p.Reward + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahData(Pengguna p)
        {
            string sql = "update pengguna set nama_depan='" + p.NamaDepan + "', nama_keluarga= '" + p.NamaKeluarga + "', alamat= '" + p.alamat + "', email='" + p.Email + "',no_telepon='" + p.NoTelepon + "', tgl_perubahan = '" + p.TglPerubahan.ToString("yyyy-MM-dd") + "' where nik='" + p.Nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahReward(Pengguna p)
        {
            string sql = "update pengguna set reward = " + p.Reward + "+1 where nik = '" + p.Nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
            if (p.JenisPngguna.Id < 3 && p.Reward +1 > p.JenisPngguna.BtsAtasReward)
            {
                string sql2 = "update pengguna set jenis_pengguna = " + p.JenisPngguna.Id + "+1 where nik = '" + p.Nik + "';";
                Koneksi.JalankanPerintahNonQuery(sql2);
            }
        }

        public static void UbahPassword(Pengguna p)
        {   //hanya untuk mengubah kolom password
            string sql = "UPDATE pengguna SET password=SHA2('" + p.Password + "',512) WHERE nik='" + p.Nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahPin(Pengguna p)
        {   //hanya untuk mengubah kolom pin
            string sql = "UPDATE pengguna SET pin = SHA2('" + p.Pin + "',512) WHERE nik='" + p.Nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public static bool CekPin(Pengguna p, string pin)
        {
            string sql = "select * from pengguna where nik='" + p.Nik + "' and pin=SHA2('" + pin + "',512);";
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);
            if (hasil.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void HapusData(string nik)
        {
            string sql = "delete from pengguna where nik='" + nik + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static List<Pengguna> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query (butuh inner join karena harus ambil nama jabatan)
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from pengguna p inner join jenisPengguna j on p.jenis_pengguna=j.id;";
            else //jika ada filter
                sql = "select * from pengguna p inner join jenisPengguna j on p.jenis_pengguna=j.id where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Pengguna> listData = new List<Pengguna>();
            while (hasil.Read() == true)
            {
                string vNik = hasil.GetValue(0).ToString();
                string vNamaDepan = hasil.GetValue(1).ToString();
                string vNamaBelakang = hasil.GetValue(2).ToString();
                string vAlamat = hasil.GetValue(3).ToString();
                string vEmail = hasil.GetValue(4).ToString();
                string vNoTlp = hasil.GetValue(5).ToString();
                //password tdk diambil
                DateTime vTglBuat = DateTime.Parse(hasil.GetValue(8).ToString());
                DateTime vTglPerubahan = DateTime.Parse(hasil.GetValue(9).ToString());
                double vReward = double.Parse(hasil.GetValue(11).ToString());

                int iJenisPengguna = int.Parse(hasil.GetValue(12).ToString());
                string nJenisPengguna = hasil.GetValue(13).ToString();
                double limitTrf = double.Parse(hasil.GetValue(14).ToString());
                double btsAtasReward = double.Parse(hasil.GetValue(15).ToString());
                JenisPengguna vJenis = new JenisPengguna(iJenisPengguna, nJenisPengguna, limitTrf, btsAtasReward);

                //kosongi password, karena tdk boleh membaca password orang lain
                Pengguna p = new Pengguna(vNik, vNamaDepan, vNamaBelakang, vAlamat
                    , vEmail, vNoTlp, "", "", vTglBuat, vTglPerubahan, vJenis, vReward);
                listData.Add(p); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public override string ToString()
        {
            return NamaDepan + " " + NamaKeluarga;
        }
        #endregion

        #region METHODS ADDRESSBOOK
        public void TambahAddressBookInternal(Tabungan norek, string ket)
        {
            AddressBookInternal abi = new AddressBookInternal();
            abi.NoRek = norek;
            abi.Keterangan = ket;

            ListAddressBookInternal.Add(abi);
        }

        public static void BacaDataAddressBookInternal(Pengguna p)
        {
            string sql;
            sql = "select * from addressbookinternal where id_pengguna = '" + p.Nik + "';";

            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            while (hasil.Read() == true)
            {
                string ket = hasil.GetValue(2).ToString();

                List<Tabungan> listData = Tabungan.BacaData("no_rekening", hasil.GetValue(1).ToString());

                p.TambahAddressBookInternal(listData[0], ket);
            }
        }

        public void TambahAddressBookEksternal(TabunganEksternal norek, string ket)
        {
            AddressBookEksternal abe = new AddressBookEksternal();
            abe.NoRek = norek;
            abe.IdBank = norek.IdBank;
            abe.Keterangan = ket;

            ListAddressBookEksternal.Add(abe);
        }

        public static void BacaDataAddressBookEksternal(Pengguna p)
        {
            string sql;
            sql = "select * from addressbookeksternal where id_pengguna = '" + p.Nik + "';";

            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            while (hasil.Read() == true)
            {
                string ket = hasil.GetValue(3).ToString();
                TabunganEksternal te = TabunganEksternal.BacaData(hasil.GetValue(2).ToString());

                p.TambahAddressBookEksternal(te, ket);
            }
        }
        #endregion 
    }
}
