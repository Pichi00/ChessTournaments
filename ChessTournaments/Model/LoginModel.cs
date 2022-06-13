using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessTournaments.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    class LoginModel:AuthenticationModel
    {
        public LoginModel()
        {
            var uzytkownicy = RepozytoriumUzytkownicy.PobierzWszystkichUzytkownikow();
            foreach (var uzytkownik in uzytkownicy)
            {
                Uzytkownicy.Add(uzytkownik);
            }
        }

        public bool WeryfikujUzytkownika(Uzytkownik uzytkownik)
        {
            if (CzyUzytkownikJuzWRepozytorium(uzytkownik))
            {
                string hasloZBazy = RepozytoriumUzytkownicy.PobierzHasloDlaUzytkownika(uzytkownik).ToString();
                if(uzytkownik.Haslo == hasloZBazy)
                {
                    return true;
                }
                
            }
            return false;
        }

        public Uzytkownik.TypyKont PobierzTypKonta(string login)
        {
            Uzytkownik.TypyKont typKonta = RepozytoriumUzytkownicy.PobierzTypKontaDlaUzytkownika(login);

            return typKonta;
        }
       
    }
}
