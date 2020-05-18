// F# is Microsofts functional language
// It provides a way to develop predictable
// code that is often way shorter
// Functional languages apply functions
// to data rather then focus on state changes
// like most OO languages
 
// Functional languages are great when you
// must execute multiple processes at once.
// Because all variables are immutable it
// is hard to make changes that will effect
// the execution of other processes
 
// Whitespace is used to define code blocks
 
// Allows you access to ReadLine, WriteLine, etc.
open System
 
// ----- INTRODUCTION -----
 
// Let binds a name to a value or function
let hello() = 
 
    // Print to screen without a newline
    printf "Enter your name : "
 
    // Read data from the user
    // Identifiers must start with an underscore
    // or a letter and then numbers
    let name = Console.ReadLine()
 
    // printfn is statically typed in regards
    // to the parameters %s represents a string
    // %i : Integer
    // %f : float
    // %b : boolean
    // %s : string
    // %A : Internal representation of things like tuples
    // %O : Other objects
    printfn "Hello %s" name
 
    // Format floats which default to 6 digits 
    printfn "PI : %.4f" 3.141592653589793238462643383
 
    // Use M to keep precision to 27 decimals
    let big_pi = 3.141592653589793238462643383M
 
    printfn "Big PI : %M" big_pi
 
    // Add padding to right and left
    printfn "%-5s %5s" "a" "b"
 
    // Add dynamic padding
    printfn "%*s" 10 "Hi"
 
// ----- BINDING -----
let bind_stuff() =
    
    // By default variables are immutable
    // unless marked as mutable
    let mutable weight = 175
    weight <- 170
 
    printfn "weight : %i" weight
 
    // You can also use reference cells if you
    // must change values
    let change_me = ref 10
    change_me := 50
 
    printfn "change_me : %i" ! change_me
 
// ----- FUNCTIONS -----
// Functions start with let, the name, parameters, 
// optional parameter types, optional return type
let do_funcs() =
    
    let get_sum (x : int, y : int) : int = x + y
 
    printfn "5 + 7 = %i" (get_sum(5,7))
 
    // Calculate the factorial with a recursive
    // function
 
    let rec factorial x =
        if x < 1 then 1
        else x * factorial (x - 1)
 
    printfn "Factorial 4 : %i" (factorial 4)
 
    // 1st : result = 4 * factorial(3) = 4 * 6 = 24
    // 2nd : result = 3 * factorial(2) = 3 * 2 = 6
    // 3rd : result = 2 * factorial(1) = 2 * 1 = 2
 
    // We use fun to create lambda expressions
    // Create a list
    let rand_list = [1;2;3]
 
    // Map performs a calculation on every item
    // in the list and returns the new list
    let rand_list2 = List.map (fun x -> x * 2) rand_list
 
    // %A returns the internal representation
    // of a list
    printfn "Double List : %A" rand_list2
 
    // We can use the pipeline operator to nest
    // function calls
    [5;6;7;8]
 
    // Filter keeps only items in the list that 
    // match the condition
    |> List.filter (fun v -> (v % 2) = 0)
    |> List.map (fun x -> x * 2)
 
    // Once the list has been created print it
    |> printfn "Even Doubles : %A"
 
    // Another way to execute multiple functions
    let mult_num x = x * 3
    let add_num n = n + 5
 
    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num
 
    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)
 
// ----- MATH -----
let do_math() =
    printfn "5 + 4 = %i" (5 + 4)
    printfn "5 - 4 = %i" (5 - 4)
    printfn "5 * 4 = %i" (5 * 4)
    printfn "5 / 4 = %i" (5 / 4)
    printfn "5 %% 4 = %i" (5 % 4)
    printfn "5 ** 2 = %f" (5.0 ** 2.0)
 
    // Get the data type
    let number = 2
    printfn "Type : %A" (number.GetType())
 
    // Cast to another type
    printfn "A Float : %.2f" (float number)
    printfn "An Int : %i" (int 3.14)
 
    // Math functions
    // Also cos, sin, tan, acos, asin, atan,
    // cosh, sinh, tanh
    printfn "abs 4.5 : %i" (abs -1)
    printfn "ceil 4.5 : %f" (ceil 4.5)
    printfn "floor 4.5 : %f" (floor 4.5)
    printfn "log 2.71828 : %f" (log 2.71828)
    printfn "log10 1000 : %f" (log10 1000.0)
    printfn "sqrt 25 : %f" (sqrt 25.0)
 
