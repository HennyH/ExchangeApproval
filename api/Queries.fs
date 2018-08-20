namespace Exchange

open FSharp.Data.Sql

module Queries =

    let [<Literal>] ResolutionPath = __SOURCE_DIRECTORY__ +
                                     "packages/system.data.sqlite.core/1.10.109.1/lib/netstandard2.0"
    let [<Literal>] ConnectionString = "Data Source=" +
                                       __SOURCE_DIRECTORY__ +
                                       @"/bin/exchange.db"


    type SQL = SqlDataProvider<Common.DatabaseProviderTypes.SQLITE,
                               SQLiteLibrary = Common.SQLiteLibrary.SystemDataSQLite,
                               ConnectionString = ConnectionString,
                               ResolutionPath = ResolutionPath,
                               CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>

    let ctx = SQL.GetDataContext()

    let things = query {
        for f in ctx.Main.Foo do
        join g in ctx.Main.Foo on (f.Id = g.Id)
        select f.Id
    }
