//Aplicando la inferencia de tipos F# reconoce el tipo de valor que es su variable 
//Variable estatica y no podra cambiarse luego
let a = 5 
//Para que pueda cambiar luego el valor de la variable se especifica que es mutable
let mutable b = 10
b <- 20
//Colecciones son inmutables
let items = [1..5]
List.append items [6]
items



//Funciones
//toma dos cadenas y retorna 1 string
let prefijo cadprefijo cadbase =
     cadprefijo + ", " + cadbase

prefijo "Hola" "Daniel"
//-> significa retorna  
//funcion externa que retorna una funcion interna que retorna un string




//Sumas

let funcionsuma (c: int, d : int) : int = c + d

printfn "5 + 7 = %i" (funcionsuma(5,7))
//O de esta forma
let funcionsuma2 c d =
     c + d
printfn "5 + 7 = %i" (funcionsuma(5,7))     


     //let get_sum (x : int, y : int) : int = x + y


  
//Seq.map para cada item de lista para añadir el hola
let names = ["Daniel"; "Miguel";"Diana"]


names
|>Seq.map (prefijo "Hola")


//Otra forma
let names2 = ["Daniel"; "Miguel";"Diana"]

let prefijoconhola = prefijo "Hola"


names2
|>Seq.map prefijoconhola



//Otra forma con pipeline(Encadenar),primero se evalua las funciones para correrla luego con alt + enter
let names3 = ["Daniel"; "Miguel";"Diana"]

let prefijoconhola2 = prefijo "Hola"

let exclamacion s =
     s + "!"
//Composicion de funciones
names3
|> Seq.map prefijoconhola2
|> Seq.map exclamacion
//|> Seq.sort

//Otra forma con pipeline(Encadenar),primero se evalua las funciones para correrla luego con alt + enter
let names4 = ["Daniel"; "Miguel";"Diana"]

let prefijoconhola3 = prefijo "Hola"

let exclamacion2 s =
     s + "!"
//una nueva funcion que toma dos funciones y las une
let granHola = prefijoconhola3 >> exclamacion2
//la direccion de las >> indica quien ejecuta primero 

//Composicion de funciones
names4
|> Seq.map granHola
|> Seq.sort

