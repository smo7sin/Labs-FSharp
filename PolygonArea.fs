module PolygonArea

open System

[<Struct>]
type Point = { X: int; Y: int }

let crossProduct p1 p2 = p1.Y * p2.X - p1.X * p2.Y

let area ps 
    =  Math.Abs (Seq.sumBy (fun (a, b) -> crossProduct a b) (ps 
    |> Seq.pairwise)) / 2

let (|Split|) (c:char) (txt:string) = txt.Split (c) |> Array.toList

let main () =
    let count = stdin.ReadLine() |> int
    let parse = 
        function Split ' ' [x1; x2] -> Some ({X = x1 |> int; Y = x2 |> int}) 
                | _ -> None

    let points = 
        Seq.init count (ignore >> stdin.ReadLine)
        |> Seq.choose parse

    printfn "%d" (area points)
    ()