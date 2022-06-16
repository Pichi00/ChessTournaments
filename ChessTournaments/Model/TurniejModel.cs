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
        public bool DodajTurniejDoBazy(Turniej turniej)
        {
            if (RepozytoriumTurniej.DodajTurniejDoBazy(turniej)){
                return true;
            }

            return false;
        }

        public int PobierzIDOrganizatora(string login)
        {
            return RepozytoriumOrganizator.PobierzIDOrganizatora(login);
        }
    }
}
