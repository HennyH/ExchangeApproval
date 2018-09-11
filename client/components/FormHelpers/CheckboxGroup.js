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
                {options.map(({ label, value  }) => (
                    <div class="custom-control custom-checkbox">
                        <input
                            class="control-input"
                            type="checkbox"
                            value={value}
                            name={name}
                            onclick={e => {
                                const value = e.target.value;
                                const selected = e.target.checked;
                                const option = new Option(value, value, false, selected);
                                field.setData(option);
                                onchange(option);
                            }}
                            {...otherAttrs}
                        />
                        <label class="control-label" for={name}>
                            {label}
                        </label>
                    </div>
                ))}
            </div>
        );
    }

    return { view }
}