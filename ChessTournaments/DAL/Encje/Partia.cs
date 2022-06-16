using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    class Partia
    {
        #region wlasciwosci
        public int Id { get; set; }
        public String Nazwa { get; set; }
        public String Miasto { get; set; }
        public DateTime Start { get; set; }

        public DateTime Koniec { get; set; }
        public Double PulaNagrod { get; set; }
        public String Organizator { get; set; }
        public String Regulamin { get; set; }

        #endregion

        #region konstruktory
        public Turniej(string nazwa, string miasto, DateTime start, DateTime koniec, double nagrody, string regulamin)
        {
            Nazwa = nazwa;
            Miasto = miasto;
            Start = start;
            Koniec = koniec;
            PulaNagrod = nagrody;
            Regulamin = regulamin;

            //TODO: domyslnie dodawany organizator
        }

        public Turniej(MySqlDataReader reader)
        {
            Nazwa = reader["nazwa"].ToString();
            Miasto = reader["miasto"].ToString();
            Start = DateTime.Parse(reader["dataRozpoczecia"].ToString());
            Koniec = DateTime.Parse(reader["dataZakonczenia"].ToString());
            PulaNagrod = double.Parse(reader["pulaNagrod "].ToString());
            Regulamin = reader["regulamin"].ToString();
        }
        #endregion

        public string ToInsert()
        {
            return $"('{Nazwa}',  '{Miasto}','{Organizator}'  , '{Start}','{Koniec}' , '{PulaNagrod}' , '{Regulamin}' )";
        }
    }
}
