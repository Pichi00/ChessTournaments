using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    public class Organizator
    {
        public string NazwaOrganizatora { get; set;}
        public string Login { get; set;}

        public Organizator(string nazwa, string login)
        {
            NazwaOrganizatora = nazwa;
            Login = login;
        }

        public string ToInsert()
        {
            return $"('{NazwaOrganizatora}', '{Login}')";
        }
    }
}
