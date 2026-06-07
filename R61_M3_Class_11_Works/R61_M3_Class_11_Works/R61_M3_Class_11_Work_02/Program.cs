using R61_M3_Class_11_Work_02.Models;

Circle c = new Circle { Radius = 4.5 };
Console.WriteLine(c);
Console.WriteLine($"Area={c.Area()}");
Rectangle r = new Rectangle { Length = 7, Width = 5 };
Print(r);
Console.ReadLine();

static void Print(IShape s)
{
    Console.WriteLine(s);
    Console.WriteLine($"Area={s.Area()}");
}