using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    public class Zawodnik
    {
        #region Własności
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Date DataUrodzenia { get; set; }
        public char Plec { get; set; }
        public int Ranking { get; set; }
        public string Login { get; set; }
        #endregion

        #region Konstruktory

        public Zawodnik(string imie, string nazwisko, Date dataUrodzenia, char plec, int ranking, string login)
        {
            Imie = imie; 
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            Plec = plec;
            Ranking = ranking;
            Login = login;
        }

        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"('{Imie}', '{Nazwisko}', '{DataUrodzenia}', '{Plec}', '{Ranking}', '{Login}')";
        }

        #endregion
    }
}
