﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ChessTournaments.ViewModel
{
    using BaseClasses;
    using View;
    using Model;
    using DAL.Encje;
    using DAL.Repozytoria;
    class DashboardViewModel:ViewModelBase
    {
        public DashboardViewModel()
        {
            Start = DateTime.Now;
            Koniec = DateTime.Now;
            TournamentListVM = new TournamentListViewModel();
        }

        private TurniejModel turniejModel = new TurniejModel();

        public TournamentListViewModel TournamentListVM { get; set; }
        

        #region Własności

        public string nazwa, miejsce, regulamin;
        public DateTime start, koniec;
        public double nagrody;
        public string Nazwa 
        {
            get => nazwa;
            set
            {
                nazwa = value;
                onPropertyChanged(nameof(nazwa));
            }
        }
        public string Miejsce
        {
            get => miejsce;
            set
            {
                miejsce = value;
                onPropertyChanged(nameof(miejsce));
            }
        }
        public DateTime Start
        {
            get => start;
            set
            {
                start = value;
                onPropertyChanged(nameof(start));
            }
        }
        public DateTime Koniec
        {
            get => koniec;
            set
            {
                koniec = value;
                onPropertyChanged(nameof(koniec));
            }
        }
        public double Nagrody
        {
            get => nagrody;
            set
            {
                nagrody = value;
                onPropertyChanged(nameof(nagrody));
            }
        }
        public string Regulamin
        {
            get => regulamin;
            set
            {
                regulamin = value;
                onPropertyChanged(nameof(regulamin));
            }
        }
        #endregion

        #region Komendy

        private ICommand addTournament;
        public ICommand AddTournament => addTournament ?? (addTournament =
            new RelayCommand(
                o =>
                {
                    OrganizerDashboard organizerDashboard = o as OrganizerDashboard;
                    string loginOrganizatora = organizerDashboard.ZalogowanyUzytkownik.Login;
                    int idOrganizatora = turniejModel.PobierzIDOrganizatora(loginOrganizatora);
                    Turniej turniej = new Turniej(Nazwa, Miejsce, Start, Koniec, Nagrody, Regulamin, idOrganizatora);
                    if (turniejModel.DodajTurniejDoBazy(turniej))
                    {
                        MessageBox.Show("Dodano turniej do bazy");
                        CzyscFormularzDodawaniaTurnieju();
                    }
                },
                null
                ));

        private ICommand addStatus;
        public ICommand AddStatus => addStatus ?? (addStatus =
            new RelayCommand(
                o =>
                {
                    PlayerDashboard playerDashboard = o as PlayerDashboard;
                    string loginZawodnika= playerDashboard.DashboardVM.ZalogowanyUzytkownik.Login;
                    int idZawodnika= turniejModel.PobierzIDZawodnika(loginZawodnika);
                    int idTurniej = 0; //tutaj daj pobierz id turniej aktualnie selected w liscie

                    StatusZawodnika status = new StatusZawodnika(StatusZawodnika.StatusEnum.niezaakceptowany,idZawodnika,idTurniej);
                    RepozytoriumStatus.DodajStatusDoBazy(status);
      
                },
                null
                ));

        #endregion

        #region Metody

        /*public void Zaloguj(Uzytkownik uzytkownik)
        {
            ZalogowanyUzytkownik = uzytkownik;
        }*/

        public void CzyscFormularzDodawaniaTurnieju()
        {
            Nazwa = null;
            Miejsce = null;
            Start = DateTime.Now;
            Koniec = DateTime.Now;
            Nagrody = 0;
            Regulamin = null;
        }
        #endregion
    }
}
