using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03StrukturovaneDatoveTypy
{
    public struct Beer // struktura
    {
        //string nazev;
        //int price;

        // lepší přes privátní proměnné
        private string _nazev;
        private int _price;

        public Beer(string nazev, int price)
        {
            //this.nazev = nazev;
            //this.price = price;
            _nazev = nazev;
            _price = price;
        }

        public override string ToString()
        {
            return _nazev + " " + _price + " Kč";
        }
    }
}
