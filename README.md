# Témata PRG - příprava

## <s>1. Základní programové konstrukce</s>
## <s>2. Algoritmus, algoritmická složitost</s>
## <s>3. Strukturované datové typy</s>
## <s>4. Spojové struktury</s>
## <s>5. a 6. OOP</s>
## <s>7. Podprogramy</s>

## 8. a 9. Návrhové vzory
* **zrychlují** návrh (řešení se nevymýšlí, ale jen použije)
* **zkvalitňují** návrh
* **zjednodušují a zpřesňují komunikaci** mezi členy týmu
* jejich znalost patří k **povinné výbavě** současného OO programátora

#### Tovární metoda
*	statická metoda nahrazující konstruktor
*	potřebujeme vracet instance různých typů
```csharp
public static Osoba GetInstance(int vek, int pohlavi, string jmeno) // tovární metoda
{
    if (vek < 0) throw new NullReferenceException("Nulova reference.");
    else if (vek >= 0 && vek <= 7) return Predskolak.GetInstance(vek, pohlavi, jmeno);
    else if (vek >= 8 && vek <= 19) return Skolak.GetInstance(vek, pohlavi, jmeno);
    else if (vek >= 20 && vek <= 65) return Pracujici.GetInstance(vek, pohlavi, jmeno);
    else return new Duchodce(vek, pohlavi, jmeno);
}

```

#### Přepravka (Crate, Transport object, Messenger)
* sloučení několika samostatných informací do jednoho objektu
```csharp
Pozice pozice = new Pozice(120, 30, 80);

class Pozice
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Pozice(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}

```

#### Služebník (Servant)
*	když je potřeba definovat společnou funkcionalitu pro více tříd současně
*	**tyto třídy musí implementovat stejné rozhraní, které je vstupním parametrem v metodách služebníka**

#### Prázdný objekt (null object)
* místo vrácení prázdného nulového ukazatele vrátíme prázdný objekt
* např. žádná barva, žádný směr apod.

### NV řešící počet instancí
* je nutný soukromý konstruktor

#### Knihovní třída (Library class, Utility)
*	opakovaně použitelná
*	soubor statických metod - např. matematické funkce
*	v C# jsou součástí standardní knihovny třídy pro práci s řetězci, kolekcemi, soubory, síťovými operacemi, UI prvky atd.

#### Jedináček (singleton)
*	třída bude mít maximálně jednu instanci
*	odkaz na instanci uložen ve statické proměnné
```csharp
private static Predskolak predskolak;

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
```

#### Výčtový typ
* definice předem známých hodnot a typová kontrola
```csharp
public enum Pohlavi // NV výčtový typ
{
    Muz = 0,
    Zena = 1,
    Jine = 2
}
```

#### Originál
* zabezpečení, že od každé hodnoty bude existovat pouze jedna instance
```csharp
private static readonly List<Pracujici> _pracujici = new();

public static new Pracujici GetInstance(int vek, int pohlavi, string jmeno) // originál
{
    // existuje uz nejaky takovy clovek?
    var existence = _pracujici.Where(x => x.Jmeno == jmeno && x.Vek == vek && (int)x.Pohlavi == pohlavi).FirstOrDefault();
    if (existence == null) // pokud ne
    {
        _pracujici.Add(new Pracujici(vek, pohlavi, jmeno)); // tak ho pridej
        return _pracujici[^1]; // a vrat ho
    }

    return existence; // jinak vrat uz existujici instanci z kolekce
}
```

#### Bazén (fond, pool)
* omezení počtu vytvářených instancí
* "znovuoživení" dříve použitých instancí
```csharp
private const int POCET_INSTANCI = 4;
private static readonly List<Skolak> _skolaci = new();

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
```

#### Muší váha (flyweight)
* šetří paměť při úkolech, pro které potřebujeme vytvořit velký počet instancí
* objekt rozdělen na dvě části - vnitřní/vnější stav
* př1. textový editor - každý znak v dokumentu není představován samostatným objektem, ale všechny shodné znaky zastupuje představitel daného znaku
* př2. jednotky v RTS hrách

### NV pro skrývání implementace

#### Zástupce (proxy)
* umožňuje řídit přístup k celému/částečnému rozhraní objektu přes jiný zastupující objekt

##### Vzdálený zástupce (Remote proxy)
* zastupuje objekt umístěný někde jinde
* zařizuje (serverovou) komunikaci se vzdáleným objektem
* měl by být připraven i na selhání spojení (vyhodit odpovídající výjimku)

##### Virtuální zástupce (Virtual proxy)
* také zastupuje jiný objekt
* vytvoření objektu se nechává na poslední chvíli (objekt ani být vytvořen nemusí) a chování objektu se předstírá
* použití: lazy loading obrázků/dat z databáze

##### Ochranný zástupce (Protection proxy)
* zakrývá identitu zastupovaného objektu
* nabízí jen podmnožinu metod zastupovaného objektu, lze implementovat kontrolu přístupových práv
* implementace skrytím za rozhraní nebo za proxy třídu spravující instanci objektu

