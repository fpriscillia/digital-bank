using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace diBa_LIB
{
    public class AddressBookEksternal
    {
        private Pengguna idPengguna;
        private BankLain idBank;
        private TabunganEksternal noRek;
        private string keterangan;

        #region CONSTRUCTORS
        public AddressBookEksternal(Pengguna idPengguna, BankLain idBank, TabunganEksternal noRek, string keterangan)
        {
            IdPengguna = idPengguna;
            IdBank = idBank;
            NoRek = noRek;
            Keterangan = keterangan;
        }
        public AddressBookEksternal()
        {
            IdPengguna = new Pengguna();
            IdBank = new BankLain();
            NoRek = new TabunganEksternal();
            Keterangan = "";
        }
        #endregion

        #region PROPERTIES
        public Pengguna IdPengguna { get => idPengguna; set => idPengguna = value; }
        public BankLain IdBank { get => idBank; set => idBank = value; }
        public TabunganEksternal NoRek { get => noRek; set => noRek = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region METHODS
        public static void TambahData(AddressBookEksternal abe)
        {

            string sql = "INSERT INTO addressBookEksternal (id_pengguna, id_bank, no_rekening, keterangan) VALUES ('" + 
                abe.IdPengguna.Nik + "','" + abe.IdBank.Id + "', '" + abe.NoRek.NoRekening + "', '" + abe.Keterangan + "');";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        #endregion
    }
}
