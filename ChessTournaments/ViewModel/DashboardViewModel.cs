using System;
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
            OrganizersTournamentsVM = new OrganizersTournaments(this);
            PlayerListVM = new PlayerListVewModel();
        }

        private TurniejModel turniejModel = new TurniejModel();

        public TournamentListViewModel TournamentListVM { get; set; }
        public OrganizersTournaments OrganizersTournamentsVM { get; set; }
        public PlayerListVewModel PlayerListVM { get; set; }
        

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
                    string loginOrganizatora = OrganizersTournamentsVM.ZalogowanyOrganizator.Login;
                    int idOrganizatora = turniejModel.PobierzIDOrganizatora(loginOrganizatora);
                    Turniej turniej = new Turniej(Nazwa, Miejsce, Start, Koniec, Nagrody, Regulamin, idOrganizatora);
                    if (turniejModel.DodajTurniejDoBazy(turniej))
                    {
                        MessageBox.Show("Dodano turniej do bazy");
                        CzyscFormularzDodawaniaTurnieju();
                        TournamentListVM.OdswiezTurnieje();
                        OrganizersTournamentsVM.OdswiezTurnieje(OrganizersTournamentsVM.ZalogowanyOrganizator);
                    }
                },
                null
                ));
        private ICommand deleteTournament;
        public ICommand DeleteTournament => deleteTournament ?? (deleteTournament =
            new RelayCommand(
                o =>
                {
                    Turniej turniej = OrganizersTournamentsVM.WybranyTurniej;
                    if (turniejModel.UsunTurniejZBazy(turniej))
                    {
                        MessageBox.Show("Usunięto turniej do bazy");
                        TournamentListVM.OdswiezTurnieje();
                        OrganizersTournamentsVM.OdswiezTurnieje(OrganizersTournamentsVM.ZalogowanyOrganizator);
                    }


                },
                null
                ));

        private ICommand editTournament;
        public ICommand EditTournament => editTournament ?? (editTournament =
            new RelayCommand(
                o =>
                {
                    string loginOrganizatora = OrganizersTournamentsVM.ZalogowanyOrganizator.Login;
                    int idOrganizatora = turniejModel.PobierzIDOrganizatora(loginOrganizatora);

                    Turniej turniej = OrganizersTournamentsVM.WybranyTurniej;
                    turniej.Aktualizuj(Nazwa,Miejsce,Start,Koniec,Nagrody,Regulamin);

                    if (turniejModel.EdytujTurniejWBazie(turniej))
                    {
                        MessageBox.Show("Zaktualizowano informacje o turnieju");
                        TournamentListVM.OdswiezTurnieje();
                        OrganizersTournamentsVM.OdswiezTurnieje(OrganizersTournamentsVM.ZalogowanyOrganizator);
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

                    string loginZawodnika = playerDashboard.ZalogowanyUzytkownik.Login;
                    int idZawodnika = turniejModel.PobierzIDZawodnika(loginZawodnika);
                    int idTurniej = TournamentListVM.WybranyTurniej.Id;

                    MessageBox.Show(idTurniej.ToString());
                    StatusZawodnika status = new StatusZawodnika(StatusZawodnika.StatusEnum.niezaakceptowany, idZawodnika, idTurniej);
                    RepozytoriumStatus.DodajStatusDoBazy(status);
                   

                },
                null
                ));

        private ICommand zaktualizujTurnieje;
        public ICommand ZaktualizujTurnieje => zaktualizujTurnieje ?? (zaktualizujTurnieje =
            new RelayCommand(
                o =>
                {
                    TournamentListVM.OdswiezTurnieje();
                },
                null
                ));

        private ICommand zaktualizujTurniejeOrganizatora;
        public ICommand ZaktualizujTurniejeOrganizatora => zaktualizujTurniejeOrganizatora ?? (zaktualizujTurniejeOrganizatora =
            new RelayCommand(
                o =>
                {
                    OrganizerDashboard organizerDashboard = o as OrganizerDashboard;
                    Organizator organizator = new Organizator(organizerDashboard.ZalogowanyUzytkownik.Login);
                    OrganizersTournamentsVM.OdswiezTurnieje(organizator);
                },
                null
                ));

        private ICommand zaakceptujZgloszenie;
        public ICommand ZaakceptujZgloszenie => zaakceptujZgloszenie ?? (zaakceptujZgloszenie =
            new RelayCommand(
                o =>
                {
                    int idStatusu = PlayerListVM.WybraneZgloszenie.IdStatusu;
                    StatusZawodnika.StatusEnum status = StatusZawodnika.StatusEnum.zaakceptowany;
                    if(RepozytoriumStatus.ZaktualizujStatus(idStatusu, status))
                    {
                        MessageBox.Show("Pomyślnie zaakceptowano zgłoszenie do turnieju");
                    }
                },
                null
                ));

        private ICommand clearForm;
        public ICommand ClearForm => clearForm ?? (clearForm =
            new RelayCommand(
                o =>
                {
                    CzyscFormularzDodawaniaTurnieju();
                },
                null
                ));





        #endregion

        /* private ICommand raiseTournamentListSelectionChangedEvent;
         public ICommand RaiseTournamentListSelectionChangedEvent => raiseTournamentListSelectionChangedEvent ?? (raiseTournamentListSelectionChangedEvent =
             new RelayCommand(
                 o =>
                 {
                     RaiseTournamentListSelectionChanged();
                 },
                 null
                 ));

         public void RaiseTournamentListSelectionChanged()
         {
             if (TournamentListSelectionChanged != null)
             {
                 TournamentListSelectionChanged(EventArgs.Empty);
             }
         }


         public delegate void TournamentListSelectionChangedHandler(EventArgs args);

         public event TournamentListSelectionChangedHandler TournamentListSelectionChanged;*/

        #region Metody

        public void CzyscFormularzDodawaniaTurnieju()
        {
            Nazwa = null;
            Miejsce = null;
            Start = DateTime.Now;
            Koniec = DateTime.Now;
            Nagrody = 0;
            Regulamin = null;
        }

        public void WypelnijFormularzZObiektu(Turniej turniej)
        {
            Nazwa = turniej.Nazwa;
            Miejsce = turniej.Miejsce;
            Start = DateTime.Parse(turniej.Start);
            Koniec = DateTime.Parse(turniej.Koniec);
            Nagrody = turniej.PulaNagrod;
            Regulamin = turniej.Regulamin;
        }

        #endregion
    }
}
