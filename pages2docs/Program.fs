namespace pages2docs

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config
open Suave.Filters
open Suave.Operators
open System.Net
open pages2docs.actions



module Program =
  let app =
    choose
      [ GET >=> choose
          [ path "/" >=> helloWorld
            path "/auth" >=> startAuth]
        POST >=> choose 
          [ path "/auth/handshake" >=> authComplete]]

  let port =
      match System.UInt16.TryParse(System.Environment.GetEnvironmentVariable("PORT")) with
      | true, parsedInt -> parsedInt
      | false, _ -> 5000us

  let config =
    let ip = IPAddress.Parse "0.0.0.0"
    {defaultConfig with
      logger = Logging.Loggers.saneDefaultsFor Logging.LogLevel.Verbose
      bindings = [HttpBinding.mk HTTP ip port ] }

  [<EntryPoint>]
  let main argv =
    startWebServer config app
    0
