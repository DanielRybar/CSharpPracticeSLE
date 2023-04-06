using _04bBinarniStrom;

Console.WriteLine("Zviřátka");
var mujStrom = new Strom<SlovnikoveHeslo>();

Console.WriteLine("Počet na začátku: " + mujStrom.Count);

mujStrom.Vloz(new SlovnikoveHeslo("kůň", "horse"));
mujStrom.Vloz(new SlovnikoveHeslo("pes", "dog"));
mujStrom.Vloz(new SlovnikoveHeslo("kočka", "cat"));
mujStrom.Vloz(new SlovnikoveHeslo("králík", "rabbit"));
mujStrom.Vloz(new SlovnikoveHeslo("had", "snake"));
mujStrom.Vloz(new SlovnikoveHeslo("mravenec", "ant"));
mujStrom.Vloz(new SlovnikoveHeslo("kachna", "duck"));
mujStrom.Vloz(new SlovnikoveHeslo("krokodýl", "crocodile"));
mujStrom.Vloz(new SlovnikoveHeslo("andulka", "dandelion"));

mujStrom.Vloz(new SlovnikoveHeslo("mravenec", "ant"));
mujStrom.Vloz(new SlovnikoveHeslo("kachna", "duck"));
mujStrom.Vloz(new SlovnikoveHeslo("krokodýl", "crocodile"));
mujStrom.Vloz(new SlovnikoveHeslo("mravenec", "ant"));

Console.WriteLine("Výpis stromu: ");
Console.WriteLine(mujStrom);
Console.WriteLine();

Console.WriteLine("Počet: " + mujStrom.Count);
Console.WriteLine("Výška: " + mujStrom.Vyska);
Console.WriteLine();

Console.WriteLine(mujStrom.Odeber(new SlovnikoveHeslo("andulka", "dandelion"))
    ? "Andulka odebrána."
    : "Andulka nenalezena.");
Console.WriteLine();

Console.WriteLine("Vyhledej hada: " + mujStrom.Vyhledej(new SlovnikoveHeslo("had", "snake")));

Console.WriteLine();

// 7) přidejte metodu pro zjištění počtu všech uzlů
Console.WriteLine("Počet prvků: " + mujStrom.Count);

// 8) přidejte metodu pro zjištění počtu výskytů prvku T
Console.WriteLine("Počet mravenců: " + mujStrom.SpocitejVyskytDanychPrvku(new SlovnikoveHeslo("mravenec", "ant"))); 
Console.WriteLine("Počet krokodýlů: " + mujStrom.SpocitejVyskytDanychPrvku(new SlovnikoveHeslo("krokodýl", "crocodile")));

// 9) přidejte metodu pro zjištění počtu uzlů s 0, 1 nebo 2 následníky
Console.WriteLine("Zjisti počet uzlů s žádným následníkem: " + mujStrom.SpocitejNasledniky(0)); 
Console.WriteLine("Zjisti počet uzlů s jedním následníkem: " + mujStrom.SpocitejNasledniky(1));
Console.WriteLine("Zjisti počet uzlů s dvěma následníky: " + mujStrom.SpocitejNasledniky(2));

// 10) přidejte metodu, která zjistí, zda je strom vyvážený
Console.WriteLine("Je strom vyvážený? " + mujStrom.JeVyvazeny()); 


//Teoretická:
//11) Jak jsou v C# vnitřně implementovány třídy:

//a) Stack = ZÁSOBNÍK
// LIFO
// je vnitřně implementován jako pole

//b) Queue = FRONTA
// FIFO
// je vnitřně implemetována jako kruhové (cyklické) pole

//c) Dictionary = SLOVNÍK
// je vnitřně implementován jako pole struktur
// použití HashTable (implementuje asociativní pole)
// pěkně znázorněno na https://dotnetos.org/assets/images/posts/DictionaryImplementation.jpg
// https://dotnetos.org/assets/images/posts/DictionaryKeyDoesNotExist.jpg