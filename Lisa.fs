namespace HackerRank

module Lisa =

   open System
      
   let inline flip func a b = func b a 
   let (/<) a b = Math.Ceiling ((float)a / (float)b) |> int
   let bint (v:bool) = Convert.ToInt32 (v)

   let specials max (ps, (s, e)) = 
           let spc = (s-1) / max
           let ss = s + spc
           let ee = max + spc * max
           let mm = ss + bint(ss > ee)
           
           if max = 1 then
               Math.Max((ps - (s - 1)), 0)
           else 
                if mm <= ps then 
                    1 + bint(s < e && (ss % max) = 0)
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
      
