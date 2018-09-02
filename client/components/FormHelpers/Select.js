import m from 'mithril'
import classNames from 'classnames';

const noop = () => {};

export default function Select2() {
    function view({
        attrs: {
            field,
            onchange = noop,
            class: classes = null,
            options = [],
            ...otherAttrs
        }
    }) {
        const selected = options.find(o => o.selected) || field.getData() || options[0];
        if (selected) {
            const currentSelection = field.getData();
            if (!currentSelection || currentSelection.value !== selected.value) {
                field.setData(selected);
                m.redraw();
            }
        }
        return (
            <select
                name={field.fieldName}
                class={classNames("form-control", classes)}
                onchange={e => {
                    field.setData(e.target.selectedOptions[0]);
                    onchange(e);
                }}
                {...otherAttrs}
            >
                {options.map(props => <option {...props} />)}
            </select>
        )
    }

    return { view };
}