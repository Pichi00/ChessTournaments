using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace ChessTournaments.View
{
    /// <summary>
    /// Logika interakcji dla klasy OrganizerDashboard.xaml
    /// </summary>
    using DAL.Encje;
    public partial class OrganizerDashboard : Window
    {
        public Uzytkownik ZalogowanyUzytkownik { get; set; }
        public OrganizerDashboard(Uzytkownik uzytkownik)
        {
            
            InitializeComponent();
            ZalogowanyUzytkownik = uzytkownik;

        }

        private void nagrody_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
