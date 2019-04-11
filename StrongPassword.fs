namespace Hackerrank

open System

module StrongPassword =

    let bool2int v = if v then 1 else 0

    let strong txt = 
        let numbers = "0123456789" |> Set.ofSeq
        let lowercase = "abcdefghijklmnopqrstuvwxyz" |> Set.ofSeq
        let uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" |> Set.ofSeq
        let special = "!@#$%^&*()-+" |> Set.ofSeq
        let len = Math.Max (String.length(txt) - 6, 0)  

        let inset = txt |> Set.ofSeq |> Set.intersect
        bool2int (inset numbers |> Set.isEmpty)