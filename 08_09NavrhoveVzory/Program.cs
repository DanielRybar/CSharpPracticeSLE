using _08_09NavrhoveVzory.Models;

// 1
/*
int vek = 5;
int pohlavi = 0;
string jmeno = "Michal";
Osoba osoba = Osoba.GetInstance(vek, pohlavi, jmeno);
Console.WriteLine(osoba.ToString());
Osoba osoba2 = Osoba.GetInstance(6, 2, "aaa");
Console.WriteLine(osoba2.ToString());
*/

// 2
int vek = 15;
int pohlavi = 1;
string jmeno = "Marfuša";

Osoba osoba = Osoba.GetInstance(vek, pohlavi, jmeno);
Console.WriteLine(osoba.ToString());

Osoba osoba2 = Osoba.GetInstance(vek, pohlavi, "Anna");
Console.WriteLine(osoba2.ToString());

Osoba osoba3 = Osoba.GetInstance(vek, pohlavi, "Monika");
Console.WriteLine(osoba3.ToString());

Osoba osoba4 = Osoba.GetInstance(vek, pohlavi, "Lenka");
Console.WriteLine(osoba4.ToString());

Skolak.ReleaseInstance(osoba4); // uvolneni instance

Osoba osoba5 = Osoba.GetInstance(vek, pohlavi, "Cyril");
Console.WriteLine(osoba5.ToString());


Console.ReadKey();