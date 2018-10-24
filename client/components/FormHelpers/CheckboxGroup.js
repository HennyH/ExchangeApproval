import m from 'mithril'
import classNames from 'classnames'

const noop = () => {};

export default function CheckboxGroup() {

    function view({
        attrs: {
            field,
            options = null,
            onchange = noop,
            class: classes = null,
            inline = true,
            ...otherAttrs
        }
    }) {
        options = options || field.config.options || [];
        const name = field.fieldName;
        return (
            <div class={classNames("form-group", inline && "form-inline")}>
                {options.map(({ label, value  }) => {
                    const id = `${name}_${label}`;
                    return (
                        <div class={classNames("custom-control custom-checkbox", inline && "form-check-inline")}>
                            <input
                                class="custom-control-input"
                                type="checkbox"
                                id={id}
                                value={value}
                                name={name}
                                onclick={e => {
                                    const selected = e.target.checked;
                                    const option = new Option(label, value, false, selected);
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
            </div>
        );
    }

    return { view }
}