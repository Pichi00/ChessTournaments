using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    class StatusZawodnika
    {
        #region wlasciwosci
        public enum StatusEnum { niezaakceptowany, zakceptowany, odrzucony }
        public int IdStatus { get; set; }
        public int IdZawodnik { get; set; }
        public int IdTurniej { get; set; }
        public StatusEnum Status { get; set; }

        #endregion

        #region konstruktory
        public StatusZawodnika(StatusEnum status)
        {
            Status = status;

        }

        public StatusZawodnika(MySqlDataReader reader)
        {
            IdStatus = int.Parse(reader["idStatusu"].ToString());
            IdTurniej = int.Parse(reader["idTurniej"].ToString());
            IdZawodnik = int.Parse(reader["idZawodnik"].ToString());
            Status = (StatusEnum)System.Enum.Parse(typeof(StatusEnum), reader["status"].ToString());
        }



        #endregion

        public string ToInsert()
        {
            return $"('{Status}')";
        }
    }
}
