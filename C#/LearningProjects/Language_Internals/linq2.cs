using System.Linq;
class Program {

    static void Main() {

        var rest = from x in new int[0]
                   let y = x * 2//constant identifier
                   select x * y;
    }
}
