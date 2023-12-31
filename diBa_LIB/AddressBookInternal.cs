using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class AddressBookInternal
    {
        private Pengguna idPengguna;
        private Tabungan noRek;
        private string keterangan;

        #region PROPERTIES
        public Pengguna IdPengguna { get => idPengguna; set => idPengguna = value; }
        public Tabungan NoRek { get => noRek; set => noRek = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region CONSTRUCTORS
        public AddressBookInternal()
        {
            IdPengguna = new Pengguna();
            NoRek = new Tabungan();
            Keterangan = "";
        }

        public AddressBookInternal(Pengguna pIdPengguna, Tabungan pNoRek, string pKeterangan)
        {
            IdPengguna = pIdPengguna;
            NoRek = pNoRek;
            Keterangan = pKeterangan;
        }
        #endregion

        #region METHODS
        public static void TambahData(AddressBookInternal abi)
        {
            string sql = "INSERT INTO addressbookinternal (id_pengguna, no_rekening, keterangan) VALUES ('" + abi.IdPengguna.Nik + "', '" + abi.NoRek.NoRekening + "', '" + abi.Keterangan + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        #endregion
    }
}
