using _04aLinearniSeznam;

var mujSeznam = new SpojovySeznam<int>();

mujSeznam.VlozNaKonec(1);
mujSeznam.VlozNaKonec(2);
mujSeznam.VlozNaKonec(3);
mujSeznam.VlozNaKonec(4);
mujSeznam.VlozNaKonec(5);
mujSeznam.VlozNaKonec(2);
mujSeznam.VlozNaKonec(6);
mujSeznam.VlozNaKonec(7);
mujSeznam.VlozNaKonec(8);
mujSeznam.VlozNaKonec(9);
mujSeznam.VlozNaKonec(10);

Console.WriteLine(mujSeznam);
Console.WriteLine("Odebrání prvního prvku: " + mujSeznam.OdeberPrvni());
Console.WriteLine(mujSeznam);

Console.WriteLine("Odebrání posledního prvku: " + mujSeznam.OdeberPosledni());
Console.WriteLine(mujSeznam);
Console.WriteLine("Počet: " + mujSeznam.Count);
Console.WriteLine("Výskyt dvojek: " + mujSeznam.SpocitejVyskytDanychZnaku(2)); // 2) přidejte metodu pro zjištění počtu výskytů prvku T
Console.WriteLine("Index pětky: " + mujSeznam.ZiskejIndexPolozky(polozka: 5)); // 1) přidejte metodu, která vrátí index zadaného prvku
Console.WriteLine(mujSeznam);
Console.WriteLine("Prvek na indexu 1: " + mujSeznam.ZiskejHodnotuPolozky(index: 1));
Console.WriteLine("Změna hodnoty prvku na indexu 1: " + mujSeznam.NastavHodnotuPolozky(index: 1, novaHodnota: 1000));
Console.WriteLine(mujSeznam);
Console.WriteLine("Prvek na indexu 4: " + mujSeznam[4]); // 5) indexování
mujSeznam[4] = 2000; // 5) indexování

Console.WriteLine();
Console.WriteLine(mujSeznam);
mujSeznam.ObratPoradiPrvku(); // 3) přidejte metodu, která obrátí pořadí prvků
Console.WriteLine("Obrácené pořadí: " + mujSeznam);
Console.WriteLine("Odstranění prvků větších než 1000");
mujSeznam.OdstranPrvkyVetsiNez(1000); // 4) přidejte mtodu pro odstranění všech prvků větších než vstupní parametr
Console.WriteLine(mujSeznam);

SpojovySeznam<int> scitanec1 = new SpojovySeznam<int>();
scitanec1.VlozNaKonec(1);
scitanec1.VlozNaKonec(2);
scitanec1.VlozNaKonec(3);
scitanec1.VlozNaKonec(4);
scitanec1.VlozNaKonec(5);
scitanec1.VlozNaKonec(50);
scitanec1.VlozNaKonec(198);

SpojovySeznam<int> scitanec2 = new SpojovySeznam<int>();
scitanec2.VlozNaKonec(8);
scitanec2.VlozNaKonec(10);
scitanec2.VlozNaKonec(900);
scitanec2.VlozNaKonec(4562);
scitanec2.VlozNaKonec(5000);
scitanec2.VlozNaKonec(6000);
scitanec2.VlozNaKonec(110000);

SpojovySeznam<int> spojenySeznam = scitanec1 + scitanec2; // 6) přetížení operátoru +
Console.WriteLine("Spojený seznam: " + spojenySeznam);