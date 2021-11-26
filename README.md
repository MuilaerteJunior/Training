

# Training
Repository for test and training purposes.

**Directory structure:**

```
Training
└─── C#
│   └───LearningProjecs
└─── netcore
    └───DesignPatterns
└─── net60
    └───CasesVerification
```

# More about the projects

## Learning Projects 
    This is a compilated source codes from some courses from Pluralsight that I had the opportunity to practice. Most of these source codes are C#, but there also Javascript snippets. Below are some topics of what were presented.
        1. Concurrenct Collections
        2. Asynchronous operations
        3. Language Internals 

## Design Patterns (Net core and xUnit)
    This project is destinated for design patterns / GanfOfFour (GoF) codes. More detailed informations are inside it.

 ## Net 6.0 (Cases Verification)
This project was developed to perform quick code verifications.

- ### **Case1 (Old Performance project)**
        This is a project that I created to be a quick way for doing some performance tests. In this way, probably I can isolated specific test cases and measure which could be the best option for writing a piece of code in larger projects.
        1. StringBuilder VS String.Concat VS ++ (plusplus)
        2. Queries with ToLower() VS String.Equals VS InstanceOfString.IndexOf

- ### **Case2 - Dealing with number precision using double and decimal**
        It's demonstrate a lot of fail cases using decimal/double and doing basic operations. There are simples cases that a double is not the right type for a number and even, decimal is not the right options also. How to deal with it?
