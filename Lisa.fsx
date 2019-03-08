open System

let txt = "10 5
3 8 15 11 14 1 9 2 24 31"

let stdin = new IO.StringReader(txt)
let (/<) a b = Math.Ceiling ((float)a / (float)b) |> int
let (/~) a b = Math.Round ((float)a / (float)b) |> int

let specials max (ps, (s, e)) = 
        let tp = 1 + e - s 
        let ss = s + (s-1) /~ max
        if ss <= ps then 
           1 + Convert.ToInt32((e >= (tp-1)* max) && ss < e)
        else
           0

let openChapters chapters max =
    chapters 
    |> Seq.map ((/<) max)
    |> Seq.map int
    |> Seq.scan (+) 1
    |> Seq.pairwise
    |> Seq.map (fun (s, e) -> (s, e-1))
    |> Seq.zip chapters
    |> Seq.map (specials max)

let (|Split|) (c:char) (txt:string) = txt.Split (c) |> Array.toList

let main () = 
    let line1 = stdin.ReadLine()
    let (n, k) = match line1 with
                    | Split ' ' [n; k] -> (n |> int, k |> int)
                    | _ -> (0, 0)
    
    let line2 = stdin.ReadLine()
    let chapters = match line2 with
                    | Split ' ' sx -> sx |> List.map int

    let result = openChapters chapters k |> Seq.toList
    stdout.WriteLine (result |> Seq.sum )
    0

main ()