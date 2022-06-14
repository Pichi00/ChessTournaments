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
    using ViewModel;

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

        public bool DodajOrganizatoraDoBazy(Organizator organizator)
        {
            if (RepozytoriumOrganizator.DodajOrganizatoraDoBazy(organizator))
            {
                return true;
            }
            return false;
        }

        public bool DodajZawodnikaDoBazy(Zawodnik zawodnik)
        {
            if (RepozytoriumZawodnik.DodajZawodnikaDoBazy(zawodnik))
            {
                return true;
            }
            return false;
        }

        public void Przelacz(RegisterViewModel rVM, string typKonta)
        {
            if(rVM != null && typKonta != null)
            {
                if (typKonta.Contains("ORGANIZATOR"))
                {
                    rVM.OrganizerFormVisibility = Visibility.Visible;
                    rVM.PlayerFormVisibility = Visibility.Collapsed;
                }
                else if (typKonta.Contains("ZAWODNIK"))
                {
                    rVM.OrganizerFormVisibility = Visibility.Collapsed;
                    rVM.PlayerFormVisibility = Visibility.Visible;
                }
                else
                {
                    rVM.OrganizerFormVisibility = Visibility.Collapsed;
                    rVM.PlayerFormVisibility = Visibility.Collapsed;
                }
            }
            
        }

    }
}
