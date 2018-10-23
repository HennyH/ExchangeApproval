import m from 'mithril'
import { FormListField } from './FormHelpers/Fields';

export const ModalState = {
    DownloadModal: {
        visible: false,
        show: () => {
            ModalState.DownloadModal.visible = true;
            ModalState.onHide = () => {ModalState.DownloadModal.visible = false}
            m.redraw();
        },
    },
    ApplicationModal: {
        selectedApplication: null,
        show: (decision) => {
            ModalState.ApplicationModal.selectedApplication = decision;
            ModalState.onHide = () => {ModalState.ApplicationModal.selectedApplication = null}
            m.redraw();
        }
    },
    onHide: () => {},
}

export const CartData = {
    handlers: [],
    items: [
        {"unitSetId":548,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}},
        {"unitSetId":549,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}}
    ]
}



// EMAIL DATA + CLIPBOARD LOGIC AND DATA STRUCTURE
export const EmailData = {
    Form: null,
    To: null,
    Name: null,
    Major: null,
    Subject: null,
    University: null,
    Approvals: null,
    mailString: null,
    Message: null,
    PopulateFields: function() {
        var formData = EmailData.Form.getData();
        EmailData.To = (formData.studentDetailsForm.email ? formData.studentDetailsForm.email : "");
        EmailData.Major = (formData.studentDetailsForm.Major ? formData.studentDetailsForm.Major : "[_STUDENT_MAJOR_]" );
        EmailData.Name = (formData.studentDetailsForm.name ? formData.studentDetailsForm.name : "[_STUDENT_NAME_]");
        EmailData.University = (formData.exchangeUniversityForm.universityName ? formData.exchangeUniversityForm.universityName : "[_EXCHANGE_UNIVERSITY_]");
    },

    Student: {
        GenerateMessage: function() {
            var unitSets = EmailData.Form.getData().unitSetForms;
            EmailData.PopulateFields();
            EmailData.Subject = "Exchange Application Update",
            EmailData.Approvals = processUnitSets(unitSets);
            EmailData.Message = studentMessage(EmailData);
            EmailData.mailString = ('?subject=' + encodeURIComponent(EmailData.Subject) + '&body=' + encodeURIComponent(EmailData.Message));
        },
        SendEmail: function() {
            EmailData.Student.GenerateMessage();
            window.location.href='mailto:' + EmailData.mailString;
        },
        CopyText: function() {
            EmailData.Student.GenerateMessage();
            copyToClipboard(EmailData.Message);
        },
    },
    Equivalence: {
        GenerateMessage: function(formIndex) {
            var unitSets = EmailData.Form.getData().unitSetForms;
            EmailData.PopulateFields();
            EmailData.Subject = "Exchange Units For Approval",
            EmailData.Approvals = processUnitSetEquivalence(unitSets[formIndex]);
            EmailData.Message = equivalenceMessage(EmailData);
            EmailData.mailString = ('?subject=' + encodeURIComponent(EmailData.Subject) + '&body=' + encodeURIComponent(EmailData.Message));
        },
        SendEmail: function(formIndex) {
            EmailData.Equivalence.GenerateMessage(formIndex);
            window.location.href='mailto:' + EmailData.mailString;
        },
        CopyText: function(formIndex) {
            EmailData.Equivalence.GenerateMessage(formIndex);
            copyToClipboard(EmailData.Message);
        }
    }
}

function copyToClipboard(text) {
    navigator.clipboard.writeText(text).then(function() {
        alert("Copied to clipboard: \n\n" + text);
    }, function() {
        alert("Failed to copy to clipboard! CTR+C the text below:\n\n" + text);
    });
}

function processUnitSets(form) {
    var approvalsString = "";

    for (var i = 0; i < form.length; i++ ) {
        approvalsString = approvalsString + processUnitSet(form[i]);
    }

    // return forms.reduce((sb, f) => sb + processUnitSet(f), "")
    return approvalsString;
}


function processUnitSet(unitSet) {
    var uwaUnits;
    var exchangeUnits;

    for (var j = 0; j < unitSet.uwaUnitsForm.length; j++) {
        uwaUnits = printUnitLine(unitSet.uwaUnitsForm[j], j)
    }

    for (var k = 0; k < unitSet.exchangeUnitsForm.length; k++) {
        exchangeUnits = printUnitLine(unitSet.exchangeUnitsForm[k], k)
    }

    return(
    `UWA Units:\t\t\t${(uwaUnits === null ? "N/A": uwaUnits)}
    Exchange Units:\t\t${exchangeUnits}
    Equivalence Approval:\t${unitSet.staffApprovalForm.isEquivalent.label}
    Contextual Approval:\t${unitSet.staffApprovalForm.isContextuallyApproved.label}

    `)
}

function printUnitLine(unit, index) {
    var unitText = (index == 0 ? "" : ", ");
    unitText += unit.unitCode + ": " + unit.unitName;
    return(unitText);
}

function processUnitSetEquivalence(unitSet) {
    var uwaUnits;
    var exchangeUnits;

    for (var j = 0; j < unitSet.uwaUnitsForm.length; j++) {
        uwaUnits = printUnitLine(unitSet.uwaUnitsForm[j], j)
    }

    for (var k = 0; k < unitSet.exchangeUnitsForm.length; k++) {
        exchangeUnits = printUnitLineEquivalence(unitSet.exchangeUnitsForm[k], k)
    }

    return(
    `UWA Units:\t\t\t${(uwaUnits === null ? "N/A": uwaUnits)}
    Exchange Units:\t\t${exchangeUnits}

    `)
}

function printUnitLineEquivalence(unit, index) {
    var unitText = (index == 0 ? "" : ", ");
    unitText += unit.unitCode + ": " + unit.unitName + " (" + unit.unitHref + ")";
    return(unitText);
}

function studentMessage(EmailData) {
    return (
`Hi ${EmailData.Name},

I hope this email finds you well.\n\nI am writing to update you on the status of your application for exchange at ${EmailData.University}. Exchange units need both equivalence and contextual approval. Please see the approval status below.\n\n\t${EmailData.Approvals}
Regards,
`
)}

function equivalenceMessage(EmailData) {
    return(
`Hi,

I hope this email finds you well.

I am writing to kindly request your assistance with ${EmailData.Name}'s <${EmailData.To}> exchange unit approvals for ${EmailData.University}.

${EmailData.Name} is enrolled in ${EmailData.Major} and is looking for approval on the following units:\n\n\t${EmailData.Approvals}
Regards,
`
)}