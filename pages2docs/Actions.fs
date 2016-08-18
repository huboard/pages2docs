module pages2docs.actions

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Writers
open Suave.Operators
open Suave.Redirection

let helloWorld = OK "<html><body><h1>Welcome to Pages2Docs!</h1></body></html>\n"

let clientId =
    match Some(System.Environment.GetEnvironmentVariable("GH_CLIENT_ID")) with
    | Some key -> key
    | None -> "MISSING"

let redirectUrl =
    match Some(System.Environment.GetEnvironmentVariable("GH_REDIRECT_URL")) with
    | Some key -> key
    | None -> "https://localhost:5000/auth/complete"


let scope = "public_repo"
let state = System.Guid.NewGuid().ToString()

let startAuth : WebPart = 
    let p = "https://github.com/login/oauth/authorize"
    let q = (sprintf "?client_id=%s&&redirect_uri=%s&scope=%s&state=%s" clientId redirectUrl scope state) 
    redirect p

let authComplete : WebPart = request (fun req ->
    let clientId =     match (req.formData "client_id") with
                        | Choice1Of2 t -> t
                        | Choice2Of2 t -> "MISSING"
    let clientSecret = match (req.formData "client_secret") with
                        | Choice1Of2 t -> t
                        | Choice2Of2 t -> "MISSING"
    let code =         match (req.formData "code") with
                        | Choice1Of2 t -> t
                        | Choice2Of2 t -> "MISSING"
    OK code)
