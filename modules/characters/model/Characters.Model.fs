namespace Dorc.Characters

module Characters =

    type Character =
        abstract member ToString : unit -> string
        abstract member GetPlayerName : unit -> string
    
    // Defines a Character as used by Fate-Like games.
    //
    // Args:
    //  Name: The character name
    //  PlayerName: The player name
    //  StressBoxes: Defines how many stress boxes there are for a given kind of stress.
    //      The stress boxes themselves are then defined as per Fate core rules.
    //      (Fate's standard stress kinds are "physical" and "mental".)
    type FateCharacter(
            name: string,
            playerName: string, 
            stress: Map<string, List<int>>,
            aspects: List<string>
        ) =
        interface Character with
            member this.ToString () = $"{this.Name} | {this.PlayerName}"
            member this.GetPlayerName () = this.PlayerName
        
        new (prototype: FateCharacter, ?stress: Map<string, List<int>>, ?aspects : List<string>) =
            FateCharacter(
                prototype.Name,
                prototype.PlayerName,
                defaultArg stress prototype.Stress,
                defaultArg aspects prototype.Aspects
                )
        
        member val Name = name
        member val PlayerName = playerName
        member val Stress = stress
        member val Aspects = aspects

        member val Consequences : Map<string, List<string>> =
            Map.empty
                .Add("Light", [])
                .Add("Medium", [])
                .Add("Severe", [])
                .Add("Extreme", [])


    type Campaign(
        gameMaster: string,
        playerCharacters: List<Character>,
        nonPlayerCharacters: List<Character>
        ) =
        member this.GameMaster = gameMaster
        member this.PlayerCharacters = playerCharacters
        member this.NonPlayerCharacters = nonPlayerCharacters

        new (gameMaster: string) = Campaign(gameMaster, List.Empty, List.Empty)

        member this.ToString () =
            $"{this.GameMaster} | {this.PlayerCharacters |> List.map (fun c -> c.GetPlayerName())}"


    
        
    

    