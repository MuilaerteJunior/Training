

namespace DesignPatterns.Creational
{
    ///Best one!
    public class SingletonBuildOnDeclarationAndVolatile {
        private static volatile SingletonBuildOnDeclarationAndVolatile _unique = new SingletonBuildOnDeclarationAndVolatile();

        private SingletonBuildOnDeclarationAndVolatile(){}
        
        public string RandomName { get; set; }
        public static SingletonBuildOnDeclarationAndVolatile GetInstance(){
            return _unique;
        }
    }
}
