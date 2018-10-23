import m from 'mithril'
import classNames from 'classnames'

const noop = () => {};

export default function RadioButtonGroup() {

    function view({
        attrs: {
            field,
            options = null,
            onchange = noop,
            class: classes = null,
            readonly = false,
            ...otherAttrs
        }
    }) {
        options = options || field.config.options || [];
        const defaultOption = field.defaultValue;
        const name = field.fieldName;
        const validationClass = !readonly
            ? (field.isValid() ? (field.isDirty() ? 'is-valid' : '') : 'is-invalid')
            : '';
        const selectedOption = field.getData();
        return (
            <div class="form-group">
                <div class={classNames("btn-group btn-group-toggle", validationClass)}>
                    {options.map(option => {
                        const { label, value, class: classes = "btn-outline-secondary" } = option;
                        const id = `${name}_${label}`;
                        const selected = value === selectedOption.value;
                        return (
                            <label class={classNames("btn", classes, selected ? "active" : "")} key={id}>
                                <input
                                    type="radio"
                                    id={id}
                                    name={field.fieldName}
                                    autocomplete="off"
                                    checked={value === defaultOption.value}
                                    onclick={e => {
                                        field.setData(option);
                                        onchange(option);
                                    }}
                                />
                                {label}
                            </label>
                        );
                    })}
                </div>
                <div class="invalid-feedback">{field.getError()}</div>
            </div>
        );
    }

    return { view }
}