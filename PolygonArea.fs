module PolygonArea

open System

[<Struct>]
type Point = { X: int; Y: int }

let crossProduct p1 p2 = p1.Y * p2.X - p1.X * p2.Y

let area ps 
    =  Math.Abs (Seq.sumBy (fun (a, b) -> crossProduct a b) (ps 
    |> Seq.pairwise)) / 2

let (|Split|) (c:char) (txt:string) = txt.Split (c) |> Array.toList

let trim (txt:string) = txt.TrimEnd()

let main () =
    let count = stdin.ReadLine() |> int 
    let parse = function
        | Split ' ' [p1; p2] -> Some ({ X=p1 |> int; Y= p2 |> int })
        | _ -> None
        
    let points = 
        Seq.init count (ignore >> stdin.ReadLine >> trim)
        |> Seq.choose parse

    do printfn "%d" (area points)