open System
open System.IO

let getLF (way: string) = 
    Directory.GetFiles(way)
    |> Seq.map Path.GetFileName
    |> Seq.sort
    |> Seq.tryLast

let way = "C:\Users\Viktor\Desktop\Лабораторные работы по языкам программирования\Лабораторная работа 3\Задание 3\ListOfFiles"

match getLF (way) with
| Some file -> printfn "Name of the last file by alphabetical order is: %s" file
| None -> printfn "Directory not found or empty"
