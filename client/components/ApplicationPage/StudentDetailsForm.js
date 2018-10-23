import m from 'mithril'
import { Form } from 'powerform'
import classNames from 'classnames'
import { Input, Select, OptionsField, StudentEmailField, StringField } from 'FormHelpers'

export class StudentDetailsPowerForm extends Form {
    constructor({ studentOfficeOptions, ...config }) {
		super(config);
		this.name = StringField.new({ required: true });
        this.email = StudentEmailField.new({ required: true });
        this.degree = StringField.new({ required: true  });
        this.major = StringField.new({ required: true });
        this.major2nd = StringField.new({ required: false });
        this.studentOffice = OptionsField.new({
			multiple: false,
            options: [
                ...studentOfficeOptions
            ],
            required: true
        });
        Form.new.call(() => this, config);
        this.config = config;
    }
}

export function StudentDetailsForm() {

    function view({ attrs: { form, staffView } }) {

        return (
            <form novalidate>
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="email">Name: </label>
                    <div class="input-group col-8">
                        <Input field={form.name} placeholder="Full Name" type="text" readOnly = {staffView} />
                    </div>
                </div>
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="email">UWA Email: </label>
                    <div class="input-group col-8">
                        <Input field={form.email} type="text" placeholder="Student Number" appendInputText="@student.uwa.edu.au" readOnly = {staffView} />
                    </div>
                </div>
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="degree">Degree: </label>
                    <div class="input-group col-8">
                        <Input field={form.degree} placeholder="Degree" type="text" readOnly = {staffView}/>
                    </div>
                </div>
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="major">Major: </label>
                    <div class="input-group col-8">
                        <Input field={form.major} placeholder="First Major" type="text" readOnly = {staffView} />
                    </div>
                </div>
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="2ndMajor">2nd Major*: </label>
                    <div class={"input-group col-8"}>
                        <Input field={form.major2nd} placeholder="Second Major (optional)" type="text" readOnly = {staffView} />
                    </div>
                </div>
                {!staffView ? 
                <div class="form-group row mx-1">
                    <label class="col-form-label col-3" for="studentOffice">Student Office: </label>
                    <div class="input-group col-8">
                        <Select
                            field={form.studentOffice}
                        />
                    </div>
                </div>
                : <div/>
                }
            </form>
        )
    }

    return { view }
}