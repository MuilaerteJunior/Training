# Design Patterns


* ## Creational
  * Creational patterns separate a system from how its objects are created, composed, and represented.
    ### Singleton Approaches
        1. Using a simple field with an object reference and checking if is null
        2. Instantiating the object reference in its declaration
            This approach fails while trying to acess the main object
        3. Instantiating the object reference in its declaration and using volatile keyword
        4. Instantiating the object reference in its declaration, using volatile keyword and a lock if eventually the field is null
        5. Using a simple field with an object reference and using lock for verifying if is null or not
            This approach fails while trying to acess the main object
    ### Builder
        It facilitates the creation of complex objects, splitting the process into well sized chunks.
    ### Factory Method
    ### Prototype
    ### Abstract Factory
        
* ## Behavioral
  * Patterns that are concerned with how classes and objects interact and distribute responsibility
    ### Strategy
        Just a simple approach using the strategy Design Pattern. Strategy make possible to change the behavior of a class in runtime.
    ### Observer
        A Observer design pattern approach that uses typed interfaces for helping use specific objects for subscriber and publisher.
    ### Template Method
        Offers a way to solve the problem of having class that have same steps to perform an operation. It creates a method in abstract class that performs steps of which each concrete class will decide how to behave.
    ### Iterator
        A pattern that helps on how to iterate over elements from contained by a collection of objects.
    ### State
        Guide on how to keep information about states over application lifecycle/interactions.
    ### Chain of responsibility
        Break down the scope of each class's responsibilities on how to handle a specific operation/Request.
    ### Mediator
        Simplifies communication between classes.
    ### Visitor
    ### Memento
    ### Command
    ### Interpreter

* ## Structural
    ### Decorator
        Decorator design pattern applied conceptually to a "drink" environment, as how to decorate and apply open-closed principle, open for extensions and closed for modifications.
    ### Adapter
        Allow data comunication between two different classes as an intermediary element between its.
    ### Facade
        Simplifies complex interactions exposing simple methods (that aggregates this complex operations) for its consumers.
    ### Composite
        Facilitates working with structure data that are trees.
    ### Bridge
        Decouples an abstraction from its implementations, allowing that can use different objects.
    ### Flyweight
        Manages maintaining objects
* ## Others
    ### Service Locator Pattern
        This is a software design pattern for registering and getting services instances that will be used in your application during execution time. It's getting obsolete since Dependency Injection increase its popularity. 
        Service Locator Pattern aims to reduce highly coupled classes, it concentrate service instances in a single location tending to reduce bad usage of memory and  it facilitates testability as well. 