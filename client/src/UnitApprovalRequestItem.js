import m from 'mithril'
import { Form } from 'powerform'

import Input from './FormHelpers/Input.js'
import Select2 from './FormHelpers/Select2'
import { OptionsField, StringField } from './FormHelpers/Fields.js'

class UnitApprovalRequestItemPowerForm extends Form {
    exchangeUnitName = StringField.new({ required: true });
    exchangeUnitCode = StringField.new({ required: true });
    exchangeUnitOutlineHref = StringField.new({
        required: true,
        regex: /^https?\:\/\//,
        regexErrorMessage: 'Enter a URL of the from https://...'
    });
    contextType = OptionsField.new();
    uwaUnitName = StringField.new({ required: true });
    uwaUnitCode = StringField.new({ required: true });
}

export default function UnitApprovalRequestItem() {

    const state = {};

    function oninit() {
        state.form = UnitApprovalRequestItemPowerForm.new();
    }

    function view() {
        const {
            exchangeUnitName, exchangeUnitCode, exchangeUnitOutlineHref,
            contextType, uwaUnitName, uwaUnitCode
        } = state.form;
        const maybeUwaFields = (contextType.getData() && contextType.getData().value !== '-1')
            ? [
                <label for="uwa-unit-name">for a UWA unit with name</label>,
                <Input field={uwaUnitName} type="text" />,
                <label for="uwa-unit-code">whose unit code is</label>,
                <Input field={uwaUnitCode} type="text" />,
            ]
            : [];
        return (
            <form class="form-inline">
                <label for="exch-unit-name">Exchange unit with name</label>
                <Input field={exchangeUnitName} type="text" />
                <label for="exch-unit-code">whose unit code is</label>
                <Input field={exchangeUnitCode} type="text" />
                <label for="exch-unit-href">and whose outline can be found at</label>
                <Input field={exchangeUnitOutlineHref} type="text" />
                <label for="contextType">as an</label>
                <Select2
                    field={contextType}
                    config={{
                        width: 'resolve',
                        data: [
                            { id: 'foo', text: '1'},
                            { id: 'foo', text: '2'}
                        ]
                    }}
                />
                {maybeUwaFields}
            </form>
        )
    }

    return { oninit, view };
}