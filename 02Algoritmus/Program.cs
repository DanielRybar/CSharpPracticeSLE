//1) Uveďte libovolný algoritmus pro řazení celých čísel v poli s určením operační a paměťové složitosti (C#).
//Na uvedeném algoritmu vysvětlete vlastnosti algoritmu.

// SelectionSort
// operační složitost v nejhorším, nejlepším a průměrném případě: - kvadratická O(n^2) - protože pro každý prvek projdeme list znovu
// paměťová složitost - je konstantní O(1)
// popis a vlastnosti algoritmu:
//  - algoritmus vezme prvek s nejmenší hodnotou a zamění ho s prvkem na první pozici
//  - je efektivnější a rychlejší než Bubble Sort
//  - obsahuje 2 cykly, první cyklus prochází prvky, druhý cyklus hledá minimum a následně se dá minimum na začátek kolekce (viz prezentace)
//  - elementárnost - má konečný počet srozumitelných kroků
//  - konečnost - má konečný počet kroků
//  - je obecný - neřeší konkrétní, ale obecný problém
//  - determinovanost - za stejných podmínek pro stejné vstupy poskytuje stejný výstup
//  - výstup - poskytuje výstup
int[] pole = new int[10] { 50, 4, 3, 9, 1054, 3986, 0, -99, 2, 47 }; // pole deseti neseřazených čísel
int minIndex;
int temp;
// pro každý prvek
for (int i = 0; i < pole.Length; i++)
{
    // najít minimum (od aktuálního prvku do konce)
    minIndex = i;
    for (int j = i; j < pole.Length; j++)
    {
        if (pole[j] < pole[minIndex])
        {
            minIndex = j;
        }
    }
    // dát minimum na začátek (prohodit minimum za aktuální prvek)
    temp = pole[minIndex];
    pole[minIndex] = pole[i];
    pole[i] = temp;
}
foreach (int item in pole)
{
    Console.WriteLine(item);
}
Console.WriteLine("---");

// BubbleSort
// operační složitost v nejhorším, nejlepším a průměrném případě: - kvadratická O(n^2) - protože pro každý prvek projdeme list znovu
// paměťová složitost - je konstantní O(1)
// popis a vlastnosti algoritmu:
//  - algoritmus porovnává dva sousední prvky a pokud je první větší, tak je prohodí
//  - je efektivnější a rychlejší než Insertion Sort
//  - obsahuje 2 cykly, první cyklus prochází prvky, druhý cyklus prochází prvky a porovnává je
//  - elementárnost - má konečný počet srozumitelných kroků
//  - konečnost - má konečný počet kroků
//  - je obecný - neřeší konkrétní, ale obecný problém
//  - determinovanost - za stejných podmínek pro stejné vstupy poskytuje stejný výstup
//  - výstup - poskytuje výstup
int[] pole2 = new int[10] { 50, 4, 3, 9, 1054, 3986, 0, -99, 2, 47 }; // pole deseti neseřazených čísel
int temp2;
// pro každý prvek
for (int i = 0; i < pole2.Length; i++)
{
    // pro každý prvek
    for (int j = 0; j < pole2.Length - 1; j++)
    {
        // porovnat dva sousední prvky
        if (pole2[j] > pole2[j + 1])
        {
            // prohodit je
            temp2 = pole2[j];
            pole2[j] = pole2[j + 1];
            pole2[j + 1] = temp2;
        }
    }
}
foreach (int item in pole2)
{
    Console.WriteLine(item);
}
Console.WriteLine("---");


