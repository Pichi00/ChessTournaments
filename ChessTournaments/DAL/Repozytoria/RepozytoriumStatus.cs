using ChessTournaments.DAL.Encje;
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
        private const string DODAJ_STATUS= "INSERT INTO `statusZawodnika`(`idTurniej`,`idZawodnik`) VALUES "; //podczas doloczania do turnieju przez nowego zawodnika

        public static void wyslijZgloszenie(Zawodnik zawodnik,Turniej turniej)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_STATUS} {$"('{zawodnik.Id} ,{turniej.Id}')"}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                connection.Close();
            }
        }
    };

}
