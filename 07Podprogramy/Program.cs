//1) Máte podprogram(metodu), která má 4 vstupní parametry:
//podprogram1(p0, p1, p2, p3)
//p0..celé číslo, p1..řetězec, p2..pole, p3..list
//Jak se bude lišit použití/chování těchto vstupních parametrů od podprogramu (metody):
//podprogram2(ref p0, ref p1, ref p2, ref p3)

void podprogram1(int p0, string p1, object[] p2, List<object> p3)
{
    // pole a list jsou referenční datové typy, takže není nutné používat ref, jelikoz se předává pouze odkaz na objekt
    // ale pokud v metodě vytvářím nové instance (new), tak se změny navenek neprojeví. Pak musím klíčové slovo ref použít

    // string je taky referenční datový typ a navíc je ještě immutable (nedá se změnit)
    // pokud tedy v metodě změním string, tak se změna neprojeví, protože se vytvoří nová instance
    // to platí i normálně - pokud třeba sčítám 2 řetězce, tak se vytvoří řetězec nový
    
    p0 = 10;
    p1 = "cau";
    p2 = new object[] { "a", "b", "c", "d", 1000 };
    p3.Reverse(); // pořadí se obrátí
    p3 = new() { 1, 2, 3 }; // ale změny se neprojeví, protože se vytvoří nová instance
}

void podprogram2(ref int p0, ref string p1, ref object[] p2, ref List<object> p3)
{
    p0 = 10;
    p1 = "cau";
    p2 = new object[] { "a", "b", "c", "d", 1000 };
    p3 = new() { 1, 2, 3 };
}

int cislo = 50;
string retez = "ahoj";
object[] pole = new object[5] { "klokan", "cvrcek", "beruska", 20, 0.5f };
List<object> list = new List<object>() { "mravenecnik", "pasovec", "lenochod", "opice" };

Console.WriteLine("VÝPIS PRVKŮ");
Console.WriteLine(cislo);
Console.WriteLine(retez);
Console.WriteLine();
Console.WriteLine("pole: ");
foreach (var item in pole)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine("list: ");
foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// pri zavolani podprogramu1 se hodnoty promennych nezmeni, jelikoz se vytvori pouze lokalni kopie na zasobniku a po skonceni podprogramu se tyto kopie vymazou
// => zmeny se tedy neprojevi
// = predaní hodnotou
Console.WriteLine("------------------------------------");
Console.WriteLine("PŘEDÁNÍ HODNOTOU: ");
podprogram1(cislo, retez, pole, list);
Console.WriteLine(cislo);
Console.WriteLine(retez);
Console.WriteLine();
Console.WriteLine("pole: ");
foreach (var item in pole)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine("list: ");
foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine();


// pri predani referenci se nevytvari lokalni kopie promenne, ale do podprogramu se předá skutecna promenna (primo tedy jeji skutecna adresa v pameti),
//      a vsechny zmeny se tak nasledne promítnou i do promennych
// => zmeny se tedy projeví
// = predaní referencí, odkazem, aluzí
Console.WriteLine("------------------------------------");
Console.WriteLine("PŘEDÁNÍ REFERENCÍ: ");
podprogram2(ref cislo, ref retez, ref pole, ref list);
Console.WriteLine(cislo);
Console.WriteLine(retez);
Console.WriteLine();
Console.WriteLine("pole: ");
foreach (var item in pole)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine("list: ");
foreach (var item in list)
{
    Console.WriteLine(item);
}
Console.WriteLine();


//2) Komponenty UI(např.Button) umožňují reagovat na různé události. Jedná se o delegáty?

// delegáty:
// => delegát je typově bezpečný ukazatel na metodu
// => klíčové slovo delegate
// => delegát je nezávislý a není závislý na událostech
// => delegát může být předán jako parametr metody
// =>  = operátor se používá k přiřazení jedné metody a operátor += se používá k přiřazení více metod delegátovi.

// události:
// => klíčové slovo event
// => u události nelze zajistit typovou bezpečnost odesílatele (sendera), musí se explicitně testovat v události 
// např. if (sender is Button) { ... }
// => je to mechanismus oznámení, který závisí na delegátech
// => událost je závislá na delegátovi a nelze ji vytvořit bez delegátů
// => událost je vyvolána, ale nemůže být předána jako parametr metody.
// => = operátor nelze použít s událostmi a pouze operátor += a -= lze použít s událostí, která přidá nebo odebere obslužnou rutinu události

// Svým způsobem je událost pouze delegátem.
// Pomocí klíčového slova event však zabráníme odběratelům (předplatitelům) zaregistrovat se k události pomocí operátoru = a tím odstranit všechny obslužné rutiny.

/*
public delegate void Notify();
public Notify MyDelegate;

MyDelegate = MyMethod;// valid
MyDelegate += MyMethod;// valid

public delegate void Notify();
public event Notify MyEvent;

MyEvent = MyEventHandler;// Error
MyEvent += MyEventHandler;// valid
*/


//3) Vytvořte(příklad) metody se 2 vstupními parametry:
//1.parametr - seznam(list) celých čísel
//2. parametr - delegát na metodu, která se aplikuje na všechny prvky seznamu

List<int> Metoda(List<int> seznam, MyDelegate fce)
{
    List<int> list = new List<int>();
    foreach (int item in seznam)
    {
        list.Add(fce(item));
    }
    return list;
}
MyDelegate del = (int item) => { return item += 100; };

List<int> seznam = new() { 5, 4, 3, 2, 1, 0, -1 };

List<int> novySeznam = Metoda(seznam, del);
foreach (var item in novySeznam)
{
    Console.WriteLine(item);
}

Console.WriteLine();


//4) Jaké jsou výhody/nevýhody třídních a instančních metod?

// třídní (statické) metody
// - u třídy se nevytváří instance (přístup přes Třída.Metoda())
// - všechny prvky uvnitř statické třídy musí být rovněž statické
// - konstruktor zde musí být neparametrický a spouští se při prvním zavolání metody z třídy (Třída.Metoda())
// - třída nepodporuje implementaci rozhraní
// - statická třída je automaticky zapečetěná a nelze od ní vytvořit instanci + sama nesmí být odvozena z jiné třídy
// - zabírají o trochu méně paměti

// instanční metody
// - nutnost vytvoření instance (objektu)
// - volání přes objekt.Metoda()
// - metody uvnitř nemusí a můžou být statické
// - možnost použití parametrického konstruktoru
// - třída podporuje implementaci rozhraní


//5) Uveďte příklady využití lambda operátorů (C#).

// použítí anonymních funkcí
Action<string>? ShowMessage;
ShowMessage = (msg) => Console.WriteLine(msg);
ShowMessage?.Invoke("Hello World");

// u LINQ metod
int[] nums = { 2, 4, 5, 6 };
var squaredNums = nums.Select(x => x * x);
Console.WriteLine(string.Join(", ", squaredNums));

// novější zápis konstrukce switch-case
int x = 1;
int y = x switch { 1 => 5, 2 => 10, _ => 0 };
// pokud je x=1, do y se uloží 5, pokud je x=2, do y se uloží 10, jinak se do y uloží 0
Console.WriteLine(y);

// vlastnosti
struct Props
{
    private string name;
    public string Name { get => name; set => name = value; }
}



public delegate int MyDelegate(int item);