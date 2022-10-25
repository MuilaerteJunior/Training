
namespace DesignPatterns.Creational.Singleton
{
    public class SingletonBuildOnDeclaration {
        private static SingletonBuildOnDeclaration _unique = new SingletonBuildOnDeclaration();

        private SingletonBuildOnDeclaration(){ }

        public string RandomName { get; set; }
        
        public static SingletonBuildOnDeclaration GetInstance(){
            return _unique;
        }
    }

}
