import m from 'mithril'
import { Form } from 'powerform'

import Input from './FormHelpers/Input.js'
import { StudentEmailField, StringField } from './FormHelpers/Fields.js'


class ApplicationPowerForm extends Form {
    email = StudentEmailField.new();
    degree = StringField.new({ required: true  });
    major = StringField.new({ required: true });
    major2nd = StringField.new({ required: false });
    universityName = StringField.new({ required: true });
    universityHomepage = StringField.new({
        required: true,
        regex: /^https?\:\/\//,
        regexErrorMessage: 'Enter a URL of the from https://...'
    })
}


export default function ApplicationForm() {

    const state = {};

    function oninit() {
        state.form = ApplicationPowerForm.new();
    }

    function view() {
        const {
            email, degree, major, major2nd,
            universityName, universityHomepage
        } = state.form;
        return (
            <form novalidate>
                <div class="form-group row">
                    <div class="col-12">
                        <h3>Student Details</h3>
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="email">UWA Email: </label>
                    <div class="input-group col-8">
                        <Input field={email} type="text" appendInputText="@student.uwa.edu.au" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">Degree: </label>
                    <div class="input-group col-8">
                        <Input field={degree} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">Major: </label>
                    <div class="input-group col-8">
                        <Input field={major} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-2" for="degree">2nd Major*: </label>
                    <div class={"input-group col-8"}>
                        <Input field={major2nd} type="text" />
                    </div>
                </div>
                <hr />
                <div class="form-group row">
                    <div class="col-12">
                        <h3>University Details</h3>
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-4" for="email">Exchange University Name: </label>
                    <div class="input-group col-8">
                        <Input field={universityName} type="text" />
                    </div>
                </div>
                <div class="form-group row">
                    <label class="col-form-label col-4" for="email">Exchange University Homepage: </label>
                    <div class="input-group col-8">
                        <Input field={universityHomepage} type="text" />
                    </div>
                </div>
            </form>
        )
    }

    return { oninit, view };
}