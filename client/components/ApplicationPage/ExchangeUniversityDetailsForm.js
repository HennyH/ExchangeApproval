import m from 'mithril'
import { Form } from 'powerform'

import { Input, StringField } from 'FormHelpers'

export class ExchangeUniversityDetailsPowerForm extends Form {
    constructor(config) {
        super();
        this.universityName = StringField.new({ required: true });
        this.universityHomepage = StringField.new({
            required: true,
            regex: /^https?\:\/\//,
            regexErrorMessage: 'Enter a URL of the from https://...'
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export function ExchangeUniversityDetailsForm() {

    function view({ attrs: { form } }) {
        return (
            <form novalidate>
                <div class="form-group row">
                    <label class="col-form-label col-4" for="email">Exchange University Name: </label>
                    <div class="input-group col-8">
                        <Input field={form.universityName} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-4" for="email">Exchange University Homepage: </label>
                    <div class="input-group col-8">
                        <Input field={form.universityHomepage} type="text" />
                    </div>
                </div>
            </form>
        )
    }

    return { view }
}