using System;
using System.Linq;
class Program {

    static void Main() {
        dynamic x = Add(1, 2);
        Console.WriteLine((object) x);
        Console.ReadLine();

        dynamic d = Add(DateTime.Now, TimeSpan.Zero);
        Console.WriteLine((object) d);
        Console.ReadLine();

        dynamic s = Add("hello! ", "Dynamic!");
        Console.WriteLine((object) s);
        Console.ReadLine();

        dynamic y = Add(3, 4);
        Console.WriteLine((object) y);
        Console.ReadLine();

    }

    private static dynamic Add(dynamic v1, dynamic v2) {
        return v1 + v2;
    }
}
