using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class TurniejModel
    {
 
        public void DodajStatusDoBazy(StatusZawodnika status)
        {
            RepozytoriumStatus.DodajStatusDoBazy(status);
    
        }

        public int PobierzIDOrganizatora(string login)
        {
            return RepozytoriumOrganizator.PobierzIDOrganizatora(login);
        }

        public ObservableCollection<Turniej> PobierzWszystkieTurnieje()
        {
            ObservableCollection<Turniej> turnieje = new ObservableCollection<Turniej>();
            var pobraneTurnieje = RepozytoriumTurniej.PobierzWszystkieTurnieje();
            foreach (var turniej in pobraneTurnieje)
                turnieje.Add(turniej);
            
            return turnieje;
        public int PobierzIDZawodnika(string login)
        {
            return RepozytoriumZawodnik.PobierzIDZawodnika(login);
        }
    }
}
