using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
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

        public int PobierzIDZawodnika(string login)
        {
            return RepozytoriumZawodnik.PobierzIDZawodnika(login);
        }
    }
}
