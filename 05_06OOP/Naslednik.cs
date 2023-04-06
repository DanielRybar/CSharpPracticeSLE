using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_06OOP
{
    public sealed class Naslednik : Predchudce // aby nebylo mozne ze tridy dedit, tak ji zapecetim (sealed), prip. ji muzu nastavit jako statickou a prepsat vsechny atributy a metody na staticke
    {
        public new void VypisPozdrav() // tato metoda nepřekrývá původní, ale kompilátor nám doporučil ji označit jako new
        {
            Console.WriteLine("cau");
        }

        public override void VypisDen() // tato metoda překrývá původní
        {
            Console.WriteLine("pátek");
            // _druh = "blabla"; // mam zde pristup k protected atributu z rodicovske tridy

            // pokud ma rodicovska trida soukrome (privatni) atributy, tak k nim nemam pristup z jine tridy
            //      (pouze pokud by byla implementovana metoda, ktera by tento soukromy atribut vracela a byla by pristupna)
            // pokud ma rodicovska trida protected atributy, tak jsou soukrome a ma k nim pristup pouze ta dana trida a tridy z ni odvozene
        }

        public static string operator *(Naslednik first, string second)
        {
            return first._druh + second + "AAAAA";
        }
    }
}

// Modifikátor sealed lze použít také na metodu. Pak dojde k potlačení její virtuálnosti a nelze ji nadále překrývat.
