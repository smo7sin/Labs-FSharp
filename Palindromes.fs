namespace HackerRank

module Palindromes =

    let palindrome word = 
        word 
        |> Seq.countBy id
        |> Seq.map snd