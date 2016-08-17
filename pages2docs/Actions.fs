module pages2docs.actions

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Writers
open Suave.Operators

let helloWorld = OK "<html><body><h1>Welcome to Pages2Docs!</h1></body></html>\n"
