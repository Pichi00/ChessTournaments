using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Repozytoria
{
    using Encje;
    static class RepozytoriumOrganizator
    {
        #region Zapytania

        private const string DODAJ_ORGANIZATORA = "INSERT INTO `organizatorzy`(`nazwa`, `login`) VALUES ";
        #endregion

        #region Metody
        public static bool DodajOrganizatoraDoBazy(Organizator organizator)
        {
            bool stan = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DODAJ_ORGANIZATORA} {organizator.ToInsert()}", connection);
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
