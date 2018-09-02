import m from 'mithril'
import classNames from 'classnames'

import { StudentDetailsForm, StudentDetailsPowerForm } from './StudentDetailsForm.js'
import { ExchangeUniversityDetailsForm, ExchangeUniversityDetailsPowerForm } from './ExchangeUniversityDetailsForm.js'
import { UnitApprovalRequestItemForm, UnitApprovalRequestItemPowerForm } from './UnitApprovalRequestItemForm.js'


export default function ApplicationForm() {

    const state = {
        scrollToLastRequest: false
    };

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
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Student Details</div>
                    <div class="card-body">
                        <StudentDetailsForm form={state.studentDetailsForm} />
                    </div>
                </div>
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Exchange University Details</div>
                    <div class="card-body">
                    <ExchangeUniversityDetailsForm form={state.exchangeUniversityDetailsForm} />
                    </div>
                </div>
                <div class="card bg-light mt-3 mb-3">
                    <div class="card-header">Unit Approval Requests</div>
                    <div class="card-body">
                        <button type="button" class="mb-1 btn btn-link" onclick={scrollToLastRequestItem}>
                            Jump To Bottom
                        </button>
                        {state.approvalRequestForms.map(({ id, form }, i) => (
                            <div class={classNames("card bg-light mt-1", i == state.approvalRequestForms.length - 1 ? "mb-1" : "mb-2")}>
                                <div class="card-body">
                                    <UnitApprovalRequestItemForm
                                        class="request-item-form"
                                        key={id}
                                        form={form}
                                        electiveContextTypeOption={electiveContextTypeOption}
                                        ondelete={() => removeApprovalRequestForm(id, changeCallback)}
                                    />
                                </div>
                            </div>
                        ))}
                        <button type="button" class="mt-3 mr-3 btn btn-primary" onclick={() => addNewApprovalRequestForm(contextTypeOptions, electiveContextTypeOption, changeCallback)}>
                                Add Request
                        </button>
                        <button type="button" class="mt-3 btn btn-link" onclick={scrollToFirstRequestItem}>
                                Jump To Top
                        </button>
                    </div>
                </div>
            </div>
        )
    }

    function onupdate() {
        if (state.scrollToLastRequest) {
            state.scrollToLastRequest = false;
            scrollToLastRequestItem();
        }
    }

    function scrollToLastRequestItem() {
        const $lastItemForm = $('.request-item-form').last()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: topOffset,
            behavior: 'smooth'
        });
    }

    function scrollToFirstRequestItem() {
        const $lastItemForm = $('.request-item-form').first()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: window.screenY - topOffset,
            behavior: 'smooth'
        });
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
        state.scrollToLastRequest = true;
    }

    function removeApprovalRequestForm(formId, changeCallback) {
        const index = state.approvalRequestForms.findIndex(f => f.id === formId);
        if (index >= 0) {
            state.approvalRequestForms.splice(index, 1);
            handleChange(changeCallback);
        }
    }

    return { oninit, view, onupdate };
}