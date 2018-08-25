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
    member this.Get([<FromQuery(Name="universityId")>]exchangeUniversityIds: int32[],
                    [<FromQuery(Name="contextId")>]uwaUnitContextIds: int32[],
                    [<FromQuery(Name="levelId")>]uwaUnitLevelIds: int32[]) =
        use connection = connect connectionString
        connection.Open() |> ignore
        let decisions =
            queryUnitDecisions
                connection
                {
                    universityIds = Some(List.ofSeq exchangeUniversityIds);
                    unitContextIds = Some(List.ofSeq uwaUnitContextIds);
                    unitLevelIds = Some(List.ofSeq uwaUnitLevelIds);
                }
        JsonResult(decisions)

    [<HttpGet("unit-levels")>]
    member this.Get() =
        use connection = connect connectionString
        connection.Open() |> ignore
        JsonResult(queryUnitLevels connection)

    [<HttpGet("universities")>]
    member this.Universities() =
        use connection = connect connectionString
        connection.Open() |> ignore
        JsonResult(queryUniversities connection None)