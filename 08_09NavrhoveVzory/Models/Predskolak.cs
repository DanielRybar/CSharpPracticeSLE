namespace _08_09NavrhoveVzory.Models
{
    public class Predskolak : Osoba
    {
        private static Predskolak predskolak;

        public override string ToString()
        {
            return String.Format("Trida {0}, jmeno {1}, pohlavi {2}, vek {3}", nameof(Predskolak), Jmeno, Pohlavi, Vek);
        }

        private Predskolak(int vek, int pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        {
        }

        public static new Predskolak GetInstance(int vek, int pohlavi, string jmeno) // singleton = jedináček
        {
            /*
            if (predskolak == null)
            {
                predskolak = new Predskolak(vek, pohlavi, jmeno);
            }
            */
            predskolak ??= new Predskolak(vek, pohlavi, jmeno); // neni thread safe

            /*
            // thread safe implementace singletonu
            lock(_lock)
            {
                if (instance == null)
            }
            */

            return predskolak;
        }
    }
}
