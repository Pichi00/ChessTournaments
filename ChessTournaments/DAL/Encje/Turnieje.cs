using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournaments.DAL.Encje
{
    class Turnieje
    {
        #region wlasciwosci
        public String Nazwa { get; set; }
        public String Miasto { get; set; } 
        public DateTime Start { get; set; }
        
        public DateTime Koniec { get; set; }
        public String PulaNagrod { get; set; }
        public String organizator { get; set; }
        public String regulamin{ get; set; }

        #endregion
    }
}
