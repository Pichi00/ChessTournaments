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

    class ZgloszeniaModel
    {
        public ZgloszeniaModel(Organizator organizator)
        {
            Zgloszenia = PobierzZgloszeniaOrganizatora(organizator);
        }

        public ObservableCollection<Zgloszenie> Zgloszenia { get; set; }

        public ObservableCollection<Zgloszenie> PobierzZgloszeniaOrganizatora(Organizator organizator)
        {
            ObservableCollection<Zgloszenie> zgloszenia = new ObservableCollection<Zgloszenie>();
            var pobraneZgloszenia = RepozytoriumZgloszenie.PobierzZgloszeniaZBazyDlaOrganizatora(organizator);
            foreach (var zgloszenie in pobraneZgloszenia)
            {
                zgloszenia.Add(zgloszenie);
            }

            return zgloszenia;
        }
    }
}
