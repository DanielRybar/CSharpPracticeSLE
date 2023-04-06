using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _04bBinarniStrom
{
    public class Strom<T> where T : IComparable
    {
        StromovyUzel<T> koren = null;

        // 7) přidejte metodu pro zjištění počtu všech uzlů
        // vlastnost je lepší
        public int Count { get => ZjistiPocetUzlu(koren); }
        private int ZjistiPocetUzlu(StromovyUzel<T> uzel)
        {
            if (uzel == null)
                return 0;
            else
                return 1 + ZjistiPocetUzlu(uzel.levy) + ZjistiPocetUzlu(uzel.pravy);
        }

        // 8) přidejte metodu pro zjištění počtu výskytů prvku T (ve stromě se prvky se stejnou hodnotou mohou opakovat)
        public int SpocitejVyskytDanychPrvku(T vstup)
        {
            return SpocitejVyskytDanychPrvkuRekurzivne(koren, vstup);
        }
        private static int SpocitejVyskytDanychPrvkuRekurzivne(StromovyUzel<T> uzel, T vstup)
        {
            if (uzel == null)
                return 0;
            else if (uzel.hodn.CompareTo(vstup) == 0)
                return 1 + SpocitejVyskytDanychPrvkuRekurzivne(uzel.levy, vstup) + SpocitejVyskytDanychPrvkuRekurzivne(uzel.pravy, vstup);
            else if (uzel.hodn.CompareTo(vstup) == -1)
                return SpocitejVyskytDanychPrvkuRekurzivne(uzel.levy, vstup);
            else
                return SpocitejVyskytDanychPrvkuRekurzivne(uzel.pravy, vstup);
        }

        // 9) přidejte metodu pro zjištění počtu uzlů s 0, 1 nebo 2 následníky (0, 1, 2 bude vstupní parametr)
        public int SpocitejNasledniky(int pocetNasledniku)
        {
            return SpocitejNaslednikyRekurzivne(koren, pocetNasledniku);
        }
        private static int SpocitejNaslednikyRekurzivne(StromovyUzel<T> uzel, int pocetNasledniku)
        {
            if (uzel == null)
                return 0;
            else if (pocetNasledniku == 0)
            {
                if (uzel.levy == null && uzel.pravy == null)
                    return 1
                        + SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
                else
                    return SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
            }
            else if (pocetNasledniku == 1)
            {
                if ((uzel.levy == null && uzel.pravy != null) || (uzel.levy != null && uzel.pravy == null))
                    return 1 
                        + SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
                else
                    return SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
            }
            else if (pocetNasledniku == 2)
            {
                if (uzel.levy != null && uzel.pravy != null)
                    return 1 
                        + SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
                else
                    return SpocitejNaslednikyRekurzivne(uzel.levy, pocetNasledniku) 
                        + SpocitejNaslednikyRekurzivne(uzel.pravy, pocetNasledniku);
            }
            else
            {
                return -1; // pokud není parametr 0,1,2
            }
        }

        // 10) přidejte metodu, která zjistí, zda je strom vyvážený
        public bool JeVyvazeny()
        {
            return JeVyvazenyRekurzivne(koren);
        }
        private static bool JeVyvazenyRekurzivne(StromovyUzel<T> uzel)
        {
            if (uzel == null)
                return true;
            else if (Math.Abs(VyvazeniRekurzivne(uzel.levy) - VyvazeniRekurzivne(uzel.pravy)) > 1)
                return false;
            else
                return JeVyvazenyRekurzivne(uzel.levy) && JeVyvazenyRekurzivne(uzel.pravy);
        }
        private static int VyvazeniRekurzivne(StromovyUzel<T> uzel)
        {
            if (uzel == null)
                return 0;
            else
                return 1 + Math.Max(VyvazeniRekurzivne(uzel.levy), VyvazeniRekurzivne(uzel.pravy));
        }
        

        public int Vyska { get => ZjistiVysku(koren); }
        private int ZjistiVysku(StromovyUzel<T> uzel)
        {
            if (uzel == null)
                return 0;
            else
                return 1 + Math.Max(ZjistiVysku(uzel.levy), ZjistiVysku(uzel.pravy));
        }

        public void Vloz(T polozka)
        {
            if (koren == null)
            {
                koren = new StromovyUzel<T>(polozka);
                return;
            }
            VlozRekurzivne(koren, ref polozka);
        }
        private static void VlozRekurzivne(StromovyUzel<T> koren, ref T novy)
        {
            if (koren.hodn.CompareTo(novy) == -1)
            {
                if (koren.levy == null)
                    koren.levy = new StromovyUzel<T>(novy);
                else
                    VlozRekurzivne(koren.levy, ref novy);
            }
            else
            {
                if (koren.pravy == null)
                    koren.pravy = new StromovyUzel<T>(novy);
                else
                    VlozRekurzivne(koren.pravy, ref novy);
            }
        }

        public bool Odeber(T polozka)
        {
            if (koren == null)
                //throw new InvalidOperationException("Kořen neobsahuje žádné elementy.");
                return false;

            return OdeberRekurzivne(ref koren, ref polozka);
        }
        private static bool OdeberRekurzivne(ref StromovyUzel<T> koren, ref T vstup)
        {
            if (koren.hodn.CompareTo(vstup) == 0)
            {
                if (koren.levy == null && koren.pravy == null)
                {
                    koren = null;
                    return true;
                }
                else if (koren.levy == null)
                {
                    koren = koren.pravy;
                    return true;
                }
                else if (koren.pravy == null)
                {
                    koren = koren.levy;
                    return true;
                }
                else
                {
                    koren.hodn = NajdiNahradu(ref koren.levy);
                    return true;
                }
            }
            else if (koren.hodn.CompareTo(vstup) == -1)
            {
                if (koren.levy == null)
                    return false;
                else
                    return OdeberRekurzivne(ref koren.levy, ref vstup);
            }
            else
            {
                if (koren.pravy == null)
                    return false;
                else
                    return OdeberRekurzivne(ref koren.pravy, ref vstup);
            }
        }
        private static T NajdiNahradu(ref StromovyUzel<T> uzel)
        {
            if (uzel.pravy == null)
            {
                T vysl = uzel.hodn;
                uzel = uzel.levy;
                return vysl;
            }
            else
                return NajdiNahradu(ref uzel.pravy);
        }

        // vyhledavani
        public bool Vyhledej(T vstup)
        {
            return VyhledejRekurzivne(koren, vstup);
        }
        private static bool VyhledejRekurzivne(StromovyUzel<T> uzel, T vstup)
        {
            if (uzel == null)
                return false;
            else if (uzel.hodn.CompareTo(vstup) == 0)
                return true;
            else if (uzel.hodn.CompareTo(vstup) == -1)
                return VyhledejRekurzivne(uzel.levy, vstup);
            else
                return VyhledejRekurzivne(uzel.pravy, vstup);
        }

        public override string ToString()
        {
            return VypisStrom(koren);
        }
        private static string VypisStrom(StromovyUzel<T> uzel)
        {
            if (uzel == null)
                return "";
            else
                return VypisStrom(uzel.levy) + " / " + uzel.hodn + " / " + VypisStrom(uzel.pravy);
        }

    }
    
    public class StromovyUzel<T>
    {
        public T hodn;
        public StromovyUzel<T> levy;
        public StromovyUzel<T> pravy;

        public StromovyUzel(T h)
        {
            hodn = h;
            levy = pravy = null;
        }
    }
}
