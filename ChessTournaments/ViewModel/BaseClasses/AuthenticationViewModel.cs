using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.ViewModel.BaseClasses
{
    using DAL.Encje;
    class AuthenticationViewModel: ViewModelBase
    {

        #region Własności Użytkownika
        private string login, haslo, typKontaString;
        private Uzytkownik.TypyKont typKonta;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                onPropertyChanged(nameof(Login));
            }

        }

        public string Haslo
        {
            get { return haslo; }
            set
            {
                haslo = value;
                onPropertyChanged(nameof(Haslo));
            }

        }

        public string TypKontaString
        {
            get => typKontaString;
            set
            {
                typKontaString = value;
                if (typKontaString != null && typKontaString.Contains("ORGANIZATOR"))
                {
                    TypKonta = Uzytkownik.TypyKont.ORGANIZATOR;
                }
                else
                {
                    TypKonta = Uzytkownik.TypyKont.ZAWODNIK;
                }
                onPropertyChanged(nameof(TypKontaString));
            }
        }

        public Uzytkownik.TypyKont TypKonta
        {
            get { return typKonta; }
            set
            {
                typKonta = value;
                onPropertyChanged(nameof(TypKonta));
            }

        }

        #endregion

        #region Własności organizatora
        private string nazwaOrganizatora;

        public string NazwaOrganizatora
        {
            get
            {
                return nazwaOrganizatora;
            }
            set
            {
                nazwaOrganizatora = value;
                onPropertyChanged(nameof(nazwaOrganizatora));
            }
        }
        #endregion

        #region  Własności Zawodnika

        private string  imieZawodnika, nazwiskoZawodnika, plecString;
        private char plec;
        private DateTime dataUrodzenia = DateTime.Now;
        private int ranking;

        public string ImieZawodnika
        {
            get => imieZawodnika;
            set
            {
                imieZawodnika = value;
                onPropertyChanged(nameof(imieZawodnika));
            }
        }
        public string NazwiskoZawodnika
        {
            get => nazwiskoZawodnika;
            set
            {
                nazwiskoZawodnika = value;
                onPropertyChanged(nameof(nazwiskoZawodnika));
            }
        }
        public DateTime DataUrodzenia
        {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                onPropertyChanged(nameof(dataUrodzenia));
            }
        }
        public char Plec
        {
            get => plec;
            set
            {
                plec = value;
                onPropertyChanged(nameof(plec));
            }
        }

        public string PlecString
        {
            get => plecString;
            set
            {
                plecString = value;
                onPropertyChanged(nameof(plecString));
            }
        }
        public int Ranking
        {
            get => ranking;
            set
            {
                ranking = value;
                onPropertyChanged(nameof(ranking));
            }
        }
        
        #endregion



    }
}
