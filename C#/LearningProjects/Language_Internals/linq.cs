using System.Linq;
class Program {

    static void Main() {

        var rest = from x in new[] { 1, 2 } select x * x;
    }
}
