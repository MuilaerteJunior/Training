
namespace DesignPatterns.Creational
{
    public class Singleton {
        private static Singleton _unique;
        public string RandomName { get; set; }

        private Singleton(){}

        public static Singleton GetInstance(){
            if ( _unique == null)
                _unique = new Singleton();

            return _unique;
        }
    }
}
