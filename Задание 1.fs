open System

let getCh () = 
    let rec loop () =
        printfn "Enter one symbol: "
        let c = Console.ReadLine()
        if c.Length = 1 then
            c
        else
            printfn "Input error: Enter exactly one symbol"
            loop()
    loop()

let rec getInt() = 
    printfn "Enter quantity of strings: "
    let q = Console.ReadLine()
    match Int32.TryParse(q) with
    | true, q when q > 0 -> q
    | false, _ ->
        printfn "Input error: Try integer greater than 0"
        getInt()

let rec readSeq q =
   seq {
       for _ in 1..q -> Console.ReadLine()
       }

let prepSymb (ch:string) lines =
    lines |> Seq.map (fun s -> s + ch)

let q = getInt()

printfn "Enter strings: "
let lines = readSeq q

let symb = getCh()
let newL = prepSymb symb lines

newL |> Seq.iter Console.WriteLine
