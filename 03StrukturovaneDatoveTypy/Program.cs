using _03StrukturovaneDatoveTypy;
using System.Collections;

// 1) Vytvořte co nejjednodušší příklad demonstrující alespoň 2 rozdíly mezi struct a class.

// struktura
// - Lze chápat jako uživatelsky definovaný hodnotový typ / odlehčenou třídu
// - Je to hodnotový datový typ, nepodporuje dědičnost
// - Může mít konstruktor, atributy, metody, vlastnosti, ...

// Struct vs Class
// - struktura je hodnotový datový typ, třída je referenční datový typ
// příklad viz 01ZakladniProgramoveKonstrukce\Program.cs


// 2) Vytvořte generickou třídu implementující Sk1) frontu Sk2) zásobník pomocí pole. 
// Konstruktor bude mít parametr - počáteční kapacita. 
// Třída bude kromě konstruktoru obsahovat metody pro vkládání, odebírání, zjištění počtu prvků a změnu velikosti (Resize s parametrem nová kapacita). 
Zasobnik<string> stack = new(5);
stack.Push("antilopa");
stack.Push("beruska");
stack.Push("cvrcek");
stack.Print();
Console.WriteLine("Odebral se: " + stack.Pop());
stack.Print();
Console.WriteLine(stack.Count);
Console.WriteLine(stack.CountNotNull);

Console.WriteLine();
Console.WriteLine("------------------");
Console.WriteLine();

// PŘEHLED:
// Strukturované datové typy
// - objekty skládající se z několika komponent (členů)
// homogenní - komponenty stejného typu; heterogenní - komponenty různého typu

// výčtový typ - enum -> NENÍ STRUKTUROVANÝ DATOVÝ TYP, K ČÍSLŮM JE POUZE PŘIŘAZENA HODNOTA

// struktura
// - Lze chápat jako uživatelsky definovaný hodnotový typ / odlehčenou třídu
// - Je to hodnotový datový typ, nepodporuje dědičnost
// - Může mít konstruktor, atributy, metody, vlastnosti, ...

Beer plzen = new Beer("Pilsner Urquell", 55); // instance struktury Beer s inicializací přes parametrický konstruktor
Console.WriteLine(plzen);
Console.WriteLine();

// Struct vs Class
// - struktura je hodnotový datový typ, třída je referenční datový typ

// objekt
// = instance
// - V podstatě místo v paměti alokované a nakonfigurované třídou / strukturou
// - Program může vytvořit několik objektů stejné třídy / struktury
// - Může být uložen v proměnné / kolekci
// - V C# je třída Object nejvyšší základní třída

// pole
// - Množina proměnných stejného datového typu = homogenní strukturovaný datový typ
// - S polem se zachází jako s celkem, k jednotlivým proměnným se přistupuje přes index. V C# se indexuje od nuly.
int[] cisla1; // prázdné pole - vlastně jen místo v paměti, kam se má pole vytvořit
int[] cisla2 = new int[3]; // pole, které bude mít délku 3 = může obsahovat maximálně 3 prvky
int[] cisla3 = new int[3] { 1, 2, 3 };
int[] cisla4 = new int[] { 1, 2, 3 };
int[] cisla5 = { 1, 2, 3 }; // pole, které bude o začátku naplněno uvedenými hodnotami

// Přístup k obsahu
cisla3[0] = 1;
cisla3[2] = 2;
Console.WriteLine(cisla3[0]);
Console.WriteLine();

// Výpis
for (int i = 0; i < cisla3.Length; i++)
{
    Console.WriteLine(cisla3[i]); // k hodnotě musíme přistoupit přes pole
}
Console.WriteLine();
foreach (int x in cisla3)
{
    Console.WriteLine(x); // foreach poskytuje přímo hodnotu, není ale dostupná informace o pozici v poli
}
int inc = 0;
foreach (int x in cisla3)
{
    Console.WriteLine(x);
    inc++;
}
Console.WriteLine();

