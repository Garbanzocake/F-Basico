open System


type Animal = class 
   val Nombre : string
   val Altura : float
   val Peso : float
    

    new (nombre, altura, peso)=
        {Nombre = nombre; Altura = altura ;Peso = peso }

//Metodos de la clase
    member x.Correr=
       printfn "%s Corre" x.Nombre
end        

//Algo de herencia seria al crear otro animal con la clase base 
type Perro(nombre, altura, peso)=
    inherit Animal(nombre, altura, peso)

    member x.Ladrar=
        printfn "%s Ladra" x.Nombre


let claseanimal()=
    let Axel = new Animal("Axel", 20.5, 40.5 )

    Axel.Correr 

    let Tyson = new Perro("Tyson", 20.5, 40.5)

    Tyson.Correr

    Tyson.Ladrar

claseanimal()