#### Chytrý odkaz (Smart reference)
* NV spadající pod Zástupce
* doplnění komunikace s objektem o další akce, typicky kvůli zrychlení a zefektivnění aplikace
* virtuální zástupce je také chytrý odkaz – rozhoduje, kdy přistoupí k originálnímu objektu a kdy načte hodnoty z cache / metadata

#### Příkaz (command)
* objekt je použit k zapouzdření všech informací potřebných ke zpožděnému spuštění události
* použití ve WPF/MAUI - viz otázka 11

#### Iterátor
* též **Enumerator**
* samostatný objekt umožňující lineární procházení kolekcemi bez znalosti jejich vnitřní implementace
* v C# foreach = implicitní iterátor

#### Stav (state)
* podobá se NV **konečný automat** (finite-state machine)
   * objekt má konečný počet definovaných stavů a vždy se může nacházet pouze v jednom z nich
   * zároveň má určeno, kdy a na základě jakých vstupů má přepínat mezi jednotlivými stavy
* na rozdíl od konečného automatu jsou stavy více decentralizované = znovupoužitelnost, ale horší optimalizace

#### Šablonová metoda
* umožňuje podtřídám měnit části algoritmu beze změny samotného algoritmu
* umožňuje definovat metody, jejichž chování je definováno jen částečně; tyto části chování definují až potomci
* používá se při řešení typických úloh, jejichž přesné parametry budou známy až za běhu
* použití
   * když chceme, aby se naše aplikace dala rozšířit, ale ne modifikovat
   * když se nám v kódu objevují podobné algoritmy (lišicí se jen v pár krocích, kostra je stejná)

### NV pro optimalizaci rozhraní

#### Fasáda
* zjednodušuje komunikaci mezi uživatelem a systémem
* vytvoření jednotného rozhraní pro celou logickou skupinu tříd, které se tak sdruží do subsystému
* zabalí komplikovaný subsystém do jednoduššího uceleného rozhraní

#### Adaptér
* převede zastaralé / nehodící se / chybné rozhraní třídy na rozhraní, které klient očekává
* zabezpečuje spolupráci tříd a usnadňuje implementaci nových
* může celou třídu zabalit do nové (object adapter), nebo z ní dědit (class adapter)

#### Strom (Composite)
* doporučené řešení situace, kdy se pracuje se stromovou strukturou, např. rekurzivně zanořené navigační menu
* jednoduché a z nich složené (kompozitní) objekty – lze k nim přistupovat jednotným způsobem, implementují stejné rozhraní
* (funkce použitá na kontejner by se měla aplikovat na všechny prvky v něm)

## 10. Paralelní programování
* dva hlavní důvody – výkon (urychlení nějakého výpočtu) a responzivita (jeden výpočet nepozastaví celou aplikaci/nezasekne se UI)
* musí se to vyplatit - tzn. že náklady na režii nesmí být větší než při použití normálního PRG

#### Vlákno (Thread)
* aplikace běží ve vlákně = proces
* v případě nutnosti je možné vytvořit další vlákno, delegovat do něj nějakou činnost a (ne)počkat až skončí
* hlavní vlákno aplikace je stále „živé“, není blokované náročným výpočtem
* je možné rozdělit složitou úlohu na více jader procesoru = zrychlení
* každé vlákno má vlastní zásobník (stack)
* zjednodušení úlohy (např. Apache)

Nízkoúrovňové řízení
```csharp
// System.Threading
Thread threadOne = new Thread(new ThreadStart(() => { /* metoda */}));
threadOne.Start(); // spuštení

threadOne.Join(); // čekání na dokončení vlákna a jeho spojení s hlavním vláknem
threadOne.Abort(); // zabití vlákna (vyhodí ve vlákně výjimku ThreadAbortException)

threadOne.IsBackground = true; // vlákno skončí společně s hlavním
```

#### Task (úloha/úkol)
* třída reprezentující asynchronní operaci
* v JavaScriptu je to Promise
* vyšší úroveň abstrakce než Thread, vnitřně implementuje třídu ThreadPool
```csharp
Task task = new Task(() => { }); // vytvoření úlohy
task.Start(); // spuštění úlohy
Task.Run(() => { }); // vytvoří a spustí úlohu
Task.Factory.StartNew(() => { }); // vytvoří a spustí úlohu
Task.WaitAll(task); // čeká na dokončení úloh(y), blokuje aktuální vlákno
Parallel.Invoke(() => { }, () => { }); // vytvoří a spustí úlohy paralelně, čeká na jejich dokončení
Task.WhenAll(task); // vrátí Task, který se dokončí až po dokončení všech úloh
```

#### Parallel.For
* paralelní iterace
```csharp
Parallel.For(0, 10, i => { });
Parallel.ForEach(new int[] { 1, 2, 3 }, i => { });
```

