using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class JenisPengguna
    {
        private int id;
        private string nama;
        private double limitTransfer;
        private double btsAtasReward;

        public JenisPengguna(int vId, string vNama, double vLimitTransfer, double vBtsAtasReward)
        {
            Id = vId;
            Nama = vNama;
            LimitTransfer = vLimitTransfer;
            BtsAtasReward = vBtsAtasReward;
        }

        public JenisPengguna()
        {
            Id = 1;
            Nama = "Silver";
            LimitTransfer = 25000000;
            BtsAtasReward = 50000000;
        }

        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public double LimitTransfer { get => limitTransfer; set => limitTransfer = value; }
        public double BtsAtasReward { get => btsAtasReward; set => btsAtasReward = value; }

        public static List<JenisPengguna> BacaData(string kolom = "", string nilai = "")
        {
            // STEP 1. susun perintah query
            string sql;
            if (kolom == "") //jika user tidak memberikan filter
                sql = "select * from jenispengguna;";
            else //jika ada filter
                sql = "select * from jenispengguna where " + kolom + " like '%" + nilai + "%';";

            // STEP 2. JALANkan perintah query
            MySqlDataReader hasil = Koneksi.JalankanPerintahSelect(sql);

            // STEP 3. pindahkan datareader ke list
            List<JenisPengguna> listData = new List<JenisPengguna>();
            while (hasil.Read() == true)
            {
                int id = int.Parse(hasil.GetValue(0).ToString()); //ambil isi datareader per kolom
                string nama = hasil.GetValue(1).ToString();
                double limitTrf = double.Parse(hasil.GetValue(2).ToString());
                double btsAtasReward = double.Parse(hasil.GetValue(3).ToString());

                JenisPengguna j = new JenisPengguna(id, nama, limitTrf, btsAtasReward);
                listData.Add(j); //tambahkan objek kategori ke list
            }
            return listData;
        }

        public override string ToString()
        {   //menggantikan method tostring, dengan mengembalikan field nama dari jenisPengguna
            return Nama;
        }

    }
}
