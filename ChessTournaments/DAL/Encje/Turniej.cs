using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChessTournaments.DAL.Encje
{
    using Repozytoria;
    class Turniej
    {

        #region wlasciwosci
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Miejsce { get; set; }
        public string Start { get; set; }

        public string Koniec { get; set; }
        public double PulaNagrod { get; set; }
        public int Organizator { get; set; }
        public string Regulamin { get; set; }

        public string NazwaOrganizatora { get; set; }

        #endregion

        #region konstruktory
        public Turniej(string nazwa, string miejsce, DateTime start, DateTime koniec, double nagrody, string regulamin, int organizator)
        {
            Nazwa = nazwa;
            Miejsce = miejsce;
            
            Start = start.ToString("yyyy-MM-dd H:mm:ss");
            Koniec = koniec.ToString("yyyy-MM-dd H:mm:ss");
            PulaNagrod = nagrody;
            Regulamin = regulamin;
            Organizator = organizator;
            NazwaOrganizatora = RepozytoriumOrganizator.PobierzNazweOrganizatoraPoID(organizator);

        }

        public Turniej(MySqlDataReader reader)
        {
            Id = int.Parse(reader["idTurnieju"].ToString());
            Nazwa = reader["nazwa"].ToString();
            Miejsce = reader["miejsce"].ToString();
            Start = reader["dataRozpoczecia"].ToString();
            Koniec = reader["dataZakonczenia"].ToString();
            PulaNagrod = double.Parse(reader["pulaNagrod"].ToString());
            Regulamin = reader["regulamin"].ToString();
            Organizator = int.Parse(reader["organizator"].ToString());
            NazwaOrganizatora = RepozytoriumOrganizator.PobierzNazweOrganizatoraPoID(Organizator);
        }
        #endregion

        public string ToInsert()
        {
            return $"('{Nazwa}', '{Miejsce}', '{Start}', '{Koniec}', '{PulaNagrod}', '{Regulamin}', '{Organizator}')";
        }

        /*public override string ToString()
        {
            return base.ToString();
        }*/
    }
}
