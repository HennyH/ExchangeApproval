import m from 'mithril'

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

export const ApplicationData = {
	hasSubmitted: false,
	pushApplication: () => {},
	getApplication: () => {}
}

export const CartData = {
	handlers: [],
	items: [
        {"unitSetId":548,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}},
        {"unitSetId":549,"lastUpdatedAt":"2018-09-20T00:00:00","approved":true,"exchangeUniversityName":"University Of Rochester","exchangeUniversityHref":"https://university.com","exchangeUnits":[{"universityName":"University Of Rochester","universityHref":"https://university.com","unitCode":"CHE 116","unitName":"Numerical Methods And Stat","unitHref":"https://unit.com"}],"uwaUnits":[{"universityName":"University of Western Australia","universityHref":"https://uwa.edu.au","unitCode":"L2 ELECTIVE","unitName":"Knowledge Story Art","unitHref":"https://uwa.edu.au"}],"equivalentUnitLevel":{"label":"Two","value":2,"selected":true}}
    ]
}

export const UnitSearchData = {
    filters: {
        loading: false,
        options: null,
        fetch: () => {
            UnitSearchData.filters.loading = true;
            m.request({
                method: "GET",
                url: "/api/requests/filters"
            }).then(options => {
                UnitSearchData.filters.options = options;
                UnitSearchData.filters.loading = false;
            });
        }
    },
    decisions: {
        loading: false,
        list: [],
        fetch: ({ universityNames = [], uwaContextTypes = [], uwaUnitLevels = [] } = {}) => {
            UnitSearchData.decisions.loading = true;
            const qs = m.buildQueryString({
                universityNames,
                uwaContextTypes,
                uwaUnitLevels
            });
            m.request({
                method: "GET",
                url: `/api/requests/decisions?${qs}`
            }).then(items => {
                UnitSearchData.decisions.list = items;
                UnitSearchData.decisions.loading = false;
            });
        }
	},
	hasSearched: false
}

export const EmailData = {
	GenerateMessage: function(form) {
		EmailData.To = form.studentDetailsForm.email;
		EmailData.Name = form.studentDetailsForm.name;
		EmailData.University = form.exchangeUniversityForm.universityName;
		EmailData.Approvals = processUnitSets(form.unitSetForms);
		EmailData.Message = 
		`Hi ${EmailData.Name},

		I hope this email finds you well. I am writing to update you on the status of your application for exchange at ${this.University}. Exchange units need both equivalence and contextual approval. Please see the approval status below.\n\n\t${EmailData.Approvals}\nRegards,
		`,
		EmailData.mailString = ('?subject=' + encodeURIComponent(EmailData.Subject) + '&body=' + encodeURIComponent(EmailData.Message));
		},
	SendEmail: function(form) {
		EmailData.GenerateMessage(form);
		window.location.href='mailto:' + EmailData.To + EmailData.mailString;
	},
	CopyText: function(form) {
		EmailData.GenerateMessage(form);
		navigator.clipboard.writeText(EmailData.Message).then(function() {
			alert("Copied to clipboard: \n\n" + EmailData.Message);
		}, function() {
			alert("Failed to copy to clipboard");
		});
	},
	To: null,
	Name: null,
	Subject: "An Update On Your Exchange Application",
	University: null,
	Approvals: null,
	mailString: null,
	Message: "turkey"	
}

function processUnitSets(form) {
	var ApprovalsString = "";

	for (var i = 0; i < form.length; i++ ) {
		ApprovalsString = ApprovalsString + processUnitSet(form[i]);
	}
	return ApprovalsString;
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