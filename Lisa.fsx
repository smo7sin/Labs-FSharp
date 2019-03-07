open System

let txt = "5 3
4 2 6 1 10"

let stdin = new IO.StringReader(txt)

let specials max (ps, (s, e)) = 
        let ss = s + (s-1)/max
        if ss <= ps then 
           1 + Convert.ToInt32((e = ps))
        else
           0

let openChapters chapters max =
    chapters 
    |> Seq.map (fun p -> Math.Ceiling ((float)p / (float)max))
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

    let result = openChapters chapters k
    stdout.WriteLine (result |> Seq.sum )
    0

main ()