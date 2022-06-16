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
        private const string ZWROC_ID_ORGANIZATORA = "SELECT `idOrganizatora` FROM `organizatorzy` WHERE login like ";
        private const string ZWROC_NAZWE_ORGANIZATORA_PO_ID = "SELECT `nazwa` FROM `organizatorzy` WHERE `idOrganizatora` = ";
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

        public static int PobierzIDOrganizatora(string login)
        {
            int idOrg = 0;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ZWROC_ID_ORGANIZATORA} '{login}'", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (int.TryParse(reader["idOrganizatora"].ToString(), out int result))
                    {
                        idOrg = result;
                    };
                }
                connection.Close();
            }

            return idOrg;
        }

        public static string PobierzNazweOrganizatoraPoID(int idOrg)
        {

            string nazwa = "";
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ZWROC_NAZWE_ORGANIZATORA_PO_ID} {idOrg}", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nazwa = reader["nazwa"].ToString();
                }
                connection.Close();
            }

            return nazwa;
        }

        #endregion
    }
}
