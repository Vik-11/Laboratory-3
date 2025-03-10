open System

let rec readSeq q = 
    seq {
        if q > 0 then
            let str = Console.ReadLine()
            yield str
            yield! readSeq(q - 1)
        }

let findSH (strings: seq<string>) =
    let cachedStr = strings |> Seq.cache
    let frst = Seq.head cachedStr
    Seq.fold (fun shortest s ->
        if String.length s  < String.length shortest then s
        else 
            shortest)
            frst cachedStr

let rec getInt() = 
    printfn "Enter quantity of strings: "
    let q = Console.ReadLine()
    match Int32.TryParse(q) with
    | true, q when q > 0 -> q
    | false, _ ->
        printfn "Try integer greater than 0"
        getInt()

let q = getInt()

printfn "Enter strings: "
let s1 = readSeq q
let SH = findSH s1
let lg = SH.Length
printf "Shortest is: %s, length is: %d" SH lg
