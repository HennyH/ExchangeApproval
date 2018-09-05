namespace API.Data.Models

open System
open Microsoft.EntityFrameworkCore
open System.ComponentModel.DataAnnotations
open API.Enums
open FSharp.EFCore.OptionConverter
open Microsoft.EntityFrameworkCore.Design
open Microsoft.Extensions.Configuration
open System

module Data =

  [<CLIMutable>]
  type UnitApprovalRequest =
      { [<Key>]id: int;
        decisionDate: DateTime;
        [<Required>]
        exchangeUniversityName: string;
        [<Required>]
        exchangeUnitName: string;
        exchangeUnitCode: string;
        [<Required>]
        exchangeUnitOutlineHref: string;
        uwaUnitName: string;
        uwaUnitCode: string;
        [<Required>]
        unitContext: UWAUnitContext;
        approved: bool;
        }
      with
        static member Configure(mb: ModelBuilder) =
          ()
          // mb.Model.FindEntityType(typeof<UnitApprovalRequest>)
          //         .FindProperty("decisionDate")
          //         .SetValueConverter(new OptionConverter<DateTime>())
          // mb.Model.FindEntityType(typeof<UnitApprovalRequest>)
          //         .FindProperty("exchangeUnitCode")
          //         .SetValueConverter(new OptionConverter<string>())
          // mb.Model.FindEntityType(typeof<UnitApprovalRequest>)
          //         .FindProperty("uwaUnitName")
          //         .SetValueConverter(new OptionConverter<string>())
          // mb.Model.FindEntityType(typeof<UnitApprovalRequest>)
          //         .FindProperty("uwaUnitCode")
          //         .SetValueConverter(new OptionConverter<string>())

  [<AllowNullLiteral>]
  type ExchangeDbContext (options: DbContextOptions<ExchangeDbContext>) =
      inherit DbContext(options)

      [<DefaultValue>]
      val mutable private unitApprovalRequests: DbSet<UnitApprovalRequest>

      member this.UnitApprovalRequests
        with get() = this.unitApprovalRequests
         and set v = this.unitApprovalRequests <- v

      override __.OnModelCreating (mb: ModelBuilder) =
        base.OnModelCreating mb
        UnitApprovalRequest.Configure mb

  [<AllowNullLiteral>]
  type Queries =
    member this.QueryUniversities (db: ExchangeDbContext) (name: string option) =
      query {
        for request in db.UnitApprovalRequests do
        where (request.decisionDate.IsSome)
        select request.exchangeUniversityName
      } |> Seq.toArray

  let connect (datasource: string): ExchangeDbContext =
    let opts = DbContextOptionsBuilder<ExchangeDbContext>()
    opts.UseSqlite(sprintf "Data Source=%s" datasource) |> ignore
    new ExchangeDbContext(opts.Options)

  type DesignTimeDbFactory() =
      interface IDesignTimeDbContextFactory<ExchangeDbContext> with
        member this.CreateDbContext(args: string[]) =
          connect (Environment.GetEnvironmentVariable("DATABASE"))