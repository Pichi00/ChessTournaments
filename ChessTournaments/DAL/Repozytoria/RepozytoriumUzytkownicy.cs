using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumUzytkownicy
    {
        #region Zapytania

        private const string DODAJ_UZYTKOWNIKA = "INSERT INTO `uzytkownicy`(`login`, `haslo`, `typ_konta`) VALUES ";

        #endregion

        #region Metody

        private static bool DodajUzytkownikaDoBazy( Uzytkownik uzytkownik)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_UZYTKOWNIKA} {uzytkownik.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }

        #endregion
    }
}
