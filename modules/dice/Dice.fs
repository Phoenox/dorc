namespace DiceSharp

module Dice =

    let asWord number =
        match number with
         | 1 -> "one"
         | 2 -> "two"
         | 3 -> "three"
         | 4 -> "four"
         | 5 -> "five"
         | 6 -> "six"
         | 7 -> "seven"
         | 8 -> "eight"
         | 9 -> "nine"
         | 10 -> "ten"
         | 11 -> "eleven"
         | 12 -> "twelve"
         | i -> i.ToString()

    let printResult result sides =
        printf $"rolled a {result} on a {asWord sides}-sided die\n"

    // Returns a random integer between 0 (inclusive) and n-1 (inclusive)
    let randInt n =
        (System.Random().Next n)

    let roll sides =
        ((randInt sides) + 1)
    
    // We want a uniformally distributed result between -1 and +1
    let rollFudge () =
        [1 .. 4] |> List.map (fun _ -> (randInt 3) - 1 )

    let rollMultiple count sides =
        [1 .. count] |> List.map (fun _ -> roll sides)

    let printRolls count sides =
        [1 .. count] |>  List.map (fun _ -> printResult (roll sides) sides)

    [<EntryPoint>]
    let main argv =
        ignore (
            printRolls (int argv.[0]) (int argv.[1])
        )
        0
        
