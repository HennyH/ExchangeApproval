namespace API.Data.Models

open System

[<CLIMutable>]
type UnitContextDTO = {
    id: int32;
    name: string;
}

[<CLIMutable>]
type UnitLevelDTO = {
    id: int32;
    name: string;
}

[<CLIMutable>]
type UniversityDTO = {
    id: int32;
    name: string
}

[<CLIMutable>]
type UnitDTO = {
    id: int32;
    name: string;
    code: string option;
    university: UniversityDTO
}

[<CLIMutable>]
type UnitDecisionDTO = {
    decisionId: int32;
    decisionDate: DateTime;
    exchangeUniversityId: int32;
    exchangeUniversityName: string;
    exchangeUnitName: string;
    exchangeUnitCode: string option;
    exchangeUnitOutlineHref: string;
    uwaUnitName: string option;
    uwaUnitCode: string option;
    uwaUnitLevelId: int32 option;
    uwaUnitLevelName: string option;
    unitContextId: int32;
    unitContextName: string;
    approved: int32;
}
