using _01ZakladniProgramoveKonstrukce;

//Co se stane v případě, že:

//a) zapíšete hodnotu 32bit do 16bit
// - vyšších 16 bitů se zahodí

//b) float do int
// - odřízne se část za desetinnou čárkou, nezaokrouhluje se

//c) záporné číslo do proměnné pouze pro kladná čísla
// - cislo jakoby se odecetlo od nejvyssi mozne hodnoty kladneho cisla

//Jak velký je datový typ bool?
// - 1 bajt (8 bitů)

Console.WriteLine(sizeof(bool));

//Je datový typ string roven poli znaků (char)?
// - string je immutable - nejde modifikovat
// - char array - je mutable - lze modifikovat

//Patří struktury (struct) mezi kolekce?
// - struct je hodnotový datový typ - podobný třídě
// - kolekce jsou referenční datové typy - dynamická změna hodnot
// - => ne

//Je možné nahradit ternární operátor ?: pomocí if-else? (příklad)
// ano
int num = 15;
Console.WriteLine(num == 15 ? "Patnáctka" : "Nepatnáctka");
if (num == 15)
{
    Console.WriteLine("Patnáctka");
}
else
{
    Console.WriteLine("Nepatnáctka");
}

//Kdy lze použít operátor, (čárka)? (příklad)
// - vícenásobná deklarace
int a = 1, b = 2;
// - inicializace pole
int[] array1Da = new int[] { 1, 2, 3, 4, 5 };
// - vícerozměrné pole
int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
// - oddělování parametrů
Console.WriteLine("Hello", "World");

//Pokud bude mít proměnná index stejnou hodnotu, budou tyto 2 příkazy pracovat se stejným prvkem pole?
//pole[++index] a pole[index--]
// preincrement ++a - zvysi pak vrati zvysenou
// postincrement a++ - vrati pak zvysi
// ++index nejdriv pricte a az potom cte, zatimco index-- cte a az potom odecita
// => ne

//Napište stejný cyklus pomocí while, do-while, for a for-each.
char[] charArr = new char[] { 'a', 'b', 'c', 'd', 'e' };

// while
Console.WriteLine("while");
int i = 0;
while (i < charArr.Length)
{
    Console.WriteLine(charArr[i]);
    i++;
}

// do-while
// - provede se vždycky, musí se testovat, jestli je pole.Length > 0
Console.WriteLine("do-while");
int j = 0;
if (charArr.Length > 0)
{
    do
    {
        Console.WriteLine(charArr[j]);
        j++;
    } while (j < charArr.Length);
}

// for
Console.WriteLine("for");
for (int x = 0; x < charArr.Length; x++)
{
    Console.WriteLine(charArr[x]);
}

// foreach
Console.WriteLine("foreach");
foreach (char c in charArr)
{
    Console.WriteLine(c);
}


//Napište část kódu reprezentující rozdíl mezi hodnotovým a referenčním datovým typem.
MyStruct myStruct = new MyStruct(); // hodnotovy datovy typ
myStruct.MyInt = 1;
MyClass myClass = new MyClass(); // referencni datovy typ
myClass.MyInt = 1;

MyStruct myStruct2 = myStruct; // jelikoz je myStruct hodnotovy datovy typ, tak se vytvori skutecna nova kopie
myStruct2.MyInt = 2; // hodnota se tedy zmeni jen u myStruct2
MyClass myClass2 = myClass; // myClass2 ukazuje na stejne misto v pameti jako myClass
myClass2.MyInt = 2; // hodnota se zmeni i u myClass

Console.WriteLine(myStruct.MyInt); // 1
Console.WriteLine(myStruct2.MyInt); // 2

Console.WriteLine(myClass.MyInt); // 2
Console.WriteLine(myClass2.MyInt); // 2