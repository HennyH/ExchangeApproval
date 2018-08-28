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
        if (this.config.required && !(value.trim())) {
            throw new ValidationError('This field is required.');
        }
        if (this.config.regex && value && !value.match(this.config.regex)) {
            throw new ValidationError(this.config.regexErrorMessage || 'Invalid value.');
        }
    }
}

export class OptionsField extends Field {
    constructor(config) {
        super({
            default: config.multiple ? [] : null,
            ...config
        });
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

    modify(newOption, previousValue) {
        if (!newOption) {
            return previousValue;
        }
        if (!this.config.multiple) {
            return newOption.selected ? newOption : null;
        } else {
            if (Array.isArray(newOption)) {
                return newOption;
            } else {
                return [
                    ...(previousValue || []),
                    newOption
                ]
                /* Dedupe */
                .filter((o, i, self) => self.findIndex(x => x.value == o.value) === i)
                /* Remove ones that were just de-selected */
                .filter(o => newOption.selected || o.value != newOption.value);
            }
        }
    }
}