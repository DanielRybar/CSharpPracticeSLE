using _05_06OOP;

Predchudce predchudce = new Predchudce();
predchudce.VypisPozdrav(); // normální metoda (Ahoj)
predchudce.VypisDen(); // viruální metoda (čtvrtek)

Predchudce predchudce1 = new Naslednik();
predchudce1.VypisPozdrav(); // volá se metoda z předka (Ahoj)
predchudce1.VypisDen(); // volá se vlastní překrytá metoda z následníka (pátek)

// k čemu je to dobré?
// například když máme pole zvířat, tak každý jednotlivý druh zvířete, který má implementovanou vlastní překrytou metodu udělá svůj zvuk

string op1 = predchudce * "sdgsezeuozuo"; // jméno předchůdce + řetězec
Console.WriteLine(op1);

Naslednik nasl = new();
string op2 = nasl * "oieiueiz"; // jméno následníka + řetězec + AAAA
Console.WriteLine(op2);

// abstraktní třída
// třída od které není možné vytvářet objekty. Taková třída slouží jako (společný) předek pro jiné třídy. 
// je většinou nedokončená (obsahuje základní atributy a metody)
// možnost implementace metod
// nelze od ní vytvořit instanci, dědičnost je v podstatě nutná

// rozhraní
// nelze plně implemetovat metody, ale pouze signatury (hlavičky) metod
// v C# je asi výhodnější, jelikož třída může být odvozena pouze z jedné třídy, ale může implementovat více rozhraní
// => V C# nelze dědit z více rodičovských tříd. Pomocí rozhraní se to řeší tak, že třída dědí z jediné třídy, ostatní vlastností implementuje pomocí rozhraní.
// Pokud spolu dvě třídy spolupracují, může si jedna vynutit existenci metod a vlastností, které ke své činnosti potřebuje ve svém protějšku.
// Třídu nelze zkompilovat, pokud neimplementuje rozhraní, která implementovat má.

// generalizace - zobecňování, v podstatě princip OOP
// jedna z vlastností algoritmu - obecnost - neřeší konkrétní problém, ale obecný problém
// např. ne kolik je 3*5, ale kolik je x*y

// specializace - zaměření se na konkrétní problém - v podstatě opak generalizace

//Je v C# nějaká implicitní přetížená metoda?
//Console.WriteLine(); // spíše proměnný počet parametrů
//.ToString()

// Jaký je hlavní rozdíl mezi strukturovaným a objektovým programováním?
// strukturované programování - program je postaven na procedurách, které jsou volány v určitém pořadí
// objektové programování - program je postaven na objektech, které jsou vytvářeny z tříd, které mají vlastnosti a metody
                        // atributy a metody jsou pospolu