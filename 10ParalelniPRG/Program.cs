using System.Diagnostics;

int pocetLogickychJader = System.Environment.ProcessorCount;
Console.WriteLine("Logická jádra: " + pocetLogickychJader);

// Proč používat paralelní PRG?
// Dva hlavní důvody – výkon (urychlení nějakého výpočtu) a responzivita (jeden výpočet nepozastaví celou aplikaci/nezasekne se UI)
// musí se to vyplatit - tzn. že náklady na režii nesmí být větší než při použití normálního PRG

// Thread
// reprezentuje vlákno (tok)
// aplikace může běžet ve více paralelních vláknech
// každé vlákno má vlastní zásobník (stack)
// Thread .Sleep(), .Start(), .Abort(), .Join(), .Priority, ...

// vytvoření vlákna
static void MethodA() { }
static void MethodB(object obj) { }

// Pro použití ThreadStart musí metoda vracet void a být bez parametrů
Thread ta = new Thread(new ThreadStart(MethodA));
ta.Start();
// Pro použití ParametrizedThreadStart musí metoda vracet void a mít jeden parametr typu object
// ten se pak nastavuje ve .Start()
Thread tb = new Thread(new ParameterizedThreadStart(MethodB));
tb.Start("foo");

// Bez specifikování delegáta se kompilátor rozhodne na základě signatury metody:
/*
Thread ta = new Thread(MethodA); // Implicitně přetypováno na ThreadStart
ta.Start();
Thread tb = new Thread(MethodB); // Implicitně přetypováno na ParametrizedThreadStart
tb.Start("foo");
*/

// Task
// třída reprezentující asynchronní operaci
// v Reactu je to Promise
// vyšší úroveň abstrakce než Thread, vnitřně implementuje třídu ThreadPool
Task task = new Task(() => { }); // vytvoření úlohy
task.Start(); // spuštění úlohy
Task.Run(() => { }); // vytvoří a spustí úlohu
Task.Factory.StartNew(() => { }); // vytvoří a spustí úlohu
Task.WaitAll(task); // čeká na dokončení úloh(y), blokuje aktuální vlákno
Parallel.Invoke(() => { }, () => { }); // vytvoří a spustí úlohy paralelně, čeká na jejich dokončení
Task.WhenAll(task); // vrátí Task, který se dokončí až po dokončení všech úloh

// Parallel.For
// paralelní iterace
Parallel.For(0, 10, i => { });
Parallel.ForEach(new int[] { 1, 2, 3 }, i => { });

// Synchronizace vláken
// Synchronizace vláken – koordinovaný přístup ke sdíleným prostředkům
// Při zpracování dat vláknem by k těmto datům neměla mít ostatní vlákna přístup
// Problém nastává, když vlákno s daty provádí neatomickou operaci a jiné vlákno začne s těmito daty také pracovat
// (data ještě nejsou plně zpracovaná a připravená k další akci)

// Zámek
// Zámek je objekt, který umožňuje synchronizaci vláken
// lock() uzamyká kus kódu objektem, který dostane jako vstupní parametr
// V tomto kusu kódu může být pouze jedno vlákno, ostatní čekají
// Vstupním parametrem je kód uzamčen, ale samotný parametr nijak uzamčen/chráněn/modifikován není, může to být libovolný objekt
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

// for (int i = 0; i < 3; i++) new Thread(Method).Start();

/* Výstup může vypadat:
12 se snaží dostat do chráněné sekce
12 se nachází ve chráněné sekci
13 se snaží dostat do chráněné sekce
14 se snaží dostat do chráněné sekce
12 opouští chráněnou sekci
13 se nachází ve chráněné sekci
13 opouští chráněnou sekci
12 je na konci metody
14 se nachází ve chráněné sekci
13 je na konci metody
14 opouští chráněnou sekci
14 je na konci metody
*/

// lock je syntaktický cukr pro Monitor.Enter a Monitor.Exit
Monitor.Enter(baton);
try
{
    // Chráněná sekce
}
finally
{
    Monitor.Exit(baton);
}

// async, await
// async a await jsou klíčová slova, která umožňují psát asynchronní kód
// využití: při práci s databází, sítí, soubory, ...


// příklad
int[] pole = new int[10] { 50, 4, 3, 9, 1054, 3986, 0, -99, 2, 47 }; // pole deseti neseřazených čísel
int[] pole1 = new int[10] { 50, 4, 3, 9, 1054, 3986, 0, -99, 2, 47 }; // pole deseti neseřazených čísel

Stopwatch stopky = Stopwatch.StartNew();

BubbleSort(pole);
stopky.Stop();
Console.WriteLine("Normální čas: " + stopky.ElapsedMilliseconds);

stopky.Restart();

ParallelBubbleSort(pole1);
stopky.Stop();
Console.WriteLine("Paralelní čas: " + stopky.ElapsedMilliseconds); // trvá déle, kvůli režii

/*
// vytvoření a spuštění úlohy
Task task5 = new Task(() => BubbleSort(pole));
task5.Start();

// čekání na dokončení úlohy
task5.Wait();

// výpis seřazeného pole
foreach (int i in pole)
{
    Console.Write(i + " ");
}
*/

static void BubbleSort(int[] array)
{
    int n = array.Length;
    bool swapped;
    do
    {
        swapped = false;
        for (int i = 0; i < n - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                (array[i + 1], array[i]) = (array[i], array[i + 1]);
                swapped = true;
            }
        }
        n--;
    } while (swapped);
}

static void ParallelBubbleSort(int[] array)
{
    int n = array.Length;
    bool swapped;
    do
    {
        swapped = false;
        Parallel.For(0, n - 1, i => // paralelni iterace
        {
            if (array[i] > array[i + 1])
            {
                (array[i + 1], array[i]) = (array[i], array[i + 1]);
                swapped = true;
            }
        });
        n--;
    } while (swapped);
}