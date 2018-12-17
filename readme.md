# Untyped combinator calculus DSL #  
## Introduction ##  

The purpose of this piece of software is to allow you to build untyped combinator logic terms, compute their values and display the results in human readable format, all that using C# code with straightforward syntax.      

The overall functionality revolves around Term class and classes inheriting from it.  
Every term is an ordered pair that contains an element on the left, an element on the right and a reference to its parent. It can be also thought of as a binary tree, where the first element of the combinator logic expression corresponds to lowest left element of the tree, and all the following elements can be gathered by traversing the tree in left-right-parent order.  

### Tree to ordered pair to combinator calculus expression relation examples

Term "Kxy" as a tree:  
![alt text](.//Docs/Kxy.svg "Kxy")
  
Term "xz(yz)" as a tree:  
![alt text](.//Docs/xz(yz).svg "xz(yz)")  

## DSL models and funcionality ##

### Short description of models used to build expressions: ###  
- `Term`: base class representing any kind of term. 
- `Applica`: application term, currently only used to build combinators.
- `Constant`: some constant value.
- `Variable`: some variable. Currently behaves the same way as constant.
- `VoidTerm`: special term used to signify termination of the branch of the tree and to complete single element terms to an ordered pair.   

Code of term models can be found in `Models\Term` folder of the `Kombinator` project. 

### Static methods of `Term`:  ###
- `public static Term BuildWith(Term[] args)`: returns a built term containing all the terms passed in the list, preserving their order. Combinator expressions are left associative, meaning the application order is left to right.   
- `public static Term EvaluateWith(Term[] args)`: returns an evaluated term after performing reduction to all objects where it's possible.  

### Public constructors of `Term` and classes that extend it: ###
- `public Term(Term leftTerm, Term rightTerm)`: constructs a term as an ordered pair, providing `Left` and `Right` elements explicitly. Sets the resulting object as a `Parent` of its `Left` and `Right` elements.
- `public Constant(object value) : base(value)`: constructs an ordered pair with `new VoidTerm()` (empty set) as a `Right` value.  
- `public Variable(string name) : base(name)`: analogous to previous constructor.  
- `public Applica(string funcName) : base(funcName)`: initializes an applicable object with a default action.  
- `public VoidTerm() : base((string) null)`: initializes a special terminal term.  

### Public instance methods of `Term` object:  ###
- `public Term Reduce()`: performs reduction of the whole term. No partial reduction or step limit.  
- `public Term Clone()`: creates a deep copy of a term object.  
- `public override string ToString()`: returns text representation of the term. Text representation itself is set in constructor.  
- `public string Stringify()`: returns representation of term as a pair of its `Left` and `Right` objects `ToString()` values.  
- `public Term Dump()`: puts stringification result of current term out into console.  
-  `public void RenewStringRepresentation()`: renews text representation of term from stringification result. 
- methods inherited from object type.

### Combinators ###
Current version ships with 3 classes `CombinatorI`, `CombinatorK`, `CombinatorS`, each implementing public static method `ConstructCombinator()` with return type `Applica`, constructing I, K and S combinator objects respectively.  
You can create your own combinators or objects of similar nature by defining their `Action` and `ArgumentNumbe`. in order to do this you have to create an `Applica` object and invoke its public instance method:  
`public void SetFunctionality(Func<Applica, Stack<Term>, ReductionResult> action, uint argumentsNumber)`  
where first argument is a function that takes a stack of arguments and returns an object of type `ReductionResult`, that encapsulates the resulting `Term` object.  

### Example of code ##
```cs
//Create terms
var K = CombinatorK.ConstructCombinator(); //Applica type
var one = new Constant("1");
var two = new Constant("2");
Console.WriteLine($"{K},{one},{two}"); //K,1,2

var stmt = Term.BuildWith(new Term[] 
                          { K, one, two }
                         ).Dump(); // ((K,1),2)
//Kxy = x
var stmt2 = Term.EvaluateWith(new Term[]
                              { K, one, two }
                             ).Dump(); // (1,())

//alternative way of evaluation
var stmt3 = stmt.Reduce().Dump(); // (1,())
```
More examples of code can be found in `KombinatorTests` project's code.
  
### Unit Tests

The solution includes a project `KombinatorTests`, containing unit tests  for building, evaluating and representing terms, and also tests of methods of tree traversal, used to make reduction possible. 