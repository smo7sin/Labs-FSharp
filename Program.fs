// Learn more about F# at http://fsharp.org
module Terminal 

open System
open System.IO
open System.IO

module PolygonArea =
    let sample () =
        let text = @"4
        0 0
        0 2
        2 2
        2 0"
        new StringReader(text)

    let sample2 () = 
        let text = @"3
        1043 770
        551 990
        681 463"

        new StringReader(text)

open HackerRank

[<EntryPoint>]
let main args =
    (PolygonArea.sample2 >> PolygonArea.main) ()
    0