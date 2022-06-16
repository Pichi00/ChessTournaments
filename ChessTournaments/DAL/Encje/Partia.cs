using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ChessTournaments.DAL.Encje
{
    class Partia
    {
        #region wlasciwosci
        public int IdPartii { get; set; }
        public int IdTurnieju { get; set; }
        public int IdZawodnikBiale { get; set; }
        public int IdZawodnikCzarne { get; set; }

        public DateTime DataRozpoczecia { get; set; }

        public int Runda { get; set; }
        public String Rezultat { get; set; }


        #endregion

        #region konstruktory
        public Partia(int idTurnieju, int idZawodnikBiale , int idZawodnikczarne, DateTime dataRozpoczecia ,int runda , string rezultat)
        {
            IdTurnieju = idTurnieju;
            IdZawodnikBiale = idZawodnikBiale;
            IdZawodnikCzarne = idZawodnikczarne;
            DataRozpoczecia = dataRozpoczecia;
            Runda = runda;
            Rezultat = rezultat;
        }

        public Partia(MySqlDataReader reader)
        {
            IdTurnieju = int.Parse(reader["idTurnieju"].ToString());
            IdZawodnikBiale = int.Parse(reader["idZawodnikBiale"].ToString());
            IdZawodnikCzarne = int.Parse(reader["idZawodnikCzarne"].ToString());
            DataRozpoczecia = DateTime.Parse(reader["datarozpoczecia"].ToString());
            Runda = int.Parse(reader["runda"].ToString());
            Rezultat =  reader["status"].ToString();

        }
        #endregion

        //public string ToInsert()
        //{
        //    return $"('{Nazwa}',  '{Miasto}','{Organizator}'  , '{Start}','{Koniec}' , '{PulaNagrod}' , '{Regulamin}' )";
        //}
    }
}
