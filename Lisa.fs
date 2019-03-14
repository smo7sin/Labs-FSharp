namespace HackerRank

module Lisa =

   open System
//    let txt = "10 5
// 3 8 15 11 14 1 9 2 24 31"

//    let txt = "5 3
// 4 2 6 1 10"
// -> 4

   let txt = "90 29
3 7 11 1 8 4 3 14 13 10 18 3 3 21 20 24 21 26 22 23 2 21 23 26 31 33 30 33 38 35 34 39 44 3 49 51 54 3 49 53 53 62 59 1 1 62 65 77 78 76 78 80 84 89 94 100 100 100 100 100 100 100 100 3 100 100 100 100 100 100 100 100 100 100 100 100 100 100 100 2 100 100 100 100 100 2 100 100 100 100"
// -> 32

   let stdin = new IO.StringReader(txt)
   
   let inline flip func a b = func b a 
   let (/<) a b = Math.Ceiling ((float)a / (float)b) |> int
   let (/~) a b = Math.Round ((float)a / (float)b) |> int
   let bint (v:bool) = Convert.ToInt32 (v)

   let specials max (ps, (s, e)) = 
           let tp = 1 + e - s 
           let spc = (s-1) / max
           let ss = s + spc
           let ee = spc * max
           let mm = ss + bint(ss > ee)
           if mm <= ps then 
              1 + bint((ss % max) = 0)
           else
              0

   let openChapters chapters max =
       chapters 
       |> Seq.map (flip (/<) max)
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
       do stdout.WriteLine (result |> Seq.sum )
