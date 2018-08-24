namespace API.Data.Models

open System

type UnitContextDTO = Elective = 1 | Core = 2 | Complementary = 3

type UniversityDTO = {
    id: int64;
    name: string
}

type UnitDTO = {
    id: int64;
    name: string;
    code: string option;
    university: UniversityDTO
}

type UnitDecision = {
    id: int64;
    date: DateTime;
    context: UnitContextDTO;
    uwaUnit: Unit option;
    exchangeUnit: Unit;
    approved: bool;
}