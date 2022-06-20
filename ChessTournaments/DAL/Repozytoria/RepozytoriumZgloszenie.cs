using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Repozytoria
{
    using Encje;
    using MySql.Data.MySqlClient;

    static class RepozytoriumZgloszenie
    {
        private const string ZGLOSZENIA_DO_TURNIEJOW_ORGANIZATORA = "SELECT s.statusZawodnika, s.idStatusu, z.imie, z.nazwisko, z.dataUrodzenia, z.plec, z.ranking, t.nazwa " +
            "FROM statuszawodnika s LEFT JOIN zawodnicy z ON s.idZawodnik = z.idZawodnika " +
            "LEFT JOIN turnieje t ON s.idTurniej = t.idTurnieju " +
            "LEFT JOIN organizatorzy o ON t.organizator = o.idOrganizatora " +
            "WHERE o.idOrganizatora = ";

        public static List<Zgloszenie> PobierzZgloszeniaZBazyDlaOrganizatora(Organizator organizator)
        {
            List<Zgloszenie> zgloszenia = new List<Zgloszenie>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ZGLOSZENIA_DO_TURNIEJOW_ORGANIZATORA} {organizator.Id}", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    zgloszenia.Add(new Zgloszenie(reader));
                connection.Close();
            }

            return zgloszenia;
        }
    }
}
