using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Encje
{
    class Turniej
    {

        #region wlasciwosci
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Miejsce { get; set; }
        public string Start { get; set; }

        public string Koniec { get; set; }
        public double PulaNagrod { get; set; }
        public int Organizator { get; set; }
        public string Regulamin { get; set; }

        #endregion

        #region konstruktory
        public Turniej(string nazwa, string miejsce, DateTime start, DateTime koniec, double nagrody, string regulamin, int organizator)
        {
            Nazwa = nazwa;
            Miejsce = miejsce;
            
            Start = start.ToString("yyyy-MM-dd H:mm:ss");
            Koniec = koniec.ToString("yyyy-MM-dd H:mm:ss");
            PulaNagrod = nagrody;
            Regulamin = regulamin;
            Organizator = organizator;

        }

        public Turniej(MySqlDataReader reader)
        {
            Id = int.Parse(reader["idTurnieju"].ToString());
            Nazwa = reader["nazwa"].ToString();
            Miejsce = reader["miejce"].ToString();
            Start = reader["dataRozpoczecia"].ToString();
            Koniec = reader["dataZakonczenia"].ToString();
            PulaNagrod = double.Parse(reader["pulaNagrod "].ToString());
            Regulamin = reader["regulamin"].ToString();
        }
        #endregion

        public string ToInsert()
        {
            return $"('{Nazwa}', '{Miejsce}', '{Start}', '{Koniec}', '{PulaNagrod}', '{Regulamin}', '{Organizator}')";
        }
    }
}
