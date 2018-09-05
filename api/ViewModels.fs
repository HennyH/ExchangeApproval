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

[<CLIMutable>]
type StudentDetailsVM = {
    email: string;
    degree: string;
    major: string;
    major2nd: string option;
}

[<CLIMutable>]
type SelectOption = {
    label: string;
    value: string;
}

[<CLIMutable>]
type ExchangeUniversityDetailsVM = {
    universityName: string;
    universityHomepage: string;
}

[<CLIMutable>]
type ApprovalRequestVM = {
    exchangeUnitName: string;
    exchangeUnitCode: string;
    exchangeUnitOutlineHref: string;
    contextType: SelectOption;
    uwaUnitName: string;
    uwaUnitCode: string;
}

[<CLIMutable>]
type StudentApplicationVM = {
    student: StudentDetailsVM;
    exchangeUniversity: ExchangeUniversityDetailsVM;
    approvalRequests: ApprovalRequestVM list;
}