// pole je referenční datový typ - proměnná obsahuje jen adresu (=referenci, aluzi), na které se obsah proměnné nachází
int[] prvni = { 1, 1, 1, 1, 1 };
int[] druhe = prvni; // tady říkám, že pole druhe bude ukazovat na to samé místo v paměti, kde je pole prvni
druhe[2] = 2; // přepíše se i první - vytváříme pouze mělkou kopii
foreach (int x in prvni)
{
    Console.WriteLine(x);
}
Console.WriteLine();

// dvourozměrné pole
int[,] array = new int[4, 2];
int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
Console.WriteLine(array2D[0, 0]);
Console.WriteLine(array2D[0, 1]);
Console.WriteLine(array2D[1, 0]);
Console.WriteLine(array2D.Length); // jako kdyby to bylo jednorozmerne pole = 8
foreach (var x in array2D)
{
    Console.Write(x); // opět - vypíše prvky za sebe, jako by šlo o jednorozměrné pole
}
Console.WriteLine();
Console.WriteLine(array2D.Rank); // kolik má pole rozměrů
Console.WriteLine();
var sirka = array2D.GetLength(0); // delka v dimenzi 0
var delka = array2D.GetLength(1); // délka v dimenzi 1
for (int i = 0; i < sirka; i++)
{
    for (int j = 0; j < delka; j++)
    {
        Console.Write(array2D[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine();

// třírozměrné pole
int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
Console.WriteLine(array3D[1, 0, 1]);
Console.WriteLine(array3D[1, 1, 2]);
Console.WriteLine();

// zubaté pole
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[5];
jaggedArray[1] = new int[4];
jaggedArray[2] = new int[2];
jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
jaggedArray[1] = new int[] { 0, 2, 4, 6 };
jaggedArray[2] = new int[] { 11, 22 };
int[][] jaggedArray2 = new int[][]
{
    new int[] { 1, 3, 5, 7, 9 },
    new int[] { 0, 2, 4, 6 },
    new int[] { 11, 22 }
};
jaggedArray[0][1] = 77;
foreach (int[] x in jaggedArray)
{
    foreach (int y in x)
    {
        Console.WriteLine(y);
    }
}
Console.WriteLine();

// vlastnosti pole
Console.WriteLine(jaggedArray.Length); // délka pole
Console.WriteLine(jaggedArray.Rank); // počet rozměrů pole
Console.WriteLine(Array.MaxLength); // statická vlastnost určující maximální deklarovatelnou velikost jednorozměrného pole

int[] poletest = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };
Console.WriteLine(Array.IndexOf(poletest, 2)); // 1
Console.WriteLine(Array.IndexOf(poletest, 2)); // Prohledáváme od začátku = 1
Console.WriteLine(Array.IndexOf(poletest, 5)); // Prvek v poli není = -1
Console.WriteLine(Array.IndexOf(poletest, 2, 3)); // Prohledáváme od indexu 3 dál = 4
Console.WriteLine(Array.LastIndexOf(poletest, 2)); // 4
Console.WriteLine(Array.Exists(poletest, x => x > 10)); // existují v poli prvky s hodnotou větší než 10? = true
Console.WriteLine(Array.Find(poletest, x => x == 2)); // vrací hodnotu prvku = 2
Console.WriteLine(Array.Find(poletest, x => x == 5)); // prvek v poli není -> defaultní hodnota = 0​
int[] vysledek = Array.FindAll(poletest, x => x > 4);
foreach (int i in vysledek)
{
    Console.WriteLine(i); // 8,9,6,11
}
Console.WriteLine(Array.FindIndex(poletest, x => x == 2)); // 1
Console.WriteLine(Array.FindIndex(poletest, x => x == 5)); // prvek v poli není = -1
Console.WriteLine();

// mělká vs hluboká kopie
// - mělká - pouze reference na stejné místo v paměti - všechny změny se tedy ve všech mělkých kopiích téhož pole
// - hluboká - zkopíruje a založí nové objekty
int[] pole = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };
int[] pole2 = (int[])pole.Clone(); // pozn. v JavaScriptu operátor spread: pole1 = [...pole2];
pole2[1] = 100;
foreach (int i in pole)
{
    Console.WriteLine(i); // 1,2,4,8,2,9,6,11,3
}
Console.WriteLine();
foreach (int i in pole2)
{
    Console.WriteLine(i); // 1,100,4,8,2,9,6,11,3
}
Console.WriteLine();

// změna velikosti pole
int[] pole10 = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };
Console.WriteLine(pole10.Length); // 9
Console.WriteLine();
Array.Resize(ref pole10, pole10.Length + 1);
foreach (int i in pole10)
{
    Console.WriteLine(i); // 1,2,4,8,2,9,6,11,3,0
}
Console.WriteLine();
Console.WriteLine(pole10.Length); // 10
Console.WriteLine();

// vlastní kód
int[] pole20 = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };
ResizeArray(ref pole20, pole20.Length + 3);
foreach (int i in pole20)
{
    Console.WriteLine(i); // 1, 2, 4, 8, 2, 9, 6, 11, 3, 0, 0, 0
}
void ResizeArray(ref int[] arr, int newSize)
{
    int[] result = new int[newSize];
    for (int i = 0; i < result.Length; i++)
    {
        if (i < arr.Length) result[i] = arr[i];
    }
    arr = result;
}
Console.WriteLine();
// - pole je v paměti uloženo jako souvislý blok, proto zmenšování není problémem (bude paměť navíc), ale zvětšování z hlediska paměti problémem je

