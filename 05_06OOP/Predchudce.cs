using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_06OOP
{
    public class Predchudce
    {
        private string _jmeno = "Cyril"; // neveřejný atribut
        protected string _druh = "Člověk"; // neveřejný atribut, který je ale přístupný z následníka

        public void VypisPozdrav() // první metoda
        {
            Console.WriteLine("ahoj");
        }

        public virtual void VypisDen() // tato metoda je virtuální a tedy překrytelná
        {
            Console.WriteLine("čtvrtek");
        }

        //Kód přetěžující operátor je veřejný a statický. Alespoň jeden typ musí být stejný jako třída, kde se kód nachází.
        public static string operator *(Predchudce first, string second)
        {
            return first._jmeno + second;
        }
    }
}
