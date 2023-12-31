using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        #region CONSTRUCTORS
        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword, string pPort)
        {
            string strCon =
                "server=" + pServer + ";database=" + pDatabase + ";uid=" + pUsername + ";password=" + pPassword + ";port=" + pPort;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
        }

        //constructor default tanpa parameter
        public Koneksi()
        {
            Configuration myConf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup userSettings = myConf.SectionGroups["userSettings"];

            var settingsSection = userSettings.Sections["DiBa_Project_UAS.db"] as ClientSettingsSection;

            string DbServer = settingsSection.Settings.Get("DbServer").Value.ValueXml.InnerText;
            string DbName = settingsSection.Settings.Get("DbName").Value.ValueXml.InnerText;
            string DbUsername = settingsSection.Settings.Get("DbUsername").Value.ValueXml.InnerText;
            string DbPassword = settingsSection.Settings.Get("DbPassword").Value.ValueXml.InnerText;
            string DbPort = settingsSection.Settings.Get("DbPort").Value.ValueXml.InnerText;

            string strCon = "server=" + DbServer + ";database=" + DbName + ";uid=" + DbUsername + ";password=" + DbPassword + ";port=" + DbPort;
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
        }


        #endregion

        #region PROPERTIES
        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }
        #endregion

        #region METHODS
        public void Connect()
        {
            // jika connection sedang terbuka maka tutup lebih dahulu 
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public static MySqlDataReader JalankanPerintahSelect(string sql)
        {
            Koneksi k = new Koneksi();

            MySqlCommand cmd = new MySqlCommand(sql, k.KoneksiDB);
            MySqlDataReader hasil = cmd.ExecuteReader();
            return hasil;
        }

        public static void JalankanPerintahNonQuery(string sql)
        {   //UNTUK MENJALANKAN INSERT, UPDATE ATAU DELETE
            Koneksi k = new Koneksi();

            MySqlCommand cmd = new MySqlCommand(sql, k.KoneksiDB);
            cmd.ExecuteNonQuery();
        }

        #endregion 
    }
}
