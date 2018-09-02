import m from 'mithril'

import { StudentDetailsForm, StudentDetailsPowerForm } from './StudentDetailsForm.js'
import { ExchangeUniversityDetailsForm, ExchangeUniversityDetailsPowerForm } from './ExchangeUniversityDetailsForm.js'
import { UnitApprovalRequestItemForm, UnitApprovalRequestItemPowerForm } from './UnitApprovalRequestItemForm.js'


export default function ApplicationForm() {

    const state = {};

    function oninit({ attrs: { contextTypeOptions, electiveContextTypeOption, changeCallback }}) {
        state.studentDetailsForm = StudentDetailsPowerForm.new({
            onChange: handleChange.bind(this, changeCallback)
        });
        state.exchangeUniversityDetailsForm = ExchangeUniversityDetailsPowerForm.new({
            onChange: handleChange.bind(this, changeCallback)
        });
        state.approvalRequestForms = [];
        addNewApprovalRequestForm(contextTypeOptions, electiveContextTypeOption, handleChange.bind(this, changeCallback));
    }

    function handleChange(callback) {
        const isValid =
            state.studentDetailsForm.isValid() &&
            state.exchangeUniversityDetailsForm.isValid() &&
            !state.approvalRequestForms.some(({ form }) => !form.isValid());
        callback(
            {
                student: state.studentDetailsForm.getData(),
                exchangeUniversity: state.exchangeUniversityDetailsForm.getData(),
                approvalRequests: state.approvalRequestForms.map(({ form }) => form.getData())
            },
            isValid
        );
    }

    function view({ attrs: { contextTypeOptions, changeCallback, electiveContextTypeOption } }) {
        return (
            <div class="container">
                <div class="row">
                    <div class="col">
                        <StudentDetailsForm form={state.studentDetailsForm} />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col">
                        <ExchangeUniversityDetailsForm form={state.exchangeUniversityDetailsForm} />
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col">
                        <h3>Unit Approval Requests</h3>
                    </div>
                </div>
                <br />
                {state.approvalRequestForms.map(({ id, form }) => [
                    <div class="row">
                        <div class="col">
                            <UnitApprovalRequestItemForm
                                key={id}
                                form={form}
                                electiveContextTypeOption={electiveContextTypeOption}
                                ondelete={() => removeApprovalRequestForm(id, changeCallback)}
                            />
                        </div>
                    </div>,
                    <br />
                ])}
                <div class="row">
                    <div class="col">
                        <button type="button" class="btn btn-primary" onclick={() => addNewApprovalRequestForm(contextTypeOptions, electiveContextTypeOption, changeCallback)}>
                            Add Request
                        </button>
                    </div>
                </div>
            </div>
        )
    }

    function addNewApprovalRequestForm(contextTypeOptions, electiveContextTypeOption, changeCallback) {
        state.approvalRequestForms.push({
            id: state.approvalRequestForms.reduce((max, { id }) => Math.max(max, id), -1),
            form: new UnitApprovalRequestItemPowerForm({
                contextTypeOptions,
                electiveContextTypeOption,
                onChange: handleChange.bind(this, changeCallback)
            })
        });
        handleChange(changeCallback);
    }

    function removeApprovalRequestForm(formId, changeCallback) {
        const index = state.approvalRequestForms.findIndex(f => f.id === formId);
        if (index >= 0) {
            state.approvalRequestForms.splice(index, 1);
            handleChange(changeCallback);
        }
    }

    return { oninit, view };
}