//2) Jakou vlastnost popisuje u řadícího algoritmu stabilita?
// Řadicí algoritmus je stabilní tehdy, jestliže po seřazení zachovává vzájemné pořadí prvků se stejným klíčem.
// př. řazení jmen a příjmení
// Mějme seznam jmen a příjmení reprezentovaný uspořádanou dvojicí (A,B), kde A je jméno a B je příjmení.
// Seznam vypadá takto: (a,z),(b,x),(b,y)
// Po seřazení stabilním algoritmem bude výsledek vždy vypadat takto: (a,z), (b,x), (b,y)
// Pokud by byl použit nestabilní řadící algoritmus, výsledek by mohl vypadat takto: (a,z), (b,y), (b,x)
// Mezi stabilní řadicí algoritmy patří kupř. bubble sort.


//3) Rekurzivní řešení Fibonacciho posloupnosti je tento algoritmus neefektivní. Uveďte důvod.
// protože se při každém rekurzivním volání funkce zvyšuje hloubka jejího zanoření
// rekurze se "překrývá" - vypočítáme stejnou hodnotu několikrát, abychom se dostali na následující hodnotu
// př. F(5) = F(4) + F(3) = F(3) + F(2) + F(3) = F(2) + F(1) + F(2) + F(3) = F(2) + F(1) + F(2) + F(2) + F(2) + F(1)
static int Fibonacci(int cislo)
{
    if (cislo == 0) return 0;
    if (cislo == 1) return 1;
    return Fibonacci(cislo - 1) + Fibonacci(cislo - 2);
}
Console.WriteLine(Fibonacci(20));
Console.WriteLine("---");


//4) Jaký algoritmus používá třída Random v C# pro generování náhodných čísel?
// - substraktivní generátor podle Knutha
// - jako seed používá hodiny - DateTime.Now.Ticks
// zvolená čísla nejsou zcela náhodná, protože k jejich výběru se používá matematický algoritmus, ale jsou dostatečně náhodná pro praktické účely.
// TickCount se se mění každých 10-16 ms, takže pokud vytvoříte novou instanci v krátkém období, skončíte se stejnou číselnou řadou.
// NE:
//int a = new Random().Next();
//int b = new Random().Next();
//int c = new Random().Next();
// ANO:
//int a = rand.Next();
//int b = rand.Next();
//int c = rand.Next();


//5) Jaký algoritmus používá medoda Sort() u kolekcí v C#?
//- může použít 3 různé varianty v závislosti na tom, kolik ještě zbývá dořadit prvků
//- Insertion sort kolekce <= 16 prvků
//- Heap sort - pokud počet oddílů překročí 2 log *velikost pole*, použije se Heap sort
//- Quick sort
//- TYTO TŘI ALGORITMY SE POUŽÍVAJÍ NAJEDNOU


//6) Algoritmus pro vyhledání prvku v poli/kolekci má lineární složitost. Bylo by možné složitost vylepšit v případě, že by posloupnost byla seřazená. Uveďte způsob řešení a odvoďte jeho složitost. 
int[] poleCisel = new int[] { 50, 4, 3, 9, 1054, 3986, 0, -99, 2, 47 };

// sekvencni vyhledavani (slozitost linearni O(n))
int sekvencniVyhledavani(int[] pole, int x)
{
    for (int i = 0; i < pole.Length; i++)
    {
        if (pole[i] == x)
            return i; // vraci index, pokud jsme hledany prvek nalezli
    }
    return -1; // pri neuspechu vracime -1
}
Console.WriteLine(sekvencniVyhledavani(poleCisel, 1054));
Console.WriteLine("---");

Array.Sort(poleCisel); // seradime pole //-99,0,2,3,4,9,47,50,1054,3986

// vyhledavani pulenim intervalu (slozitost logaritmicka O(log n))
int vyhledavaniPulenimIntervalu(int[] pole, int x)
{
    int min = 0;
    int max = pole.Length - 1;
    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (x == pole[mid])
        {
            return mid++; // vraci index, pokud jsme hledany prvek nalezli
        }
        else if (x < pole[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }
    return -1; // pri neuspechu vracime -1
}
Console.WriteLine(vyhledavaniPulenimIntervalu(poleCisel, 1054));