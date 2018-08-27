namespace API.Data.ViewModels

open API.Data.Models

[<CLIMutable>]
type UnitLevelVM = UnitLevelDTO

[<CLIMutable>]
type UnitContextVM = UnitContextDTO

[<CLIMutable>]
type UnitDecisionVM = UnitDecisionDTO

[<CLIMutable>]
type UniversityVM = UniversityDTO

[<CLIMutable>]
type FilterOptionsVM = {
    levelOptions: UnitLevelVM list;
    contextOptions: UnitContextVM list;
    exchangeUniversities: UniversityVM list;
}


