using _13TestovaniSW;

QuadraticEquation eq = new QuadraticEquation(a: 2, b: -11, c: 14);
Console.WriteLine(eq);
Console.WriteLine("Diskriminant D = " + eq.GetDiscriminant());
Console.WriteLine("Počet kořenů: " + eq.RootCount);
if (eq.RootCount > 0)
{
    Console.WriteLine("Kořeny: [" + string.Join(", ", eq.Roots()) + "]");
    Console.WriteLine("Vrchol: [" + string.Join(", ", eq.Vertex) + "]");
    Console.WriteLine("Pro x = 5: y = " + eq.Value(5));
}

Console.WriteLine("-----------------");
eq.SetParameters(a: 1, b: 3, c: 7);
Console.WriteLine(eq);
Console.WriteLine("Diskriminant D = " + eq.GetDiscriminant());
Console.WriteLine("Počet kořenů: " + eq.RootCount);
if (eq.RootCount > 0)
{
    Console.WriteLine("Kořeny: [" + string.Join(", ", eq.Roots()) + "]");
    Console.WriteLine("Vrchol: [" + string.Join(", ", eq.Vertex) + "]");
    Console.WriteLine("Pro x = 5: y = " + eq.Value(5));
}


// pro testování přidat nový projekt - MSTest Test Project