namespace _08_09NavrhoveVzory.Models
{
    public class Duchodce : Osoba
    {
        public override string ToString()
        {
            return String.Format("Trida {0}, jmeno {1}, pohlavi {2}, vek {3}", nameof(Duchodce), Jmeno, Pohlavi, Vek);
        }

        public Duchodce(int vek, int pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        { }
    }
}