# Design Patterns


* ## Creational
    ### Singleton Approaches
        1. Using a simple field with an object reference and checking if is null
        2. Instantiating the object reference in its declaration
            *This approach fails while trying to acess the main object*
        3. Instantiating the object reference in its declaration and using volatile keyword
        4. Instantiating the object reference in its declaration, using volatile keyword and a lock if eventually the field is null
        5. Using a simple field with an object reference and using lock for verifying if is null or not
            *This approach fails while trying to acess the main object*


