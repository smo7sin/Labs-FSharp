﻿// Learn more about F# at http://fsharp.org
module Terminal 
open HackerRank


[<EntryPoint>]
let main args =
    let k = 5
    let last = (31, (22, 28));
    stdout.WriteLine (Lisa.specials k last)
    0