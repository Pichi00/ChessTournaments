﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumTurniej
    {
        #region Zapytania
        private const string DODAJ_TURIEJ = "INSERT INTO `turnieje`" +
            "(`nazwa`,`miejsce`,`dataRozpoczecia`,`dataZakonczenia`,`pulaNagrod`,`regulamin`,`organizator`) VALUES ";
        private const string WSZYSTKIE_TURNIEJE = "SELECT * FROM `turnieje`";
        #endregion
        #region Metody

        public static bool DodajTurniejDoBazy(Turniej turniej)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_TURIEJ} {turniej.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
            }

            return stan;
        }

        public static List<Turniej> PobierzWszystkieTurnieje()
        {
            List<Turniej> turnieje = new List<Turniej>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(WSZYSTKIE_TURNIEJE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    turnieje.Add(new Turniej(reader));
                connection.Close();
            }
            return turnieje;
        }

        #endregion
    }
}
