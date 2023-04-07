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