// Kolekce
// - standardní datové struktury doplňující pole
// https://www.geeksforgeeks.org/collections-in-c-sharp/

// -- Generické (s datovým typem) --
// List<string>
Console.WriteLine("--- List");
List<string> list1 = new List<string> { "Antilopa", "Fenek", "Bizon", "Cvrček", "Datel", "Emu" };
list1.Add("Gekon");
foreach (string l in list1)
{
    Console.WriteLine(l);
}
// Dictionary<string,string>
Console.WriteLine("--- Dictionary");
Dictionary<string, string> dict1 = new Dictionary<string, string> { { "Antilopa", "Antelope" }, { "Cvrček", "Cricket" }, { "Datel", "Woodpecker" }, { "Bizon", "Bison" } };
dict1.Add("Gekon", "Gecko");
foreach (KeyValuePair<string, string> item in dict1)
{
    Console.WriteLine(item.Key + "=" + item.Value);
}
// Queue<string>
Console.WriteLine("--- Queue");
Queue<string> fronta1 = new Queue<string>();
fronta1.Enqueue("Antilopa");
fronta1.Enqueue("Bizon");
fronta1.Enqueue("Cvrček");
while (fronta1.Any())
{
    Console.WriteLine(fronta1.Dequeue());
}
// Stack<string>
Console.WriteLine("--- Stack");
Stack<string> stack1 = new Stack<string>();
stack1.Push("Antilopa");
stack1.Push("Bizon");
stack1.Push("Cvrček");
while (stack1.Any())
{
    Console.WriteLine(stack1.Pop());
}
// HashSet<string>
// https://docs.microsoft.com/cs-cz/dotnet/api/system.collections.generic.hashset-1?view=netcore-3.1
// Unikátní prvky
Console.WriteLine("--- HashSet");
HashSet<string> list2 = new HashSet<string> { "Antilopa", "Fenek", "Bizon", "Cvrček", "Datel", "Emu" };
list2.Add("Gekon");
list2.Add("Antilopa"); // nevloží se, protože už tam je
foreach (string l in list2)
{
    Console.WriteLine(l);
}
// LinkedList<string>
// https://docs.microsoft.com/cs-cz/dotnet/api/system.collections.generic.linkedlist-1?view=netcore-3.1
// Rychlé vkládání a odstraňování
Console.WriteLine("--- LinkedList");
LinkedList<string> list3 = new LinkedList<string>();
list3.AddFirst("Gekon");
list3.AddFirst("Antilopa");
list3.AddLast("Bizon");
list3.AddLast("Cvrček");
foreach (string l in list3)
{
    Console.WriteLine(l);
}
// SortedList<string,string>
Console.WriteLine("--- SortedList");
SortedList<string, string> dict2 = new SortedList<string, string> { { "Antilopa", "Antelope" }, { "Cvrček", "Cricket" }, { "Datel", "Woodpecker" }, { "Bizon", "Bison" } };
dict2.Add("Gekon", "Gecko");
foreach (KeyValuePair<string, string> item in dict2)
{
    Console.WriteLine(item.Key + "=" + item.Value);
}

