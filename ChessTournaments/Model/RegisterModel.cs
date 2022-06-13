using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessTournaments.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;

    class RegisterModel
    {
        public ObservableCollection<Uzytkownik> Uzytkownicy { get; set; } = new ObservableCollection<Uzytkownik>();

        public RegisterModel()
        {
            var uzytkownicy = RepozytoriumUzytkownicy.PobierzWszystkichUzytkownikow();
            foreach(var uzytkownik in uzytkownicy)
            {
                Uzytkownicy.Add(uzytkownik);
            }
        }

        public bool CzyUzytkownikJuzWRepozytorium(Uzytkownik uzytkownik)
        {
            return Uzytkownicy.Contains(uzytkownik);
        }

        public bool DodajUzytkownikaDoBazy(Uzytkownik uzytkownik)
        {
            if(!CzyUzytkownikJuzWRepozytorium(uzytkownik))
            {
                if (RepozytoriumUzytkownicy.DodajUzytkownikaDoBazy(uzytkownik))
                {
                    Uzytkownicy.Add(uzytkownik);
                    return true;
                }
                
            }
            return false;
        }

    }
}
