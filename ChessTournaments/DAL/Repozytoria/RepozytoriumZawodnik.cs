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
        private const string ZWROC_ID_ZAWODNIKA = "SELECT `idZawodnika` FROM `zawodnicy` WHERE login like ";
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

        public static int PobierzIDZawodnika(string login)
        {
            int idZaw = 0;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ZWROC_ID_ZAWODNIKA} '{login}'", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["idZawodnika"].ToString(), out int result))
                    {
                        idZaw = result;
                    };
                }
                connection.Close();
            }

            return idZaw;
        }


        #endregion
    }
}

