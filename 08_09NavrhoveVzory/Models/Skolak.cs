using _08_09NavrhoveVzory.Exceptions;

namespace _08_09NavrhoveVzory.Models
{
    public class Skolak : Osoba
    {
        private const int POCET_INSTANCI = 4;
        private static readonly List<Skolak> _skolaci = new();
        public override string ToString()
        {
            return String.Format("Trida {0}, jmeno {1}, pohlavi {2}, vek {3}", nameof(Skolak), Jmeno, Pohlavi, Vek);
        }

        private Skolak(int vek, int pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        { }

        public static new Skolak GetInstance(int vek, int pohlavi, string jmeno) // pool = bazén
        {
            if (_skolaci.Count < POCET_INSTANCI) // pokud je pocet instanci mensi nez POCET_INSTANCI, vytvori se nova instance
            {
                _skolaci.Add(new Skolak(vek, pohlavi, jmeno));
                return _skolaci[^1];
            }
            else // jinak se vrati posledni vytvorena instance nebo se vyhodi vyjimka
            {
                //return _skolaci[^1];
                throw new TooManyInstancesException(POCET_INSTANCI);
            }
        }

        public static void ReleaseInstance(Osoba instance)
        {
            if (instance is Skolak skolak)
            {
                _skolaci.Remove(skolak); // odstrani referenci z kolekce, bohuzel si muzu udrzet kopii
                // resenim je destruktor s poctem instanci, ale funguje jen kdyz neni garbage collector
            }
            else throw new PersonFalsificateException(nameof(Skolak));
        }
    }
}
