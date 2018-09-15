import m from 'mithril'
import classNames from 'classnames'

const noop = () => {};

export default function RadioGroup() {

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
        const name = field.fieldName;
        const validationClass = !readonly
            ? (field.isValid() ? (field.isDirty() ? 'is-valid' : '') : 'is-invalid')
            : '';
        const selected = field.getData();
        return (
            <div class={classNames("form-group", validationClass)}>
                {options.map(option => {
                    const { label, value } = option;
                    const id = `${name}_${label}`;
                    return (
                        <div class="custom-control custom-radio">
                            <input
                                class="custom-control-input"
                                type="radio"
                                id={id}
                                value={value}
                                name={field.fieldName}
                                checked={value === selected.value}
                                onclick={e => {
                                    field.setData(option);
                                    onchange(option);
                                }}
                                {...otherAttrs}
                            />
                            <label class="custom-control-label" for={id}>
                                {label}
                            </label>
                        </div>
                    );
                })}
                <div class="invalid-feedback">{field.getError()}</div>
            </div>
        );
    }

    return { view }
}