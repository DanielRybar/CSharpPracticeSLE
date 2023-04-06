using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04aLinearniSeznam
{
    class SpojovySeznam<T> where T : IComparable
    {
        public SpojovySeznam()
        {
            zacatek = null;
        }

        Uzel zacatek;
        public int Count
        {
            get
            {
                int pocitadlo = 0;
                Uzel aktualni = zacatek;
                while (aktualni != null)
                {
                    pocitadlo++;
                    aktualni = aktualni.dalsi;
                }
                return pocitadlo;
            }
        }

        // 1) přidejte metodu, která vrátí index zadaného prvku
        public int ZiskejIndexPolozky(T polozka)
        {
            int index = 0;
            Uzel aktualni = zacatek;
            while (aktualni != null)
            {
                if (aktualni.hodn != null && aktualni.hodn.Equals(polozka))
                {
                    return index;
                }
                aktualni = aktualni.dalsi;
                index++;
            }
            return -1;
        }

        // 2) přidejte metodu pro zjištění počtu výskytů prvku T
        public int SpocitejVyskytDanychZnaku(T znak)
        {
            int pocitadlo = 0;
            Uzel aktualni = zacatek;
            while (aktualni != null)
            {
                if (aktualni.hodn != null && aktualni.hodn.Equals(znak))
                {
                    pocitadlo++;
                }
                aktualni = aktualni.dalsi;
            }
            return pocitadlo;
        }

        // 3) přidejte metodu, která obrátí pořadí prvků
        public void ObratPoradiPrvku()
        {
            Uzel aktualni = zacatek;
            Uzel predchozi = null;
            Uzel dalsi = null;
            while (aktualni != null)
            {
                dalsi = aktualni.dalsi;
                aktualni.dalsi = predchozi;
                predchozi = aktualni;
                aktualni = dalsi;
            }
            zacatek = predchozi;
        }

        // 4) přidejte metodu pro odstranění všech prvků větších než vstupní parametr
        public void OdstranPrvkyVetsiNez(T polozka)
        {
            Uzel aktualni = zacatek;
            Uzel predchozi = null;
            Uzel dalsi = null;
            while (aktualni != null)
            {
                dalsi = aktualni.dalsi;
                if (aktualni.hodn.CompareTo(polozka) > 0) // větší než, nikoli rovno
                {
                    if (predchozi == null)
                    {
                        zacatek = dalsi;
                    }
                    else
                    {
                        predchozi.dalsi = dalsi;
                    }
                }
                else
                {
                    predchozi = aktualni;
                }
                aktualni = dalsi;
            }
        }

        // indexer
        // 5) upravte třídu Spojový seznam tak, aby implementovala rozhraní IList<T> neboli umožňovala přístup k prvkům pomocí indexu zapsaného v []
        // - není sice od IList, ale indexování funguje i bez toho
        public T this[int index]
        {
            get
            {
                return ZiskejHodnotuPolozky(index);
            }
            set
            {
                NastavHodnotuPolozky(index, value);
            }
        }

        // 6) přidejte metodu nebo operátor + pro spojení dvou seřazených seznamů tak, aby výsledek byl opět seřazený seznam
        public static SpojovySeznam<T> operator +(SpojovySeznam<T> seznam1, SpojovySeznam<T> seznam2) // přetížení operátoru, kód musí být veřejný a statický
        {
            SpojovySeznam<T> vysledek = new SpojovySeznam<T>();
            Uzel aktualni1 = seznam1.zacatek;
            Uzel aktualni2 = seznam2.zacatek;
            while (aktualni1 != null && aktualni2 != null)
            {
                if (aktualni1.hodn.CompareTo(aktualni2.hodn) < 0)
                {
                    vysledek.VlozNaKonec(aktualni1.hodn);
                    aktualni1 = aktualni1.dalsi;
                }
                else
                {
                    vysledek.VlozNaKonec(aktualni2.hodn);
                    aktualni2 = aktualni2.dalsi;
                }
            }
            while (aktualni1 != null)
            {
                vysledek.VlozNaKonec(aktualni1.hodn);
                aktualni1 = aktualni1.dalsi;
            }
            while (aktualni2 != null)
            {
                vysledek.VlozNaKonec(aktualni2.hodn);
                aktualni2 = aktualni2.dalsi;
            }
            return vysledek;
        }

        
        public void VlozNaZacatek(T vstup)
        {
            var novy = new Uzel(vstup, zacatek);
            /*novy.hodn = vstup;
            novy.dalsi = zacatek;*/
            zacatek = novy;
        }

        public void VlozNaKonec(T vstup)
        {
            var novy = new Uzel(vstup, null);
            /*novy.hodn = vstup;
            novy.dalsi = zacatek;*/
            //zacatek = novy;
            var temp = zacatek;

            if (temp == null)
            {
                zacatek = novy;
                return;
            }

            while (temp.dalsi != null)
            {
                temp = temp.dalsi;
            }

            temp.dalsi = novy;
        }

        public T OdeberPrvni()
        {
            var temp = zacatek;
            if (temp != null)
                zacatek = zacatek.dalsi;
            else
                throw new InvalidOperationException("Sekvence neobsahuje žádné elementy.");

            return temp.hodn;
        }

        public T OdeberPosledni()
        {
            var temp = zacatek;
            if (temp == null)
                throw new InvalidOperationException("Sekvence neobsahuje žádné elementy.");
            if (temp.dalsi == null)
            {
                zacatek = null;
                return temp.hodn;
            }
            while (temp.dalsi.dalsi != null)
            {
                temp = temp.dalsi;
            }
            var temp2 = temp.dalsi;
            temp.dalsi = null;
            return temp2.hodn;
        }

        public T OdeberIndex(int index)
        {
            var temp = zacatek;
            if (index < 0 || index > Count || temp == null)
                throw new InvalidOperationException("Sekvence neobsahuje žádné elementy.");

            if (index == 0)
            {
                zacatek = zacatek.dalsi;
                // OdeberPrvni(); // velmi neefektivní
            }
            else
            {
                Uzel pomocny = temp;
                for (int i = 0; i < index; i++)
                {
                    pomocny = temp;
                    temp = temp.dalsi;
                }

                pomocny.dalsi = temp.dalsi;
            }

            return temp.hodn;
        }

        public T ZiskejHodnotuPolozky(int index)
        {
            return ZiskejUzel(index).hodn;
        }
        public T NastavHodnotuPolozky(int index, T novaHodnota)
        {
            ZiskejUzel(index).hodn = novaHodnota;
            return novaHodnota;
        }

        private Uzel ZiskejUzel(int index)
        {
            Uzel aktualni = zacatek;
            for (int i = 0; i < index; i++)
            {
                if (aktualni != null)
                    aktualni = aktualni.dalsi;
                else
                    throw new IndexOutOfRangeException(index.ToString());
            }

            if (aktualni == null)
                throw new InvalidOperationException("Sekvence neobsahuje žádné elementy.");

            return aktualni;
        }
        
        public override string ToString()
        {
            string vystup = String.Empty;
            Uzel temp = zacatek;

            while (temp != null)
            {
                if (temp.hodn != null)
                {
                    vystup += "," + temp.hodn.ToString();
                    temp = temp.dalsi;
                }
            }

            return vystup.Trim(',');
        }
        
        // vnoreny do tridy SpojovySeznam
        internal class Uzel
        {
            public T hodn;
            public Uzel dalsi/*, predchozi*/;

            public Uzel(T h, Uzel d)
            {
                hodn = h;
                dalsi = d;
            }
        }
    }
}
