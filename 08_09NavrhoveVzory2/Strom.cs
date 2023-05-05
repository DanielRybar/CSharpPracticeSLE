using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_09NavrhoveVzory2
{
    abstract class SouborovyPrvek // komponenta
    {
        public virtual string? Nazev { get; }
        public virtual int Velikost { get; }
    }
    class Soubor : SouborovyPrvek // atomický prvek (leaf)
    {
        public override string? Nazev { get; }
        public override int Velikost { get; }
    }
    class Slozka : SouborovyPrvek // skupina (composite) 
    {
        public List<SouborovyPrvek> Soubory { get; }
        public override string? Nazev { get; }
        public override int Velikost { get => RekurzivniVelikost(); }

        private int RekurzivniVelikost()
        {
            int velikost = 0;
            foreach (var soubor in Soubory)
            {
                velikost += soubor.Velikost;
            }
            return velikost;
        }
    }
}