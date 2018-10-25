import m from 'mithril'
import classNames from 'classnames';

const noop = () => {};

export default function Select() {
    function view({
        attrs: {
            field,
            onchange = noop,
            class: classes = null,
            options = null,
            readonly,
            ...otherAttrs
        }
    }) {
        options = options || field.config.options
        const selected = field.getData() || options.find(o => o.selected) || options[0];
        if (selected) {
            const currentSelection = field.getData();
            if (!currentSelection || currentSelection.value !== selected.value) {
                field.setData(selected);
            }
        }
        return (
            <select
                name={field.fieldName}
                class={classNames("custom-select", classes)}
                onchange={e => {
                    field.setData(e.target.selectedOptions[0]);
                    onchange(e);
                }}
                disabled={readonly}
                {...otherAttrs}
            >
                {options.map(props => (
                    <option
                        {...props}
                        selected={props.value === selected.value}
                    >
                        {props.label}
                    </option>
                ))}
            </select>
        )
    }

    return { view };
}