import m from 'mithril'
import classNames from 'classnames';

const noop = () => {};

export default function Select2() {
    function view({
        attrs: {
            field,
            onchange = noop,
            class: classes = null,
            ...otherAttrs
        }
    }) {
        return (
            <select
                name={field.fieldName}
                class={classNames("form-control", classes)}
                onchange={e => {
                    field.setData(e.target.selectedOptions);
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