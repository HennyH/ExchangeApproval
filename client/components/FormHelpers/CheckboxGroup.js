import m from 'mithril'

const noop = () => {};

export default function CheckboxGroup() {

    function view({
        attrs: {
            field,
            options = [],
            onchange = noop,
            class: classes = null,
            ...otherAttrs
        }
    }) {
        const name = field.fieldName;
        return (
            <div class="form-group">
                {options.map(({ label, value  }) => {
                    const id = `${name}_${label}`;
                    return (
                        <div class="custom-control custom-checkbox">
                            <input
                                class="custom-control-input"
                                type="checkbox"
                                id={id}
                                value={value}
                                name={name}
                                onclick={e => {
                                    const value = e.target.value;
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