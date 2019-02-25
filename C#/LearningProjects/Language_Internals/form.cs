using System;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Language_Internals {
    class Program {
        static void Main(string[] args) {
            var frm = new Form();

            frm.Click += (o, e) => {
                Console.WriteLine(string.Join(", ", args));
            };

            byte[] b = new byte[64 * 1024 * 1024];

            Task.Run(() => {
                new Random().NextBytes(b);
                Console.WriteLine(b.Length);
            });

            GC.Collect();
            Application.Run(frm);
        }
    }
}
