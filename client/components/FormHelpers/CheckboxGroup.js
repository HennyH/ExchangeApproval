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
                {options.map(value => (
                    <div class="custom-control custom-checkbox">
                        <input class="custom-control-input"
                            type="checkbox"
                            value={value}
                            id={name + value}
                            onclick={e => {
                                const value = e.target.value;
                                const selected = e.target.checked;
                                const option = new Option(value, value, false, selected);
                                field.setData(option);
                                onchange(option);
                            }}
                            {...otherAttrs}
                        />
                        <label class="custom-control-label" for={name + value}>
                            {value}
                        </label>
                    </div>
                ))}
            </div>
        );
    }

    return { view }
}