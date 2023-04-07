# Témata PRG - příprava

### <s>1. Základní programové konstrukce</s>
### <s>2. Algoritmus, algoritmická složitost</s>
### <s>3. Strukturované datové typy</s>
### <s>4. Spojové struktury</s>
### <s>5. a 6. OOP</s>
### <s>7. Podprogramy</s>

### 8. a 9. Návrhové vzory
* zrychlují návrh (řešení se nevymýšlí, ale jen použije)
*	zkvalitňují návrh
*	zjednodušují a zpřesňují komunikaci mezi členy týmu
*	jejich znalost patří k povinné výbavě současného OO programátora

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
* př. textový editor - každý znak v dokumentu není představován samostatným objektem, ale všechny shodné znaky zastupuje představitel daného znaku
* vnitřní/vnější stav

### NV pro skrývání implementace

#### Zástupce (proxy)
#### Příkaz (command)
#### Iterátor
#### Stav (state)
#### Šablonová metoda

### NV pro optimalizaci rozhraní

#### Fasáda
#### Adaptér
#### Strom (Composite)

### <s>10. Paralelní programování (viz kód)</s>

### 11. Architektury .NET
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

### 12. Verzovací systémy
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

### 13. Testování SW
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