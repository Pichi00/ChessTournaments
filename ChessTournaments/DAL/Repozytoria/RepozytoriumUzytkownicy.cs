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

        private const string DODAJ_UZYTKOWNIKA = "INSERT INTO `uzytkownicy`(`login`, `haslo`, `rodzajKonta`) VALUES ";
        private const string WSZYSCY_UZYTKOWNICY = "SELECT * FROM uzytkownicy";
        #endregion

        #region Metody

        public static List<Uzytkownik> PobierzWszystkichUzytkownikow()
        {
            List<Uzytkownik> list = new List<Uzytkownik>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_UZYTKOWNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Uzytkownik(reader));
                }

                connection.Close();
            }

                return list;
        }

        public static bool DodajUzytkownikaDoBazy( Uzytkownik uzytkownik)
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
