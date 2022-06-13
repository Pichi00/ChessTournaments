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
    class AuthenticationModel
    {
        public ObservableCollection<string> Uzytkownicy { get; set; } = new ObservableCollection<string>();

        public bool CzyUzytkownikJuzWRepozytorium(Uzytkownik uzytkownik)
        {
            return Uzytkownicy.Contains(uzytkownik.Login);
        }
        
    }
}
