

namespace DesignPatterns.Creational
{
    public class SingletonBuildOnDeclarationAndVolatileUsingLock {
        private static volatile SingletonBuildOnDeclarationAndVolatileUsingLock _unique = new SingletonBuildOnDeclarationAndVolatileUsingLock();


        private SingletonBuildOnDeclarationAndVolatileUsingLock(){ }
        public string RandomName { get; set; }
        public static SingletonBuildOnDeclarationAndVolatileUsingLock GetInstance(){
            if (_unique == null){
                lock (_unique){
                    _unique = new SingletonBuildOnDeclarationAndVolatileUsingLock();       
                }
            }

            return _unique;
        }
    }
}
