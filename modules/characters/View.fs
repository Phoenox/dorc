module Dorc.Modules.CharacterManager

open Elmish

type Model =
    {
        title: string
    }

let initModel =
    {
        title = ""
    }

type Message =
    | CreateNewCharacter

let update remote message model =
    match message with
    | CreateNewCharacter ->
        model, Cmd.none

let page model dispatch =
    