// ----- STRINGS -----
let string_stuff() =
    // Escape characters
    // \n, \\, \", \'
    let str1 = "This is a random string"
 
    // Verbatim Strings
    let str2 = @"I ignore backslashes"
 
    // Triple Quoted Strings
    let str3 = """ "I ignore double quotes and backslashes" """
 
    // Combine strings
    let str4 = str1 + " " + str2
 
    // Get length
    printfn "Length : %i" (String.length str4)
 
    // Access index
    printfn"%c" str1.[1]  
 
    // Get a substring with a range
    printfn"1st Word : %s" (str1.[0..3])
 
    // Collect executes a function on each character
    let upper_str = String.collect (fun c -> sprintf"%c, " c) "commas"
    printfn "Commas : %s" upper_str
 
    // Exists checks if any characters meet a condition
    printfn "Any Upper : %b" (String.exists (fun c -> Char.IsUpper(c)) str1)
 
    // Check if every character meets condition
    printfn "Number : %b" (String.forall (fun c -> Char.IsDigit(c)) "1234")
 
    // Apply function to each index in a string
    let string1 = String.init 10 (fun i -> i.ToString())  
    printfn"Numbers : %s" string1
 
    // Apply function to each item in string
    String.iter(fun c -> printfn "%c" c) "Print Me" 
 
// ----- LOOPING -----
 
let loop_stuff() =
 
    // ----- WHILE LOOP -----
    let magic_num  = "7"
    let mutable guess = ""
 
    while not (magic_num.Equals(guess)) do
        printf "Guess the Number : "
        guess <- Console.ReadLine()
 
    printfn "You Guessed the Number"
 
    // ----- FOR LOOP -----
    for i = 1 to 10 do 
        printfn "%i" i
 
    // Iterate down
    for i = 10 downto 1 do
        printfn "%i" i
 
    // Iterate over a range
    for i in [1..10] do
        printfn "%i" i
 
    // Why loop at all when you can pipe
    // a list to any function
    [1..10] |> List.iter (printfn "Num : %i")
 
    // Sum a list
    let sum = List.reduce (+) [1..10]
    printfn "Sum : %i" sum
 
// ----- CONDITIONALS -----
 
let cond_stuff() =
 
    // ----- IF ELSE ELIF -----
    let age = 8
 
    if age < 5 then
        printfn "Preschool"
    elif age = 5 then 
        printfn "Kindergarten"
    elif (age > 5) && (age <= 18) then
        let grade = age - 5
        printfn "Go to Grade %i" grade
    else
        printfn "Go to College"
 
    let gpa = 3.9
    let income = 15000
    printfn "College Grant : %b" ((gpa >= 3.8) || (income <= 12000))
 
    printfn "Not True : %b" (not true)
 
    // ----- MATCH -----
    // You can use match and guard statements
    // to do the same thing
    let grade2: string = 
        match age with
        | age when age < 5 -> "Preschool"
        | 5 -> "Kindergarten" 
        | age when ((age > 5) && (age <= 18)) -> (age - 5).ToString()
        | _ -> "College"
 
    printfn "Grade2 : %s" grade2
 
