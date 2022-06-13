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
    }
}
