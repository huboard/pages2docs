module pages2docs.actions

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Writers
open Suave.Operators
open Suave.DotLiquid
open DotLiquid

setTemplatesDir "./templates"

type Model =
  { title : string }

let helloWorld : WebPart =
    let o = { title = "Hello" }
    page "hello.liquid" o