// ----- LISTS -----
let list_stuff() =
    // Define a list literal
    let list1 = [1; 2; 3; 4]
 
    // Print list
    list1 |> List.iter (printfn "Num : %i")
 
    // Print list
    printfn "%A" list1
 
    // Use cons operator 
    let list2 = 5::6::7::[]
    printfn "%A" list2
 
    // Use ranges
    let list3 = [1..5]
    let list4 = ['a'..'g']
    printfn "%A" list4
 
    // Generate a list with init
    // Create 5 indexes and multiply the index
    // value times 2
    let list5 = List.init 5 (fun i -> i * 2)
    printfn "%A" list5
 
    // Generate a list with yield
    let list6 = [ for a in 1..5 do yield (a * a) ]
    printfn "%A" list6
 
    // Generate even list with yield
    let list7 = [ for a in 1 .. 20 do if a % 2 = 0 then yield a]
    printfn "%A" list7
 
    // Generate a list with yield bang which
    // creates multiple lists for each item
    // and merges into a final list
    // 1 generates 1; 2; 3 for example
    let list8 = [for a in 1..3 do yield! [ a .. a + 2 ] ]
    printfn "%A" list8
 
    // Get length
    printfn "Length : %i" list8.Length
 
    // Check if empty
    printfn "Empty : %b" list8.IsEmpty
 
    // Get item at index
    printfn "Index 2 : %c" (list4.Item(2))
 
    // Get the 1st item
    printfn "Head : %c" (list4.Head)
 
    // Get the tail
    printfn "Tail : %A" (list4.Tail)
 
    // Filter out only evens
    let list9 = list3 |> List.filter (fun x -> x % 2 = 0)
    printfn "Evens : %A" list9
 
    // Multiply all values times themselves
    let list10 = list9 |> List.map (fun x -> (x * x))
    printfn "Squares : %A" list10
 
    // Sort a list
    printfn "Sorted : %A" (List.sort [5; 4; 3])
 
    // Sum a list with fold
    printfn "Sum : %i" (List.fold (fun sum elem -> sum + elem) 0 [1;2;3])
 
// ----- ENUMS -----
 
// You can define enums 
type emotion =
| joy = 0
| fear = 1
| anger = 2
 
let enum_stuff() = 
 
    let my_feeling = emotion.joy
 
    match my_feeling with
    | joy -> printfn "I'm joyful"
    | fear -> printfn "I'm fearful"
    | anger -> printfn "I'm angry"
 
// ----- OPTIONS -----
// Option is used when a function may not return 
// a value
 
let option_stuff() = 
 
    // Divide unless they try to divide by 0
    let divide x y =
        match y with
        | 0 -> None
        | _ -> Some(x/y)
 
    if (divide 5 0).IsSome then
        printfn "5 / 0 = %A" ((divide 5 0).Value)
    elif (divide 5 0).IsNone then
        printfn "Can't Divide by Zero"
    else
        printfn "Something Happened"
 
// ----- TUPLES -----
// Comma separated list of values of any type
 
let tuple_stuff() =
    let avg (w, x, y, z) : float =
        let sum = w + x + y + z
        sum / 4.0
 
    printfn "Avg : %f" (avg (1.0,2.0,3.0,4.0))
 
    let my_data = ("Derek", 42, 6.25)
 
    // Get data from tuple but ignore height
    let (name, age, _) = my_data
    printfn "Name : %s" name
 
// ----- RECORDS -----
// Lists of key value pairs for creating custom types
 
type customer = 
        { Name : string;
        Balance : float}
 
let record_stuff() =
 
    let bob = { Name = "Bob Smith"; Balance = 101.50 }
    printfn "%s owes us %.2f" bob.Name bob.Balance
 
// ----- SEQUENCES -----
// Sequences are infinite data structures that 
// aren't defined until needed
 
