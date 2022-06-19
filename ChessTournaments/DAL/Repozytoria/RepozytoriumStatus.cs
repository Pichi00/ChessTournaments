﻿using ChessTournaments.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Repozytoria
{
 

    class RepozytoriumStatus
    {
        private const string DODAJ_STATUS = "INSERT INTO `statuszawodnika`(`idZawodnik`,`idTurniej`,`statusZawodnika`) VALUES "; //podczas doloczania do turnieju przez nowego zawodnika
        private const string WYSWIETL_TURNIEJE_UZYTKOWNIKA= "select nazwa, miasto";
        private const string WYSWIETL_ZGLOSZENIA_DO_TURNIEJU = "INSERT INTO `statusZawodnika`(`idTurniej`,`idZawodnik`,`statusZawodnika`) VALUES ";
        public static void DodajStatusDoBazy(StatusZawodnika status)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_STATUS} {status.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    };

}
