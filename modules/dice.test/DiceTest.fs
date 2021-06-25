module diceTests

open NUnit.Framework
open DiceSharp

[<SetUp>]
let Setup () =
    ()

[<Test>]
let test_roll_staysInBounds () =
    let sides = 6
    let sampleCount = 1000
    let samples = [1 .. sampleCount] |> List.map (fun _ -> Dice.roll sides)
    let lowerBound = 1
    let upperBound = sides

    samples
        |> List.map 
            (fun i -> Assert.That(i, Is.LessThanOrEqualTo upperBound))
        |> ignore
    samples
        |> List.map
            (fun i -> Assert.That(i, Is.GreaterThanOrEqualTo lowerBound))
        |> ignore

[<Test>]
let test_rollMultiple_staysInBounds () =
    let sides = 12
    let number = 1000
    let samples = Dice.rollMultiple number sides
    let lowerBound = 1
    let upperBound = sides

    samples
        |> List.map 
            (fun i -> Assert.That(i, Is.LessThanOrEqualTo upperBound))
        |> ignore
    samples
        |> List.map
            (fun i -> Assert.That(i, Is.GreaterThanOrEqualTo lowerBound))
        |> ignore

[<Test>]
let test_rollFudge_staysInBounds () =
    let sampleCount = 1000 / 4
    let samples = [1 .. sampleCount] |> List.collect (fun _ -> Dice.rollFudge ())
    let lowerBound = -1
    let upperBound = 1

    samples
        |> List.map 
            (fun i -> Assert.That(i, Is.LessThanOrEqualTo upperBound))
        |> ignore
    samples
        |> List.map
            (fun i -> Assert.That(i, Is.GreaterThanOrEqualTo lowerBound))
        |> ignore
