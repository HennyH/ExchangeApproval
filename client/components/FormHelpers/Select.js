import m from 'mithril'
import classNames from 'classnames';

const noop = () => {};

const placeHolderOption = { label: "Please select...", value: null };

export default function Select() {
    function view({
        attrs: {
            field,
            onchange = noop,
            className: classes = null,
            options = null,
            readonly,
            ...otherAttrs
        }
    }) {
        options = options || field.config.options
        const selectedOption = field.getData() || options.find(o => o.selected);
        const validationClass = !readonly && field.validationClass();
        if (selectedOption) {
            const currentSelection = field.getData();
            if (!currentSelection || currentSelection.value !== selectedOption.value) {
                field.setData(selectedOption);
            }
        }
        return [
            <select
                name={field.fieldName}
                class={classNames("custom-select", classes, validationClass)}
                onchange={e => {
                    field.setData(e.target.selectedOptions[0]);
                    onchange(e);
                }}
                disabled={readonly}
                {...otherAttrs}
            >
                {!selectedOption && (
                    <option value={placeHolderOption.value}>
                        {placeHolderOption.label}
                    </option>
                )}
                {options.map(props => (
                    <option
                        {...props}
                        selected={selectedOption && props.value === selectedOption.value}
                    >
                        {props.label}
                    </option>
                ))}
            </select>,
            <div class="invalid-feedback">{field.getError()}</div>
        ];
    }

    return { view };
}