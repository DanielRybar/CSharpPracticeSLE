namespace _08_09NavrhoveVzory.Models
{
    public class Osoba : object
    {
        protected readonly int _vek;
        protected readonly Pohlavi _pohlavi;
        protected readonly string _jmeno;

        protected Osoba(int vek, int pohlavi, string jmeno)
        {
            _vek = vek;
            _pohlavi = (Pohlavi)pohlavi;
            _jmeno = jmeno;
        }

        public int Vek { get => _vek; }
        public Pohlavi Pohlavi { get => _pohlavi; }
        public string Jmeno { get => _jmeno; }

        public static Osoba GetInstance(int vek, int pohlavi, string jmeno) // tovární metoda
        {
            if (vek < 0) throw new NullReferenceException("Nulova reference.");
            else if (vek >= 0 && vek <= 7) return Predskolak.GetInstance(vek, pohlavi, jmeno);
            else if (vek >= 8 && vek <= 19) return Skolak.GetInstance(vek, pohlavi, jmeno);
            else if (vek >= 20 && vek <= 65) return Pracujici.GetInstance(vek, pohlavi, jmeno);
            else return new Duchodce(vek, pohlavi, jmeno);
        }

        public Osoba Starnuti(int cislo)
        {
            return GetInstance(_vek + cislo, (int)_pohlavi, _jmeno);
        }
    }
}