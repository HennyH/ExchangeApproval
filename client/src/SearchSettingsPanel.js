import m from 'mithril';
import classNames from 'classnames';
import 'select2-theme-bootstrap4/dist/select2-bootstrap.min.css'

import CheckboxGroup from './CheckboxGroup';
import Styles from './SearchSettingsPanel.css';

const UPDATE_APPROVAL_TYPES = "UPDATE_APPROVAL_TYPES";
const UPDATE_UNIT_LEVELS = "UPDATE_UNIT_LEVELS";
const UPDATE_UNIVERSITIES = "UPDATE_UNIVERSITIES";

function reducer(state, action, data) {
    switch (action) {
        case UPDATE_APPROVAL_TYPES:
            return { ...state, approvalTypes: data };
        case UPDATE_UNIT_LEVELS:
            return { ...state, unitLevels: data };
        case UPDATE_UNIVERSITIES:
            return { ...state, exchangeUniversities: data };
        default:
            return state;
    }
}

export default function SearchSettingsPanel() {

    let state = {};

    function handleApprovalTypesChange(toggles) {
        state = reducer(state, UPDATE_APPROVAL_TYPES, toggles);
    }

    function handleUnitLevelsChange(toggles) {
        state = reducer(state, UPDATE_UNIT_LEVELS, toggles);
    }

    function handleUniversitiesChange(event) {
        const selectedValues = Array.from(event.target.selectedOptions).map(({ value}) => value);
        state = reducer(state, UPDATE_UNIVERSITIES, selectedValues);
    }

    function handleSubmit(onSubmit, event) {
        event.preventDefault();
        event.stopPropagation();
        onSubmit(state);
    }

    function view({ attrs: { handleSubmit: onSubmit, levelOptions, contextOptions }}) {
        return (
            <form onsubmit={handleSubmit.bind(this, onSubmit)}>
                <fieldset class={Styles.fieldset}>
                    <legend class={Styles.legend}>Search Settings</legend>
                    <div class="row">
                        <div class="col-6">
                            <label for="universities">Exchange Universitys</label>
                            <select class={classNames("form-control", Styles.universitySelect)}
                                    id="universities-select"
                                    name="universities"
                                    onchange={handleUniversitiesChange}></select>
                        </div>
                        <div class="col">
                            <label>Approval Type(s)</label>
                            <CheckboxGroup name="approval-types"
                                            options={contextOptions}
                                            handleUpdate={handleApprovalTypesChange}
                            />
                        </div>
                        <div class="col">
                            <label>Unit Level(s)</label>
                            <CheckboxGroup name="unit-level"
                                            options={levelOptions}
                                            handleUpdate={handleUnitLevelsChange}
                            />
                        </div>
                        <div class="col">
                            <button type="submit" class="btn btn-primary">
                                Search
                            </button>
                        </div>
                    </div>
                </fieldset>
            </form>
        );
    }

    function oncreate(vnode) {
        $("#universities-select").select2({
            multiple: true,
            width: 'resolve',
            placeholder: 'Select universities to filter to...',
            data: vnode.attrs.exchangeUniversities
        });

        const $submitButton = $(vnode.dom).find('button[type="submit"]');
        $submitButton.css('margin-top', $submitButton.parent().height() - $submitButton.height());
        $submitButton.css('margin-left', $submitButton.parent().width() - $submitButton.width());
    }

    return { view, oncreate };
}