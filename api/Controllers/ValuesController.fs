namespace API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open API.Data.Queries
open API.Data.ViewModels

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

    [<HttpGet("filters")>]
    member this.GetFilters() =
        use connection = connect connectionString
        connection.Open() |> ignore
        let unitLevels = queryUnitLevels connection
        let contextTypes = queryUnitContexts connection
        let exchangeUniversities = queryExchangeUniversities connection None
        let filterOptions: FilterOptionsVM = {
            levelOptions = unitLevels |> List.ofSeq;
            contextOptions = contextTypes |> List.ofSeq;
            exchangeUniversities = exchangeUniversities |> List.ofSeq;
        }
        JsonResult(filterOptions)

    [<HttpPost("application")>]
    member this.SubmitRequests([<FromBody>]studentApplication: StudentApplicationVM) =
        printfn "Lets take a lookin"
        printfn "%O" studentApplication
        printfn "And thats it folks!"
