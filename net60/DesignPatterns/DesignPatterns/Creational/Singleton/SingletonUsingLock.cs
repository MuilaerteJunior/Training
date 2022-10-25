
namespace DesignPatterns.Creational.Singleton
{
    public class SingletonUsingLock {
        private static SingletonUsingLock _unique;

        private SingletonUsingLock(){ }
        
        public string RandomName { get; set; }
        public static SingletonUsingLock GetInstance(){        
            if (_unique == null)
                _unique = new SingletonUsingLock();

            lock (_unique) {
                return _unique;
            }
        }
    }

}
