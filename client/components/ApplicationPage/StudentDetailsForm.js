import m from 'mithril'
import { Form } from 'powerform'

import { Input, StudentEmailField, StringField } from 'FormHelpers'

export class StudentDetailsPowerForm extends Form {
    constructor({ ...config }) {
        super(config);
        this.email = StudentEmailField.new();
        this.degree = StringField.new({ required: true  });
        this.major = StringField.new({ required: true });
        this.major2nd = StringField.new({ required: false });
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export function StudentDetailsForm() {

    function view({ attrs: { form } }) {
        return (
            <form novalidate>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="email">UWA Email: </label>
                    <div class="input-group col-8">
                        <Input field={form.email} type="text" appendInputText="@student.uwa.edu.au" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">Degree: </label>
                    <div class="input-group col-8">
                        <Input field={form.degree} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">Major: </label>
                    <div class="input-group col-8">
                        <Input field={form.major} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">2nd Major*: </label>
                    <div class={"input-group col-8"}>
                        <Input field={form.major2nd} type="text" />
                    </div>
                </div>
            </form>
        )
    }

    return { view }
}