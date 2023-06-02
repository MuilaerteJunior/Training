

namespace DesignPatterns.Creational.Singleton
{
    ///Best one!
    public class SingletonBuildOnDeclarationAndVolatile {
#pragma warning disable IDE0044 // Add readonly modifier
        private static volatile SingletonBuildOnDeclarationAndVolatile _unique = new();
#pragma warning restore IDE0044 // Add readonly modifier

        private SingletonBuildOnDeclarationAndVolatile(){}
        
        public string RandomName { get; set; }
        public static SingletonBuildOnDeclarationAndVolatile GetInstance(){
            return _unique;
        }
    }
}
