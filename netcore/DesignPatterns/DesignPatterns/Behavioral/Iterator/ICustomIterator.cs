//TODO: Create an example using IEnumerable also!  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/iterators
namespace DesignPatterns.Behavioral.Iterator
{
    public interface ICustomIterator<T> {
        bool HasNext();
        T Next();
    }
}

