using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumZawodnik
    {

        #region Zapytania
        private const string INFO_O_ZAWODNIKU = "SELECT * FROM zawodnicy WHERE login LIKE ";
        private const string DODAJ_ZAWODNIKA = "INSERT INTO `zawodnicy`(`imie`, `nazwisko`, `dataUrodzenia`, `plec`, `ranking`, `login`) VALUES ";
        #endregion

        #region Metody

        public static bool DodajZawodnikaDoBazy(Zawodnik zawodnik)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ZAWODNIKA} {zawodnik.ToInsert()}", connection);
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

