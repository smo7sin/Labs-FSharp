namespace Hackerrank

open System

module StrongPassword =

    let strong txt = 
        let numbers = "0123456789"
        let lowercase = "abcdefghijklmnopqrstuvwxyz"
        let uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        let special = "!@#$%^&*()-+"
        let len = Math.Max (String.length(txt) - 6, 0)  
        
        len + (txt |> Seq.zip numbers) |> Seq.countBy id