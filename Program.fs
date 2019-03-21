﻿// Learn more about F# at http://fsharp.org
module Terminal 

open System

// 76

//    let txt = "10 5
// 3 8 15 11 14 1 9 2 24 31"

let txt = "5 3
4 2 6 1 10"
// -> 4

//    let txt = "90 29
// 3 7 11 1 8 4 3 14 13 10 18 3 3 21 20 24 21 26 22 23 2 21 23 26 31 33 30 33 38 35 34 39 44 3 49 51 54 3 49 53 53 62 59 1 1 62 65 77 78 76 78 80 84 89 94 100 100 100 100 100 100 100 100 3 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 2 100 100 100 100 100 2 100 100 100 100"
// -> 32

let stdin = new IO.StringReader(txt)

open HackerRank

[<EntryPoint>]
let main args =
    let k = 100 
    let chapter = (100, (100, 100))
    stdout.WriteLine (Lisa.specials k chapter)
    0