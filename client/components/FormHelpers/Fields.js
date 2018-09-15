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
        const required = this.config.required ||
                         (this.config.requiredIf && this.config.requiredIf(value, allValues));
        if (required && (!value || !value.trim())) {
            throw new ValidationError('This field is required.');
        }
        if (this.config.regex && value && !value.match(this.config.regex)) {
            throw new ValidationError(this.config.regexErrorMessage || 'Invalid value.');
        }
    }
}

export class IntegerField extends Field {
    validate(value, allValues) {
        const required = this.config.required ||
                         (this.config.requiredIf && this.config.requiredIf(value, allValues));
        if (required && (value === null || value === undefined)) {
            throw new ValidationError('This field is required.');
        }
    }
}

export class FormListField extends Field {
    constructor({ factory, ...config }) {
        super(config);
        this.formFactory = factory;
        this.forms = [];
    }

    getData() {
        return this.forms.map(f => f.getData());
    }

    modify(newVal, preVal) {
        return newVal.map(data => this.formFactory({ data }));
    }

    setData(data) {
        super.setData(data);
        this.forms = this.currentValue;
    }

    validate() {
        if (this.config.required &&
            (
                this.forms.length === 0 ||
                this.forms.some(f => f._fields.some(n => !f[n].isValid()))
            )
        ) {
            throw new ValidationError('This section requires at least one valid entry.');
        }
        return ;
    }

    isDirty() {
        return this.forms.some(f => f.isDirty());
    }

    pushForm(config) {
        this.forms.push(this.formFactory(config));
        this.triggerOnChange();
    }

    unshiftForm(config) {
        this.forms.unshift(this.formFactory(config));
        this.triggerOnChange();
    }

    removeForm(form) {
        const index = this.forms.indexOf(form);
        if (index >= 0) {
            this.forms.splice(index, 1);
            this.triggerOnChange();
        }
    }
}

export class FormField extends Field {
    constructor(config) {
        super(config);
        Field.new.call(() => this, config);
        this.config = config;
        config.form._fields.map(name => this[name] = config.form[name]);
    }

    getData() {
        return this.config.form.getData();
    }

    setData(data) {
        this.config.form.setData(data);
    }

    validate() {
        return this.config.form.isValid();
    }
}

export class OptionsField extends Field {
    constructor(config) {
        config = config || {}
        super({
            default: config.default
                ? { ...config.default, selected: true }
                : (config.multiple ? [] : null),
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
                const selected = this.defaultValue || config.options.find(o => o.selected) || config.options[0];
                this.setData(selected);
            }

        }
    }

    validate() {
        if (this.config.required && this.value === undefined) {
            throw new ValidationError('This field is required.');
        }
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

