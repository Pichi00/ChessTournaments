using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Encje
{
    public class Uzytkownik
    {
        public enum TypyKont {ORGANIZATOR, ZAWODNIK}

        #region Własności
        public string Login { get; set; }
        public string Haslo { get; set; }
        public TypyKont TypKonta { get; set; }
        #endregion

        #region Konstruktory
        public Uzytkownik(string login, string haslo, TypyKont typKonta)
        {
            Login = login;
            Haslo = haslo;
            TypKonta = typKonta;
        }

        public Uzytkownik(string login, string haslo)
        {
            Login = login;
            Haslo = haslo;
        }

        public Uzytkownik(MySqlDataReader reader)
        {
            Login = reader["login"].ToString();
            Haslo = reader["haslo"].ToString();
            if(reader["rodzajKonta"].ToString().ToUpper() == "ORGANIZATOR")
            {
                TypKonta = TypyKont.ORGANIZATOR;
            }
            else
            {
                TypKonta = TypyKont.ZAWODNIK;
            }
            
        }
        #endregion

        #region Metody

        public string ToInsert()
        {
            return $"('{Login}', '{Haslo}', '{TypKonta.ToString().ToLower()}')";
        }

        #endregion
    }
}
