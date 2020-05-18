open System

let hola() = 
    printf "Ingresa tu nombre : "

    let nombre = Console.ReadLine()
//%s =string ,%i integer ,%float ,%b boolean ,%A Tuples,%o Objects
    printfn "Hola %s" nombre 

//Llamar la funcion
hola()

Console.ReadKey() |> ignore 

//Formatear 

let hola2()=
    printfn "PI : %.4f" 3.14169265358979323


hola2()

//Enlazar cosas

let enlazar_cosa()=
    let mutable peso = 175
    peso <- 170

    printfn "peso : %i" peso

    let cambiar_me = ref 10 
    cambiar_me := 50

    printfn "cambiar : %i" ! cambiar_me


enlazar_cosa()

//Funciones 

let hacer_func()=

    let obten_sum (x : int, y : int) : int = x + y
    
    printfn "5 + 7 = %i"  (obten_sum(5,7))

hacer_func()



let funcrecur()=

     //Ejemplo de funcion recursiva
    let rec factorial x = 
        if x < 1 then 1
        else x * factorial (x - 1)

    printfn "Factorial de 4 : %i" (factorial 4)


funcrecur()


//Listas
let funcionlist()=
    let rand_list = [1..3]
//Duplicar la lista que teniamos 
    let rand_list2 = List.map (fun x -> x *2) rand_list

    printfn "Lista doble : %A" rand_list2

funcionlist()

//Operador Pipeline

let fpipeline()=
    let rand_list = [1..3]
//Duplicar la lista que teniamos 
    let rand_list2 = List.map (fun x -> x *2) rand_list

    printfn "Lista doble : %A" rand_list2
//añadir valores que cumplan la condicion a la lista
    [5..8]
    //Saca el modulo de 2 para los numeros arriba 5 al 8 y los guarda
    |> List.filter(fun v -> (v % 2 )= 0 )//se encarga de filtrar,dejar los numeros pares
    |> List.map (fun x -> x * 2)//mapea guarda solo los que pasaron el filtro
    |> printfn "solo Pares,  dobles : %A"

//Otro ejemplo de encadenar funciones,primero una luego otra segun ">>" o "<<"
    let mult_num x = x * 3 
    let add_num y = y + 5 

    let mult_add = mult_num >> add_num   
    let add_mult = mult_num << add_num   

    printfn "mult_add :%i" (mult_add 10)
    printfn "add_mult :%i" (add_mult 10)
fpipeline()



let hacer_mates()=

    printfn " 5 + 4 = %i" (5 + 4)
    printfn " 5 - 4 = %i" (5 - 4)
    printfn " 5 * 4 = %i" (5 * 4)
    printfn " 5 / 4 = %i" (5 / 4)
    printfn " 5 %% 4 = %i" (5 % 4)
    printfn " 5 ** 2 = %f" (5.0 ** 2.0) //potencia al cuadrado

    let numero = 2 
    printfn "Type : %A" ( numero.GetType())

    printfn "A Float  : %2f" (float numero)
    printfn "An Int  : %i" (int 3.14)

hacer_mates()

//Ciclo while

let ciclowhile()=
    let num_magico = "7"
    let mutable adivinado= ""
    
    while not (num_magico.Equals(adivinado)) do
        printf "Adivina el numero : "
        adivinado <- Console.ReadLine()
    
    printfn "Adivinaste el numero!! "
 

ciclowhile()


//Ciclo for

let ciclofor()=
    for i = 1 to 10 do
        printfn "%i" i
    
    for i = 10 downto 1 do
        printfn "%i" i

    for i in [1..10] do 
        printfn "%i" i

    [1..10] |> List.iter (printfn "Numero : %i")

    let sum = List.reduce (+) [1..10]
    printfn "Sum :%i" sum
ciclofor()   

//Condicionales    

let condicional()=

    let edad = 8 

    if edad < 5 then 
        printfn "Preescolar"
    elif edad = 5 then   
        printfn "Kindergarten"        
    elif (edad > 5) && (edad <= 18) then
        let grado = edad - 5
        printfn "Ir al grado %i" grado 
    else
        printfn "Ir a la universidad"       


    //Califica para beca?

    let prom = 3.9
    let ingresos= 15000

    printfn "Beca concedida : %b"((prom >=3.8)|| (ingresos <=12000) )

    printfn "No verdadero : %b"(not true)



      // ----- MATCH -----
    // You can use match and guard statements
    // to do the same thing
    let grade2: string = 
        match edad with
        | edad when edad < 5 -> "Preschool"
        | 5 -> "Kindergarten" 
        | edad when ((edad > 5) && (edad <= 18)) -> (edad - 5).ToString()
        | _ -> "College"
 
    printfn "Grade2 : %s" grade2
 

condicional()    




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


//Estructuras

type Rectangle = struct 
    val Longitud: float
    val Ancho : float
    new (length, width)=
        {Longitud = length; Ancho = width}
end        

let festructura()=
    let area(forma: Rectangle)=
        forma.Longitud * forma.Ancho

    let rect = new Rectangle(5.0, 6.0)

    let rect_area = area rect

    printfn "Area : %.2f" rect_area



festructura()