let seq_stuff() =
    // You can have a list made from a range
    let seq1 = seq { 1 .. 100 }
 
    // You can use a range of evens
    let seq2 = seq { 0 .. 2 .. 50 }
 
    // Descending sequence
    let seq3 = seq { 50 .. 1 }
 
    // If you try to print it is abbreviated
    printfn "%A" seq2
 
    // Print the whole list
    Seq.toList seq2 |> List.iter (printfn "Num : %i")
 
    // Test if a number is prime
    let is_prime n =
        let rec check i =
            i > n/2 || (n % i <> 0 && check (i + 1))
        check 2
 
    // If is_prime returns true then add to the sequence
    let prime_seq = seq { for n in 1..500 do if is_prime n then yield n }
 
    printfn "%A" prime_seq
 
    // Print the whole list of primes
    Seq.toList prime_seq |> List.iter (printfn "Prime : %i")
 
// ----- MAPS -----
// Maps are collections of key value pairs
 
let map_stuff() =
    // Create a map
    let customers =
        // Create empty map
        Map.empty. 
            // Add key values to map
            Add("Bob Smith", 100.50).
            Add("Sally Marks", 50.25)
 
    // Number of customers
    printfn "# of Customers %i" customers.Count
 
    // Find Bob Smiths balance
    let cust = customers.TryFind "Bob Smith"
    match cust with
    | Some x -> printfn "Balance : %.2f" x
    | None -> printfn "Not Found"
 
    // List customer names and balances
    printfn "Customers: %A" customers
 
    // Test if key exists
    if customers.ContainsKey "Bob Smith" then
        printfn "Bob Smith was Found"
 
    // Get value of key
    printfn "Bobs Balance : %.2f" customers.["Bob Smith"]
 
    // Remove an item
    let custs2 = Map.remove "Sally Marks" customers
    printfn "# of Customers %i" custs2.Count
 
// ----- GENERICS -----
// Generics allow you to use any data type in a function
 
let add_stuff<'T> x y =
        printfn "%A" (x + y)
 
let generic_stuff() =
        
    // add_stuff<float> 5.5 2.4
    add_stuff<int> 5 2
 
// ----- EXCEPTION HANDLING -----
// Allows use to catch errors
 
let exp_stuff() =
    let divide x y =
        try
            printfn "%.2f / %.2f = %.2f" x y (x / y)
        with
            | :? System.DivideByZeroException -> printfn "Can't Divide by Zero"
 
    divide 5.0 4.0
 
// ----- STRUCTS -----
// Structs allow you to create data types
 
type Rectangle = struct
    val Length : float
    val Width : float
 
    new (length, width) =
        {Length = length; Width = width}
end
 
let struct_stuff() =
    
    let area(shape: Rectangle) =
        shape.Length * shape.Width
 
    let rect = new Rectangle(5.0, 6.0)
 
    let rect_area = area rect
 
    printfn "Area : %.2f" rect_area
    
// ----- CLASSES -----
// Classes model real world objects by
// defining their attributes (fields) and
// capabilities (methods)
 
type Animal = class
   val Name : string
   val Height : float
   val Weight : float
 
   new (name, height, weight) =
      { Name = name; Height = height; Weight = weight;}
 
   member x.Run =
      printfn "%s Runs" x.Name
end
 
// ----- INHERITANCE -----
 
// Define the subclass Dog
type Dog(name, height, weight) = 
    inherit Animal(name, height, weight)
 
    member x.Bark =
        printfn "%s Barks" x.Name
 
let class_stuff() =
    let spot = new Animal("Spot", 20.5, 40.5)
 
    spot.Run
 
    let bowser = new Dog("Bowser", 20.5, 40.5)
 
    // Subclasses get every field and method
    // in the super class plus new ones
    bowser.Run
    bowser.Bark
 
hello()
 
bind_stuff()
 
do_funcs()
 
do_math()
 
string_stuff()
 
loop_stuff()
 
cond_stuff()
 
list_stuff()
 
enum_stuff()
 
option_stuff()
 
tuple_stuff()
 
record_stuff()
 
seq_stuff()
 
map_stuff()
 
generic_stuff()
 
exp_stuff()
 
struct_stuff()
 
class_stuff()
 
// Keeps the console open
// Ignore says to ignore the input
System.Console.ReadKey() |> ignore