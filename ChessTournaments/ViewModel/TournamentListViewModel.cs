using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ChessTournaments.ViewModel
{
    using BaseClasses;
    using Model;
    using DAL.Encje;
    using System.Windows.Input;
    using System.ComponentModel;

    class TournamentListViewModel:ViewModelBase
    {
        #region Konstruktory
        public TournamentListViewModel()
        {
            
            model = new TurniejModel();
            OdswiezTurnieje();
        }
        #endregion

        #region Właściwości

        protected TurniejModel model = null;

        //public event PropertyChangedEventHandler WybranyTurniejPropertyChangedEvent;

        private ObservableCollection<Turniej> turnieje;
        public ObservableCollection<Turniej> Turnieje 
        {
            get => turnieje;
            set
            {
                turnieje = value;
                onPropertyChanged(nameof(turnieje));
            }
        }

        protected Turniej wybranyTurniej;
        public Turniej WybranyTurniej
        {
            get => wybranyTurniej;
            set
            {
                wybranyTurniej = value;
                onPropertyChanged(nameof(wybranyTurniej));
            }
        }
        #endregion

        public void OdswiezTurnieje() => Turnieje = model.PobierzWszystkieTurnieje();
       
        
        
        



    }
}
