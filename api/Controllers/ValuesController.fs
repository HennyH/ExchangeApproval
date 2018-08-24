namespace API.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open API.Data.Queries

[<Route("api/[controller]")>]
[<ApiController>]
type ValuesController (configuration: IConfiguration) =
    inherit ControllerBase()

    let connectionString = configuration.["ConnectionString"]

    [<HttpGet("{name}")>]
    member this.Get(name: string) =
        use connection = connect connectionString
        connection.Open() |> ignore
        let universities = queryUniversities connection (Some name)
        JsonResult(universities)

    [<HttpPost>]
    member this.Post([<FromBody>] value:string) =
        ()

    [<HttpPut("{id}")>]
    member this.Put(id:int, [<FromBody>] value:string ) =
        ()

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        ()
