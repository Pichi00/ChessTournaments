using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessTournaments.ViewModel
{
    using BaseClasses;
    using DAL.Encje;
    class DashboardViewModel:ViewModelBase
    {
       
        public Uzytkownik ZalogowanyUzytkownik { get; set; }

        public void Zaloguj(Uzytkownik uzytkownik)
        {
            ZalogowanyUzytkownik = uzytkownik;
        }
    }
}
