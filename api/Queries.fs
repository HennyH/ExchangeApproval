namespace API.Data

module Queries =

    open Dapper
    open Microsoft.Data.Sqlite
    open SqlFrags.SqlGen
    open API.Data.Models
    open API.Enums

    type Connection = SqliteConnection
    type Parameters = (string * obj) list
    type SortOrder = Ascending | Descending

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
                WHERE @FilterByName IS NULL OR university_name LIKE '%' || @Name || '%'
            "
        let parameters = [
            "FilterByName", (match name with | Some(name) -> true | None -> false) :> obj;
            "Name", defaultArg name "" :> obj;
        ]
        query<UniversityDTO> connection sql (Some parameters)

    let queryUnitContexts (connection: Connection) =
        query<UnitContextDTO>
            connection
            @"
                SELECT uwa_unit_context_id AS id, uwa_unit_context_name AS name
                FROM uwa_unit_context
                ORDER BY uwa_unit_context_id ASC
            "
            None

    let queryUnitLevels (connection: Connection) =
        query<UnitLevelDTO>
            connection
            @"
                SELECT uwa_unit_level_id AS id, uwa_unit_level_name AS name
                FROM uwa_unit_level
                ORDER BY uwa_unit_level_id ASC
            "
            None

    let queryExchangeUniversities (connection: Connection) =
        query<UniversityDTO>
            connection
            @"
                SELECT university_id AS id, university_name AS name FROM exchange_universities
            "

    type UnitDecisionQueryParameters = {
        universityIds: int32 list option;
        unitContextIds: int32 list option;
        unitLevelIds: int32 list option;
    }

    let queryUnitDecisions (connection: Connection) (queryParameters: UnitDecisionQueryParameters) =
        let parameters =
            match queryParameters with
            | { universityIds = uniIds; unitContextIds = contextIds; unitLevelIds = levelIds } ->
                [
                    "FilterByExchangeUniversities", (match uniIds with | Some(ids) -> ids.Length > 0 | None -> false) :> obj;
                    "ExchangeUniversities", defaultArg uniIds [] :> obj;
                    "FilterByUWAUnitContextIds", (match contextIds with | Some(ids) -> ids.Length > 0 | None -> false) :> obj;
                    "UWAUnitContextIds", defaultArg contextIds [] :> obj;
                    "FilterByUWAUnitLevelIds", (match levelIds with | Some(ids) -> ids.Length > 0 | None -> false) :> obj;
                    "UWAUnitLevelIds", defaultArg levelIds [] :> obj;

                ]
        printfn "parameters = %A" parameters
        connection.Query(
            @"
                SELECT
                    decision.decision_id,
                    decision.decision_date,
                    decision.exchange_university_id,
                    decision.exchange_university_name,
                    decision.exchange_unit_name,
                    decision.exchange_unit_code,
                    decision.exchange_unit_outline_href,
                    decision.uwa_unit_context_id,
                    decision.uwa_unit_context_name,
                    decision.uwa_unit_level_id,
                    decision.uwa_unit_level_name,
                    decision.uwa_unit_name,
                    decision.uwa_unit_code,
                    decision.approved
                FROM denormalized_unit_decisions AS decision
                WHERE 1=1
                    AND (@FilterByExchangeUniversities = 0 OR decision.exchange_university_id IN @ExchangeUniversities)
                    AND (@FilterByUWAUnitContextIds = 0 OR decision.uwa_unit_context_id IN @UWAUnitContextIds)
                    AND (@FilterByUWAUnitLevelIds = 0 OR decision.uwa_unit_level_id IN @UWAUnitLevelIds)
            ",
            dict parameters
        )

