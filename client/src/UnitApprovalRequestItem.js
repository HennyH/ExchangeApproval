import m from 'mithril'
import { Form } from 'powerform'

import Input from './FormHelpers/Input.js'
import Select from './FormHelpers/Select'
import { OptionsField, StringField } from './FormHelpers/Fields.js'
import Styles from './UnitApprovalRequestItem.css'

class UnitApprovalRequestItemPowerForm extends Form {
    constructor({ contextTypeOptions } = {}) {
        super()
        this.exchangeUnitName = StringField.new({ required: true });
        this.exchangeUnitCode = StringField.new({ required: true });
        this.exchangeUnitOutlineHref = StringField.new({
            required: true,
            regex: /^https?\:\/\//,
            regexErrorMessage: 'Enter a URL of the from https://...'
        });
        this.contextType = OptionsField.new({ options: contextTypeOptions });
        this.uwaUnitName = StringField.new({ required: true });
        this.uwaUnitCode = StringField.new({ required: true });
    }
}

export default function UnitApprovalRequestItem() {

    const state = {};

    function oninit() {
        state.form = new UnitApprovalRequestItemPowerForm({
            contextTypeOptions: [
                { value: '1', text: 'Elective' },
                { value: '2', text: 'Core'},
                { value: '3', text: 'Complementary'}
            ]
        });
    }

    function view() {
        const {
            exchangeUnitName, exchangeUnitCode, exchangeUnitOutlineHref,
            contextType, uwaUnitName, uwaUnitCode
        } = state.form;
        const isElective = contextType.getData() && contextType.getData().value === '1';
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
                                <Input field={exchangeUnitName} type="text" />
                            </div>
                            <div class="col">
                                <label for="exch-unit-code">Unit Code:</label>
                                <Input field={exchangeUnitCode} type="text" />
                            </div>
                            <div class="col">
                                <label for="exch-unit-href">Unit Outline Link:</label>
                                <Input field={exchangeUnitOutlineHref} type="text" />
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
                                    field={contextType}
                                    options={contextType.config.options}
                                />
                            </div>
                            {isElective
                                ? <div />
                                : ([
                                    <div class="col-4">
                                        <label for="uwa-unit-name">Unit Name:</label>
                                        <Input field={uwaUnitName} type="text" />
                                    </div>,
                                    <div class="col-4">
                                        <label for="uwa-unit-code">Unit Code:</label>,
                                        <Input field={uwaUnitCode} type="text" />
                                    </div>
                                ])
                            }
                        </div>
                    </div>
                </div>
            </form>
        )
    }

    return { oninit, view };
}