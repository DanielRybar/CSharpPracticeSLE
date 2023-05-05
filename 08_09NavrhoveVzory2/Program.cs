using _08_09NavrhoveVzory2;

// iterator
List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
foreach (int item in list)
{
    Console.WriteLine(item);
}
// pouziti enumeratoru
IEnumerator<int> enumerator = list.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.WriteLine(enumerator.Current);
}


// proxy
IImage image = new ImageProxy("test.jpg"); // skutecny obrazek zatim nemam

// skutečný obrázek se načte až při prvním zobrazení, naplní se proměnná _realImage
image.Display();

// ...

// použije se načtení z proměnné _realImage
image.Display();


// stav
var lightSwitch = new LightSwitch();
lightSwitch.SwitchOn();
lightSwitch.SwitchOn();
lightSwitch.SwitchOff();
lightSwitch.SwitchOff();

// výstup
//Switching light on
//Light is already on
//Switching light off
//Light is already off


// adapter
var jsonSource = new JsonAnimalSource();
var animalAdapter = new JsonAnimalAdapter(jsonSource);

animalAdapter.ProcessAnimalData("some data");