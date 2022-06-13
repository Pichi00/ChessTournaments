using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessTournaments.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;

    class RegisterModel:AuthenticationModel
    {
        
        public RegisterModel()
        {
            var uzytkownicy = RepozytoriumUzytkownicy.PobierzWszystkichUzytkownikow();
            foreach(var uzytkownik in uzytkownicy)
            {
                Uzytkownicy.Add(uzytkownik);
            }
        }

        public bool DodajUzytkownikaDoBazy(Uzytkownik uzytkownik)
        {
            if (!CzyUzytkownikJuzWRepozytorium(uzytkownik))
            {
                if (RepozytoriumUzytkownicy.DodajUzytkownikaDoBazy(uzytkownik))
                {
                    Uzytkownicy.Add(uzytkownik.Login);
                    return true;
                }

            }
            return false;
        }

    }
}
