module Docs.State

open Elmish
open Feliz.Router

type Model = {
    CurrentPage : Router.Page
    Count : int
}

module Model =
    let init = {
        CurrentPage = Router.defaultPage
        Count = 1
    }

type Msg =
    | UrlChanged of Router.Page
    | Clicked

let init () =
    let nextPage = (Router.currentUrl() |> Router.parseUrl)
    { Model.init with CurrentPage = nextPage }, Cmd.none

let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    match msg with
    | UrlChanged p -> { currentModel with CurrentPage = p }, Cmd.none

    | Clicked ->
        { currentModel with Count = currentModel.Count + 1}, Cmd.none
