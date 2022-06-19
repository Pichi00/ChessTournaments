using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    class Zgloszenie
    {

        #region Własności

        public string ImieZawodnika { get; set; }
        public string NazwiskoZawodnika { get; set; }
        public string DataUrodzeniaZawodnika { get; set; }
        public int RankingZawodnika { get; set; }
        public char PlecZawodnika { get; set; }
        public string NazwaTurnieju { get; set; }
        public string StatusZawodnika { get; set; }


        #endregion

        #region Konstruktory
        public Zgloszenie(Zawodnik zawodnik, Turniej turniej, StatusZawodnika status)
        {
            ImieZawodnika = zawodnik.Imie;
            NazwiskoZawodnika = zawodnik.Nazwisko;
            DataUrodzeniaZawodnika = zawodnik.DataUrodzenia.ToString();
            RankingZawodnika = zawodnik.Ranking;
            PlecZawodnika = zawodnik.Plec;
            NazwaTurnieju = turniej.Nazwa;
            StatusZawodnika = status.Status.ToString();
        }

        public Zgloszenie(MySqlDataReader reader)
        {
            ImieZawodnika = reader["imie"].ToString();
            NazwiskoZawodnika = reader["nazwisko"].ToString();
            DataUrodzeniaZawodnika = reader["dataUrodzenia"].ToString();
            RankingZawodnika = int.Parse(reader["ranking"].ToString()); 
            PlecZawodnika = char.Parse(reader["plec"].ToString());
            NazwaTurnieju = reader["nazwa"].ToString();
            StatusZawodnika = reader["statusZawodnika"].ToString();
        }

        #endregion
    }
}
