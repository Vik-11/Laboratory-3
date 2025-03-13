open System
open System.IO

let getLF (way: string) = 
    Directory.GetFiles(way)
    |> Seq.map Path.GetFileName
    |> Seq.sort
    |> Seq.tryLast

printfn "Enter path to directory: "
let rec readD () = 
     printfn "Enter valid directory: "
     let path = Console.ReadLine()
     if Directory.Exists(path) then
         path
     else
         printfn "Directory do not exists. Try again"
         readD()
    
//way = "C:\Users\Viktor\Desktop\Лабораторные работы по языкам программирования\Лабораторная работа 3\Задание 3\ListOfFiles"
let NewPath = readD()
match getLF NewPath with
| Some file -> printfn "Name of the last file by alphabetical order is: %s" file
| None -> printfn "Directory is empty"         
