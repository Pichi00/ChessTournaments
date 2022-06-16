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
        public enum StatusEnum { niezaakceptowany, zakceptowany, odrzucony}
        public int IdStatus { get; set; }
        public int IdZawodnik { get; set; }
        public int IdTurniej { get; set; }
        public StatusEnum Status { get; set; }

        #endregion

        #region konstruktory
        public StatusZawodnika(int idzawodnika, int idturniej, StatusEnum status)
        {
            IdZawodnik = idzawodnika;
            IdTurniej = idturniej;
            Status = status;
          
        }

        public StatusZawodnika(MySqlDataReader reader)
        {
            IdStatus = int.Parse(reader["idStatusu"].ToString());
            IdTurniej = int.Parse(reader["idTurniej"].ToString());
            IdZawodnik = int.Parse(reader["idZawodnik"].ToString());
            Status=(StatusEnum)System.Enum.Parse(typeof(StatusEnum), reader["status"].ToString());
        }
        


        #endregion

        //public string ToInsert()
        //{
        //    return $"('{Nazwa}',  '{Miasto}','{Organizator}'  , '{Start}','{Koniec}' , '{PulaNagrod}' , '{Regulamin}' )";
        //}
    }
}
