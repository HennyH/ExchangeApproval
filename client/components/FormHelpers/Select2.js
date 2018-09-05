import m from 'mithril'
import classNames from 'classnames';

import Styles from './Select2.css'

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
                class={classNames("form-control", Styles.select2Wrapper, classes)}
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