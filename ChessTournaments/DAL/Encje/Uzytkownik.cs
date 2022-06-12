using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    class Uzytkownik
    {
        public enum TypyKont {ORGANIZATOR, ZAWODNIK}

        #region Własności
        public string Login { get; set; }
        public string Haslo { get; set; }
        public TypyKont TypKonta { get; set; }
        #endregion

        #region Konstruktory

        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"{Login}, {Haslo}, {TypKonta}";
        }

        #endregion
    }
}
