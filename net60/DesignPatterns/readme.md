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

* ## Behavioral
  * Patterns that are concerned with how classes and objects interact and distribute responsibility
    ### Strategy
        Just a simple approach using the strategy Design Pattern
    ### Observer
        A Observer design pattern approach that uses typed interfaces for helping use specific objects for subscriber and publisher.
    ### Template Method
    ### Iterator
    ### State
* ## Structural
    ### Decorator
        Decorator design pattern applied conceptually to a "drink" environment, as how to decorate and apply open-closed principle, open for extensions and closed for modifications.

    ### Adapter
    ### Facade    
    ### Composite
    ### Bridge


        
/*
BRIDGE
BUILDER
FLYWEIGHT
CHAIR OF RESPONSIBILITY
INTERPRETER
MEDIATOR
*/