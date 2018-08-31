import m from 'mithril'
import { Form } from 'powerform'

import Input from './FormHelpers/Input.js'
import Select from './FormHelpers/Select.js'
import { OptionsField, StringField } from './FormHelpers/Fields.js'
import Styles from './UnitApprovalRequestItemForm.css'

export class UnitApprovalRequestItemPowerForm extends Form {
    constructor({ contextTypeOptions, electiveContextTypeOption, ...config }) {
        super();
        this.exchangeUnitName = StringField.new({ required: true });
        this.exchangeUnitCode = StringField.new({ required: true });
        this.exchangeUnitOutlineHref = StringField.new({
            required: true,
            regex: /^https?\:\/\//,
            regexErrorMessage: 'Enter a URL of the from https://...'
        });
        this.contextType = OptionsField.new({ options: contextTypeOptions });
        this.uwaUnitName = StringField.new({
            requiredIf: (val, allValues) => allValues.contextType.value !== electiveContextTypeOption.value
        });
        this.uwaUnitCode = StringField.new({
            requiredIf: (val, allValues) => allValues.contextType.value !== electiveContextTypeOption.value
        });
        Form.new.apply(() => this, config);
        this.config = config;
    }
}

export function UnitApprovalRequestItemForm() {

    function view({ attrs: { form, electiveContextTypeOption, ondelete }}) {
        const isElective =
            form.contextType.getData() &&
            form.contextType.getData().value === electiveContextTypeOption.value;
        return (
            <form novalidate class={Styles.requestContainer}>
                <div class="form-row">
                    <div class="col">
                        <div class="form-row">
                            <div class="col">
                                <h5>Exchane Unit Details</h5>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <label for="exch-unit-code">Unit Name:</label>
                                <Input field={form.exchangeUnitName} type="text" />
                            </div>
                            <div class="col">
                                <label for="exch-unit-code">Unit Code:</label>
                                <Input field={form.exchangeUnitCode} type="text" />
                            </div>
                            <div class="col">
                                <label for="exch-unit-href">Unit Outline Link:</label>
                                <Input field={form.exchangeUnitOutlineHref} type="text" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="col">
                        <div class="form-row">
                            <div class="col">
                                <h5>UWA Unit Details</h5>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-4">
                                <label for="contextType">Unit Type:</label>
                                <Select
                                    field={form.contextType}
                                    options={form.contextType.config.options}
                                />
                            </div>
                            {isElective
                                ? <div />
                                : ([
                                    <div class="col-4">
                                        <label for="uwa-unit-name">Unit Name:</label>
                                        <Input field={form.uwaUnitName} type="text" />
                                    </div>,
                                    <div class="col-4">
                                        <label for="uwa-unit-code">Unit Code:</label>,
                                        <Input field={form.uwaUnitCode} type="text" />
                                    </div>
                                ])
                            }
                        </div>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="col">
                        <button type="button" class="btn btn-danger" onclick={ondelete}>
                            Delete
                        </button>
                    </div>
                </div>
            </form>
        )
    }

    return { view };
}