// -- Negenerické
// ArrayList
Console.WriteLine("--- ArrayList");
ArrayList list4 = new ArrayList { "Antilopa", "Fenek", "Bizon", "Cvrček", "Datel", "Emu", 5, 5.7f };
list4.Add("Gekon");
foreach (var l in list4)
{
    // zde je nutné testovat typ objektu, nějak takto:
    if (l is string)
    {
        Console.WriteLine(l as string);
    }
}
// Hashtable - negenerický Dictionary
Console.WriteLine("--- Hashtable");
Hashtable dict3 = new Hashtable { { "Antilopa", "Antelope" }, { "Cvrček", "Cricket" }, { "Datel", 50 }, { "Bizon", "Bison" } };
dict3.Add("Gekon", "Gecko");
foreach (DictionaryEntry item in dict3)
{
    Console.WriteLine(item.Key + "=" + item.Value);
}
// Queue
Console.WriteLine("--- Queue");
Queue fronta2 = new Queue();
fronta2.Enqueue("Antilopa");
fronta2.Enqueue("Bizon");
fronta2.Enqueue("Cvrček");
while (fronta2.Count > 0)
{
    Console.WriteLine(fronta2.Dequeue());
}
// Stack
Console.WriteLine("--- Stack");
Stack stack2 = new Stack();
stack2.Push("Antilopa");
stack2.Push("Bizon");
stack2.Push("Cvrček");
while (stack2.Count > 0)
{
    Console.WriteLine(stack2.Pop());
}
Console.WriteLine();

// Fronta vs Zásobník
// FRONTA - First In, First Out (kdo přijde jako první, jako první odchází)
// - např. jako fronta na úřadě - FIFO,
// metody Enqueue (přijde), Dequeue (odchází), Peek
// https://upload.wikimedia.org/wikipedia/commons/thumb/5/52/Data_Queue.svg/1200px-Data_Queue.svg.png

// ZÁSOBNÍK - Last In, First Out (kdo přijde jako poslední, odchází jako první)
// - např. zásobník na vodu - LIFO,
// metody Push (vložení), Pop (odebrání), Peek
// https://cdn.programiz.com/sites/tutorial2program/files/stack.png

// Pole vs kolekce
// - pole obsahuje neměnný počet prvků, nedá se rozšiřovat, méně vestavěných metod
// - kolekce obsahuje proměnný počet prvků, dá se rozšiřovat/zmenšovat, má více vestavěných metod (+ např. rozšiřující - LINQ)

// Příklad generické třídy (generika - uvedení datového typu, typová bezpečnost)
DataStore<string> store = new DataStore<string>("beruska");
Console.WriteLine(store.Data);
Console.WriteLine();

//DataStore<string> store1 = new DataStore<string>(123); // nelze, parametr není string
DataStore<int> store2 = new DataStore<int>(12);
Console.WriteLine(Math.Pow(store2.Data, 2));