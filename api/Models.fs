namespace API

module Models =

    open System

    type UnitType =
        | Elective
        | Core
        | Complementary

    type University = string

    type UnitLevel =
        | One
        | Two
        | Three
        | FourPlus

    type UnitCode = string
    type UnitName = string

    type ExchangeUnitCode = UnitCode
    type ExchangeUnitName = UnitName
    type ExchangeUnitURL = string
    type ExchangeUnit = {
        name: ExchangeUnitCode;
        code: ExchangeUnitName;
        url: ExchangeUnitURL;
    }

    type UWAUnitCode = UnitCode
    type UWAUnitName = UnitName
    type UWAUnit = {
        name: UWAUnitName;
        code: UWAUnitCode;
        level: UnitLevel
    }

    type ElectiveUnitDecision = {
        decisionDate: DateTime;
        exchangeUnit: ExchangeUnit;
        approved: bool
    }

    type EquivalentUnitDecision = {
        decisionDate: DateTime;
        uwaUnit: UWAUnit;
        unitType: UnitType;
        exchangeUnit: ExchangeUnit
        approved: bool
    }

    type UnitDecision =
        | ElectiveUnitDecision of ElectiveUnitDecision
        | EquivalentUnitDecision of EquivalentUnitDecision