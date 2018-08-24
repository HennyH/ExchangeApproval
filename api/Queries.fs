namespace API.Data

module Queries =

    open Dapper
    open Microsoft.Data.Sqlite
    open API.Data.Models

    type Connection = SqliteConnection
    type Parameters = (string * obj) list

    let connect (datasource: string): Connection =
        new SqliteConnection("Data Source=" + datasource)

    let query<'T> (connection: Connection) (sql: string) (parameters: Parameters option): 'T seq =
        match parameters with
        | Some(p) -> connection.Query<'T>(sql, dict p)
        | None -> connection.Query<'T>(sql)

    let queryUniversities (connection: Connection) (name: string option) =
        let sql =
            @"
                SELECT university_id AS id, university_name AS name
                FROM university
                WHERE @Name IS NULL OR university_name LIKE '%' || @Name || '%'
            "
        let parameters = match name with
                         | Some(n) -> [("Name", n :> obj)]
                         | None -> []
        query<UniversityDTO> connection sql (Some parameters)
