using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    using Repozytoria;
    public class Organizator
    {
        public string NazwaOrganizatora { get; set;}
        public string Login { get; set;}
        public int Id { get; set;}

        public Organizator(string nazwa, string login)
        {
            NazwaOrganizatora = nazwa;
            Login = login;
            Id = RepozytoriumOrganizator.PobierzIDOrganizatora(login);
        }
        public Organizator(string login)
        {
            Login = login;
            Id = RepozytoriumOrganizator.PobierzIDOrganizatora(login);
            NazwaOrganizatora = RepozytoriumOrganizator.PobierzNazweOrganizatoraPoID(Id);
        }

        public string ToInsert()
        {
            return $"('{NazwaOrganizatora}', '{Login}')";
        }
    }
}
