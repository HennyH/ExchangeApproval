import { Field, ValidationError } from 'powerform'

export class StudentEmailField extends Field {
    validate(value, allValues) {
        if (!value || !value.match(/^\d{8}$/)) {
            throw new ValidationError('Please enter a valid UWA email.');
        }
    }
}

export class StringField extends Field {
    validate(value, allValues) {
        // console.log('validating', this.fieldName, value);
        const required = this.config.required ||
                         (this.config.requiredIf && this.config.requiredIf(value, allValues));
        // console.log('field ', this.fieldName, 'was required? = ', required, this.config.required, !!this.config.requiredIf)
        if (required && (!value || !value.trim())) {
            throw new ValidationError('This field is required.');
        }
        if (this.config.regex && value && !value.match(this.config.regex)) {
            throw new ValidationError(this.config.regexErrorMessage || 'Invalid value.');
        }
    }
}

export class OptionsField extends Field {
    constructor(config) {
        config = config || {}
        super({
            default: config.default || (config.multiple ? [] : null),
            ...config
        });
        /* When we initialize an options field which will be backed by some
         * type of <select /> element, we need to make sure the field's current
         * value matches the default state that the <select /> element
         * will have. For example a non-multiple select by default will choose
         * either the first element that has the selected attr set OR the first
         * option.
         */
        if (config.options && config.options.length > 0) {
            if (config.multiple) {
                this.setData(config.options.filter(o => o.selected))
            } else {
                const selected = config.options.find(o => o.selected) || config.options[0];
                this.setData(selected);
            }

        }
    }

    validate() {
        return !this.config.required || this.value;
    }

    setData(value) {
        if (value instanceof HTMLCollection) {
            value = Array.from(value);
        }
        /* We need to normalize first because behind the scenes powerform
         * uses JSON.stringify on our value. If we are setting data with a
         * HTMLOptionElement we are in trouble because it is recursive and
         * so doesn't play well with this approach...
         */
        let normalizedValue = value;
        if (value instanceof HTMLOptionElement) {
            normalizedValue = {
                label: value.label,
                value: value.value,
                selected: value.selected
            }
        } if (Array.isArray(value)) {
            normalizedValue = value.map(
                ({ label, value, selected }) => ({ label, value, selected })
            );
        }
        super.setData(normalizedValue);
    }

    modify(newOption, previousOption) {
        if (!newOption) {
            return previousOption;
        }

        if (!this.config.multiple) {
            return (!previousOption || newOption.value !== previousOption.value)
                ? newOption
                : null;
        }

        if (Array.isArray(newOption)) {
            return newOption;
        }

        return [
            ...(previousOption || []),
            newOption
        ]
        /* Dedupe */
        .filter((o, i, self) => self.findIndex(x => x.value == o.value) === i)
        /* Remove ones that were just de-selected */
        .filter(o => newOption.selected || o.value != newOption.value);
    }
}