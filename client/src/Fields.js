import { Field, ValidationError } from 'powerform'

export class StudentEmailField extends Field {
    validate(value, allValues) {
        if (!value || !value.match(/^\d{8}$/)) {
            throw new ValidationError('Please enter a valid UWA email.');
        }
    }
}

export class StringField extends Field {
    constructor({ required, regex = null, regexErrorMessage = null, ...props }) {
        super(props);
        this.required = required;
        this.regex = regex;
        this.regexErrorMessage = regexErrorMessage;
    }

    validate(value, allValues) {
        if (this.required && !(value.trim())) {
            throw new ValidationError('This field is required.');
        }
        if (this.regex && value && !value.match(this.regex)) {
            throw new ValidationError(this.regexErrorMessage || 'Invalid value.');
        }
    }
}