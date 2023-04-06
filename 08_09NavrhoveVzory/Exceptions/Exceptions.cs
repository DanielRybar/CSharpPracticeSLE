namespace _08_09NavrhoveVzory.Exceptions
{
    public class TooManyInstancesException : Exception
    {
        public TooManyInstancesException(int pocetInstanci) : base("Pocet instanci je vetsi nez " + pocetInstanci)
        { }
    }

    public class PersonFalsificateException : Exception
    {
        public PersonFalsificateException(string category) : base("Osoba nespadá do kategorie " + category + "!!!")
        { }
    }
}
