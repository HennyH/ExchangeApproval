import m from 'mithril'
import classNames from 'classnames';

const noop = () => {};

export default function Select2() {
    function view({
        attrs: {
            field,
            onchange = noop,
            class: classes = null,
            config: { multiple = false } = {},
            ...otherAttrs
        }
    }) {
        return (
            <select
                name={field.fieldName}
                class={classNames("form-control", classes)}
                onchange={e => {
                    if (multiple) {
                        field.setData(e.target.selectedOptions);
                    } else {
                        field.setData(e.target.selectedOptions[0]);
                    }
                    onchange(e);
                }}
                {...otherAttrs}
            />
        )
    }

    function oncreate({ attrs: { config }, dom: ref }) {
        $(ref).select2(config);
    }

    return { view, oncreate };
}