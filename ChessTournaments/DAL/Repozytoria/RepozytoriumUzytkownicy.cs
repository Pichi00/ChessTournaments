﻿using System;
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
        private const string HASLO_DLA_UZYTKOWNIKA = "SELECT * FROM uzytkownicy WHERE login LIKE ";
        #endregion

        #region Metody

        public static List<string> PobierzWszystkichUzytkownikow()
        {
            List<string> list = new List<string>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSCY_UZYTKOWNICY, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Uzytkownik(reader).Login);
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

        public static string PobierzHasloDlaUzytkownika(Uzytkownik uzytkownik)
        {
            string haslo = "";
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{HASLO_DLA_UZYTKOWNIKA} '{uzytkownik.Login}'", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                    haslo = reader["haslo"].ToString();
            }
            return haslo;
        }

        #endregion
    }
}
