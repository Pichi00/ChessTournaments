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
        private const string DODAJ_STATUS = "INSERT INTO `statuszawodnika`(`idZawodnik`,`idTurniej`,`statusZawodnika`) VALUES "; //podczas doloczania do turnieju przez nowego zawodnika
        private const string WYSWIETL_TURNIEJE_UZYTKOWNIKA= "select * from turnieje left join statusZawodnika on turnieje.idTurnieju =statuszawodnika.idTurniej where statuszawodnika.idZawodnik=";
        private const string USUN_ZGLOSZENIE_Z_TURNIEJU = "DELETE FROM statusZawodnika where";
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

        public static bool UsunStatusDoBazy(int idZawodnik ,int idTurniej)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                bool stan = false;
                MySqlCommand command = new MySqlCommand($"{USUN_ZGLOSZENIE_Z_TURNIEJU}`idZawodnik`={idZawodnik} AND `idTurniej` ={ idTurniej}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                stan = true;
                connection.Close();
                return stan;
            }
        }

        public static List<Turniej> PobierzWszystkieTurniejeUzytkownika(Zawodnik zawodnik)
        {
            int idZawodnika = RepozytoriumZawodnik.PobierzIDZawodnika(zawodnik.Login);
            List<Turniej> turnieje = new List<Turniej>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{WYSWIETL_TURNIEJE_UZYTKOWNIKA} {idZawodnika} ",connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    turnieje.Add(new Turniej(reader));
                connection.Close();
            }
            return turnieje;
        }
    };

}
