namespace Exchange

module Queries =

    open Dapper
    open Microsoft.Data.Sqlite
    open Exchange.Models

    type Connection = SqliteConnection

    type UnitQueryParameters = {
        university: string option;
        unitTypes: UnitType list option;
        unitLevels: UnitLevel list option;
    }

    type Foo(ID: int64) =
        member this.ID = ID

    let connect (datasource: string): Connection =
        new SqliteConnection("Data Source=" + datasource)

    let queryUnits (connection: Connection) (parameters: UnitQueryParameters option) =
        connection.Query<Foo>("SELECT * FROM Foo")