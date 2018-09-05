import m from 'mithril'
import { Form } from 'powerform'

import { Input, Select, OptionsField, StringField }  from 'FormHelpers'
import Styles from './UnitApprovalRequestItemForm.css'

export class UnitApprovalRequestItemPowerForm extends Form {
    constructor({ contextTypeOptions, electiveContextTypeOption, ...config }) {
        super(config);
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
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export function UnitApprovalRequestItemForm() {

    function view({ attrs: { form, readonly, electiveContextTypeOption, ondelete, ...otherAttrs }}) {
        const isElective =
            form.contextType.getData() &&
            form.contextType.getData().value === electiveContextTypeOption.value;
        return (
            <form novalidate {...otherAttrs}>
                <div class="form-row">
                    <div class="col">
                        <div class="form-row">
                            <div class="col">
                                <h6>Exchane Unit Details</h6>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col">
                                <label class="col-form-label-sm" for="exch-unit-code">Unit Name:</label>
                                <Input readonly={readonly} field={form.exchangeUnitName} type="text" />
                            </div>
                            <div class="col">
                                <label class="col-form-label-sm"  for="exch-unit-code">Unit Code:</label>
                                <Input readonly={readonly} field={form.exchangeUnitCode} type="text" />
                            </div>
                            <div class="col">
                                <label class="col-form-label-sm" for="exch-unit-href">Unit Outline Link:</label>
                                <Input readonly={readonly} field={form.exchangeUnitOutlineHref} type="text" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="form-row">
                    <div class="col">
                        <div class="form-row">
                            <div class="col">
                                <h6>UWA Unit Details</h6>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="col-4">
                                <label class="form-control-sm" class="col-form-label-sm" for="contextType">Unit Type:</label>
                                <Select
                                    disabled={readonly}
                                    field={form.contextType}
                                    options={form.contextType.config.options}
                                />
                            </div>
                            {isElective
                                ? <div />
                                : ([
                                    <div class="col-4">
                                        <label class="col-form-label-sm" for="uwa-unit-name">Unit Name:</label>
                                        <Input readonly={readonly} field={form.uwaUnitName} type="text" />
                                    </div>,
                                    <div class="col-4">
                                        <label class="col-form-label-sm" for="uwa-unit-code">Unit Code:</label>,
                                        <Input readonly={readonly} field={form.uwaUnitCode} type="text" />
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