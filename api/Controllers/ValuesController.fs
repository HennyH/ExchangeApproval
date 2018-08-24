namespace API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open API.Data.Queries
open System
open Microsoft.AspNetCore.Mvc

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController (configuration: IConfiguration) =
    inherit ControllerBase()

    let connectionString = configuration.["ConnectionString"]

    [<HttpGet("decisions")>]
    member this.Get([<FromQuery>]exchangeUniversityIds: System.Collections.Generic.List<int64>,
                    [<FromQuery>]uwaUnitContextIds: System.Collections.Generic.List<int64>,
                    [<FromQuery>]uwaUnitLevelIds: System.Collections.Generic.List<int64>) =
        use connection = connect connectionString
        connection.Open() |> ignore
        printfn "Uids = %A, CtxIds = %A, LvlIds = %A" exchangeUniversityIds uwaUnitContextIds uwaUnitLevelIds
        let queryParameters: UnitDecisionQueryParameters = {
            sorts = None;
            universityIds = Some(List.ofSeq exchangeUniversityIds);
            unitContextIds = Some(List.ofSeq uwaUnitContextIds);
            unitLevelIds = Some(List.ofSeq uwaUnitLevelIds);
        }
        let decisions = queryUnitDecisions connection queryParameters
        JsonResult(decisions)

    [<HttpGet("unit-levels")>]
    member this.Get() =
        use connection = connect connectionString
        connection.Open() |> ignore
        JsonResult(queryUnitLevels connection)
