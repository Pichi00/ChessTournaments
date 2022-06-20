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
    using System.Windows;

    class TurniejModel
    {
        public ObservableCollection<Turniej> Turnieje { get; set; }

        public TurniejModel()
        {
            Turnieje = new ObservableCollection<Turniej>();
            List<Turniej> pobraneTurnieje = RepozytoriumTurniej.PobierzWszystkieTurnieje();
            foreach(var turniej in pobraneTurnieje)
            {
                Turnieje.Add(turniej);
            }
        }
        public void DodajStatusDoBazy(StatusZawodnika status)
        {
            RepozytoriumStatus.DodajStatusDoBazy(status);
    
        }

        public bool DodajTurniejDoBazy(Turniej turniej)
        {
            if (RepozytoriumTurniej.DodajTurniejDoBazy(turniej))
            {
                Turnieje.Add(turniej);
                return true;
            }
            return false;
        }

        public bool UsunTurniejZBazy(Turniej turniej)
        {
            if (RepozytoriumTurniej.UsunTurniejZBazy(turniej))
            {
                Turnieje.Remove(turniej);
                return true;
            }
            return false;
        }

        public bool EdytujTurniejWBazie(Turniej turniej)
        {
            if (RepozytoriumTurniej.EdytujTurniejWBazie(turniej))
            {
                return true;
            }
            return false;
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
        }

        public ObservableCollection<Turniej> PobierzTurniejeOrganizatora(Organizator organizator)
        {
            ObservableCollection<Turniej> turnieje = new ObservableCollection<Turniej>();
            var pobraneTurnieje = RepozytoriumTurniej.PobierzTurniejeOrganizatora(organizator);
            foreach (var turniej in pobraneTurnieje)
                turnieje.Add(turniej);

            return turnieje;
        }

        public ObservableCollection<Turniej> PobierzWszystkieTurniejeuzytkownika(Zawodnik zawodnik)
        {
            ObservableCollection<Turniej> turnieje = new ObservableCollection<Turniej>();
            var pobraneTurnieje = RepozytoriumStatus.PobierzWszystkieTurniejeUzytkownika(zawodnik);
            foreach (var turniej in pobraneTurnieje)
                turnieje.Add(turniej);

            return turnieje;
        }

        public int PobierzIDZawodnika(string login)
        {
            return RepozytoriumZawodnik.PobierzIDZawodnika(login);
        }

        
    }
}