#### Synchronizace vláken
* **synchronizace vláken** – koordinovaný přístup ke sdíleným prostředkům
* při zpracování dat vláknem by k těmto datům neměla mít ostatní vlákna přístup
* problém nastává, když vlákno s daty provádí neatomickou operaci a jiné vlákno začne s těmito daty také pracovat
* (data ještě nejsou plně zpracovaná a připravená k další akci)

#### Zámek (lock)
* zámek je objekt, který umožňuje synchronizaci vláken
* **lock()** uzamyká kus kódu objektem, který dostane jako vstupní parametr
* v tomto kusu kódu může být pouze jedno vlákno, ostatní čekají
* vstupním parametrem je kód uzamčen, ale samotný parametr nijak uzamčen/chráněn/modifikován není, může to být libovolný objekt
```csharp
object baton = new object();
void Method()
{
    var id = Environment.CurrentManagedThreadId;
    Console.WriteLine(id + " se snaží dostat do chráněné sekce");
    lock (baton)
    {
        Console.WriteLine(id + " se nachází ve chráněné sekci");
        Thread.Sleep(10);
        Console.WriteLine(id + " opouští chráněnou sekci");
    }
    Thread.Sleep(10);
    Console.WriteLine(id + " je na konci metody");
}

for (int i = 0; i < 3; i++) new Thread(Method).Start();
```

Lock je syntaktický cukr pro Monitor.Enter a Monitor.Exit
```csharp
Monitor.Enter(baton);
try
{
    // Chráněná sekce
}
finally
{
    Monitor.Exit(baton);
}
```

#### Async, await
* klíčová slova pro psaní asynchronního kódu
* využití: při práci s databází, sítí, soubory, ...

## 11. Architektury .NET
* WPF - bindování, viewmodel, obecně předvést architekturu MVVM

Command - obecný kód, implementuje ICommand
```csharp
public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged; // udalost, ktera se spusti, pokud se zmeni stav, kdy se muze command spustit

    private Action _execute;
    private Func<bool> _canExecute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) // muze se spustit? (kdyz ne, tlacitko je zablokovane)
    {
        return _canExecute == null
                ? true // pokud ho v commandu nezadame, tak je povoleno vždy
                : _canExecute(); // jinak se spusti funkce, ktera nam vrati true/false
    }

    public void Execute(object? parameter) // spusti se pri stisku tlacitka
    {
        _execute();
    }

    public void RaiseCanExecuteChanged() // zavola se, pokud se zmeni stav, kdy se muze command spustit
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        // invoke znamena
        // if (CanExecuteChanged != null)
        // {
        //     CanExecuteChanged(this, EventArgs.Empty);
        // }

    }
}
```

## 12. Verzovací systémy
* https://www.freecodecamp.org/news/10-important-git-commands-that-every-developer-should-know/
* git clone <REPOSITORY_URL>
* git branch <branch-name>
* git push -u <remote> <branch-name>
* git checkout <name-of-your-branch>
* git status
* git add <file>
* git commit -m "commit message"
* git push <remote> <branch-name>
* git pull <remote>
* git revert 3321844
* git merge <branch-name>

## 13. Testování SW
* máme projekt, který chceme testovat - v tomto případě kalkulačka pro kvadratickou rovnici
* do stejného solution přidáme nový projekt pro testování - MSTest Test Project
* nyní je nutné do nového testovacího projektu přidat referenci na testovaný projekt (v kontextovém menu pravé tlačítko - Add - Project Reference)
* spuštění testů - Test/Run All Tests

Anotace
```csharp
[TestClass] // nad testovací třídu
[TestInitialize] // zavolá se před každým testem
[TestCleanup] // zavolá se po každém testu
[TestMethod] // reprezentuje jeden test
```

Příklad - pomocí Assert testujeme očekávané chování
```csharp
private QuadraticEquation _eq;

[TestInitialize] // zavolá se před každým testem
public void Initialize()
{
    _eq = new QuadraticEquation(1, 2, 3); // nastavim koeficienty na a=1,b=2,c=3
}

[TestMethod]
[ExpectedException(typeof(QuadraticCoefficientException))] // očekávaná výjimka
public void TestRootCount()
{
    Assert.AreEqual(0, _eq.RootCount); // testuji zda počet kořenů je opravdu 0
    _eq.SetParameters(-5, 6, 7); // nastavuji parametry
    Assert.AreEqual(2, _eq.RootCount); // mají nové parametry 2 kořeny?
    _eq.SetParameters(-7, -79, 16);
    Assert.AreEqual(2, _eq.RootCount);

    _eq.SetParameters(0, 5, 5); // nyní nastavím kvadratický člen na 0
    double[] roots = _eq.Roots(); // metoda .Roots() by měla vyhodit výjimku, protože kvadratický člen (a) je nulový
    
    // pokud se očekávané hodnoty rovnají výpočtům a opravdu se vyhodí očekávaná výjimka, pak testy proběhly úspěšně
}
```