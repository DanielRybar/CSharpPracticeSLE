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

// Bez specifikování delegáta se kompilátor rozhodne na základně signatury metody:
/*
Thread ta = new Thread(MethodA); // Implicitně přetypováno na ThreadStart
ta.Start();
Thread tb = new Thread(MethodB); // Implicitně přetypováno na ParametrizedThreadStart
tb.Start("foo");
*/

// Task
// třída reprezentující asynchronní operaci, v Reactu je to Promise
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
// Vstupním parametrem je kód uzamčen ale samotný parametr nijak uzamčen/chráněn/modifikován není, může to být libovolný object
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

//for (int i = 0; i < 3; i++) new Thread(Method).Start();

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


// Ukázka kódu
// chceme sečíst všechna čísla v poli
int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// normální cesta
long sum = 0;
foreach (var number in numbers)
{
    sum += number;
}
Console.WriteLine("Normální cesta: " + sum);


// ....................................................


// pomocí Thread
int CPUs;
int portionSize;
long[] sumPortions;

CPUs = Environment.ProcessorCount; // Vrací počet logických procesorů, které mohou být využity CLR
portionSize = numbers.Length / CPUs; // Rozdělení pole pro jednotlivá vlákna
sumPortions = new long[CPUs]; // Pole pro (mezi)výsledky
long sum2 = 0;

// Vytvoření pole vláken a jejich spuštění
Thread[] threads = new Thread[CPUs];
for (int i = 0; i < CPUs; i++)
{
    threads[i] = new Thread(SumPortion);
    threads[i].Start(i);
}
// Počkat, až všechna vlákna skončí
// .Join() blokuje volající vlákno, dokud dané vlákno neskončí
for (int i = 0; i < CPUs; i++) threads[i].Join();
// Sečíst (mezi)výsledky jednotlivých vláken
for (int i = 0; i < CPUs; i++) sum2 += sumPortions[i];

void SumPortion(object _portionNumber)
{
    int portionNumber = (int)_portionNumber; // Explicitní přetypování
    var start = portionSize * portionNumber;
    var end = (portionNumber == CPUs - 1) ? (numbers.Length) : (portionSize * portionNumber + portionSize);
    // $"Vlákno {Environment.CurrentManagedThreadId}" pracuje od {start} do {end - 1}
    long sum = 0;
    for (int i = start; i < end; i++) sum += numbers[i];
    sumPortions[portionNumber] = sum;
}

Console.WriteLine("Thread cesta: " + sum2);


// ....................................................


// pomocí Task
CPUs = Environment.ProcessorCount;
portionSize = numbers.Length / CPUs;
sumPortions = new long[CPUs];
long sum3 = 0;

Task[] tasks = new Task[CPUs];
for (int i = 0; i < CPUs; i++)
{
    var tid = i; // Pro jistotu
    tasks[tid] = Task.Run(() =>
    {

        var start = portionSize * tid;
        var end = (tid == CPUs - 1) ? (numbers.Length) : (portionSize * tid + portionSize);

        long sum = 0;
        for (int j = start; j < end; j++) sum += numbers[j];
        sumPortions[tid] = sum;

    });
}

Task.WaitAll(tasks); // Počká, až se dokončí všechny Tasky v poli

for (int i = 0; i < CPUs; i++) sum3 += sumPortions[i]; // Sečíst (mezi)výsledky

Console.WriteLine("Task cesta: " + sum3);


// ....................................................


// pomocí Parallel.For
sum = 0;
Parallel.For(0, CPUs, (i) =>
{

    var tid = i;
    var start = portionSize * tid;
    var end = (tid == CPUs - 1) ? (numbers.Length) : (portionSize * tid + portionSize);

    long sum = 0;
    for (int j = start; j < end; j++) sum += numbers[j];
    sumPortions[tid] = sum;

});

for (int i = 0; i < CPUs; i++) sum += sumPortions[i];

Console.WriteLine("Parallel for: " + sum);