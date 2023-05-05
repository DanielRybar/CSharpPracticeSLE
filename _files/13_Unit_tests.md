## 13. Testování SW

### Chyba
* něco je špatně nebo nevyhovuje očekávaným standardům

### Sémantická chyba
* program dělá něco jiného než jsme zamýšleli
* může se projevit jen někdy
* nemusí být vidět na první pohled

### Syntaktická chyba
* prohřešek proti gramatice používaného programovacího jazyka, jsou odhaleny kompilátorem
* editor ve VS je odhalí bez kompilace

### Ladění aplikace (debugging)
* pomocí **breakpointů, logování, sledování výkonu**, ...

### Výjimka
* **pasivní** ošetření - **blok try-catch(-finally)**, pokud k výjimce dojde, tak ...
* **aktivní** ošetření - snažíme se vyhození výjimky **předejít** - hromady podmínek apod.

### Testování
* spouštíme program s nejrůznějšími (nepředpokládanými) testovacími vstupy a sledujeme, jak se s nimi vypořadá

### Jednotkové testy
* testování jednotlivých funkčních částí aplikace
* ověření správné funkcionality jednotky kódu (porovnání s očekávaným výstupem)

### Návod pro vytvoření testovacího projektu
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