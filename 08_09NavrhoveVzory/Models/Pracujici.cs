namespace _08_09NavrhoveVzory.Models
{
    public class Pracujici : Osoba
    {
        private static readonly List<Pracujici> _pracujici = new();
        public override string ToString()
        {
            return String.Format("Trida {0}, jmeno {1}, pohlavi {2}, vek {3}", nameof(Pracujici), Jmeno, Pohlavi, Vek);
        }

        private Pracujici(int vek, int pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        { }

        public static new Pracujici GetInstance(int vek, int pohlavi, string jmeno) // originál
        {
            var existence = _pracujici.Where(x => x.Jmeno == jmeno && x.Vek == vek && (int)x.Pohlavi == pohlavi).FirstOrDefault();
            if (existence == null)
            {
                _pracujici.Add(new Pracujici(vek, pohlavi, jmeno));
                return _pracujici[^1];
            }

            return existence;
        }
    }
}
