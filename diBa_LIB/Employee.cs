using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Employee
    {
        private int id;
        private string namaDepan;
        private string namaKeluarga;
        private Position posisi;
        private string nik; 
        private string email;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;

        #region CONSTRUCTORS

        public Employee()
        {
            Id = 0;
            NamaDepan = "";
            NamaKeluarga = "";
            Posisi = new Position();
            Nik = "";
            Email = "";
            Password = "";
            TglBuat = DateTime.Now;
            TglPerubahan = DateTime.Now;
        }

        public Employee(int pId, string pNamaDepan, string pNamaKeluarga, string pNik, string pEmail, 
            string pPwd, DateTime pTglBuat, DateTime pTglPerubahan, Position pPosisi)
        {
            Id = pId;
            NamaDepan = pNamaDepan;
            NamaKeluarga = pNamaKeluarga;
            Nik = pNik;
            Email = pEmail;
            Password = pPwd;
            TglBuat = pTglBuat;
            TglPerubahan = pTglPerubahan;
            Posisi = pPosisi;
        }
        #endregion

        #region PROPERTIES
        public int Id { get => id; set => id = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Position Posisi { get => posisi; set => posisi = value; }
        #endregion

        #region METHODS 
        public static void TambahData(Employee e)
        {
            string sql = "INSERT INTO employee (id, nama_depan, nama_keluarga, position, nik, email, password, tgl_buat, tgl_perubahan) VALUES ('" +
                e.Id + "', '" + e.NamaDepan + "', '" + e.NamaKeluarga + "', '" + e.Posisi.Id + "', '" + e.Nik + "', '" + e.Email + "', SHA2('" +
                e.Password + "', 512), '" + e.TglBuat.ToString("yyyy-MM-dd") + "', '" + e.TglPerubahan.ToString("yyyy-MM-dd") + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahData(Employee e)
        {
            string sql = "update employee set nama_depan='" + e.NamaDepan + "', nama_keluarga= '" + 
                e.NamaKeluarga + "', position= '" + e.Posisi.Id + "', nik='" + e.Nik + "',email='" + 
                e.Email + "', tgl_perubahan = '" + e.TglPerubahan.ToString("yyyy-MM-dd") + "' where id='" + e.Id + "'";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void UbahPassword(Employee e)
        {   //hanya untuk mengubah kolom password
            string sql = "UPDATE employee SET password=SHA2('" + e.Password + "',512) WHERE id='" + e.id + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static void HapusData(string id)
        {
            string sql = "delete from employee where id='" + id + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }

        public static Employee CekLogin(string email, string pwd)
        {
            //STEP 1. SUSUN SQL UNTUK CEK LOGIN
            string sql = "select * from employee e inner join position p on e.position = p.id where email='" + email + "' and password=SHA2('" + pwd + "',512);";

            // STEP 2. JALANKAN perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. JIKA USERNAME DAN PWD TERDAFTAR, MASUKKAN KE OBJ PEGAWAI
            Employee employeeLogin = new Employee();

            if (hasil.Read() == true)
            {   //urutan GetValue(0) adalah sesuai dengan SQL yang sudah disusun
                //jika menggunakan select * maka urutan sesuai dengan urutan dalam tabel yang dituju
                employeeLogin.Id = int.Parse(hasil.GetValue(0).ToString()); //ambil isi datareader per kolom
                employeeLogin.NamaDepan = hasil.GetValue(1).ToString();
                employeeLogin.NamaKeluarga = hasil.GetValue(2).ToString();
                employeeLogin.Nik = hasil.GetValue(4).ToString();
                employeeLogin.Email = hasil.GetValue(5).ToString();
                employeeLogin.Password = hasil.GetValue(6).ToString();
                employeeLogin.TglBuat = DateTime.Parse(hasil.GetValue(7).ToString());
                employeeLogin.TglPerubahan = DateTime.Parse(hasil.GetValue(8).ToString());

                Position ps = new Position();
                ps.Id = int.Parse(hasil.GetValue(3).ToString());
                ps.Nama = hasil.GetValue(10).ToString();
                ps.Keterangan = hasil.GetValue(11).ToString();
                employeeLogin.Posisi = ps;
            }
            else //jika username dan pwd tdk terdaftar, kembalikan null
            {
                employeeLogin = null;
            }
            return employeeLogin;
        }

        public static List<Employee> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query (butuh inner join karena harus ambil nama jabatan)
            string sql;
            if (kolom == "" || nilai == "") //jika user tidak memberikan filter
                sql = "select * from employee e inner join position p on e.position = p.id;";
            else //jika ada filter
                sql = "select * from employee e inner join position p on e.position = p.id where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<Employee> listData = new List<Employee>();
            while (hasil.Read() == true)
            {
                int eID = int.Parse(hasil.GetValue(0).ToString());
                string eNamaDepan = hasil.GetValue(1).ToString();
                string eNamaKeluarga = hasil.GetValue(2).ToString();
                string eNIK = hasil.GetValue(4).ToString();
                string eEmail = hasil.GetValue(5).ToString();
                //password tdk diambil
                DateTime eTglBuat = DateTime.Parse(hasil.GetValue(7).ToString());
                DateTime eTglPerubahan = DateTime.Parse(hasil.GetValue(8).ToString());

                int idPosition = int.Parse(hasil.GetValue(3).ToString());
                string namaPosition = hasil.GetValue(10).ToString();
                string keterangan = hasil.GetValue(11).ToString();
                Position ePos = new Position(idPosition, namaPosition, keterangan);

                //kosongi password, karena tdk boleh membaca password orang lain
                Employee e = new Employee(eID, eNamaDepan, eNamaKeluarga, eNIK, eEmail, "", eTglBuat, eTglPerubahan, ePos);
                listData.Add(e); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public override string ToString()
        {
            return id.ToString();
        }
        #endregion
    }
}
