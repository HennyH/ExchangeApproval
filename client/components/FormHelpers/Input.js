import m from 'mithril'
import classNames from 'classnames'

const noop = () => {};

export default function Input() {
    function view({
        attrs: {
            field,
            oninput = noop,
            class: classes = null,
            appendInputText = null,
            prependInputText = null,
            readonly = false,
            ...otherAttrs
        },
        children
    }) {
        /* If a field is readonly it shouldn't be validated. If we allow
         * validation green borders  appear around inputs despite the values
         * presumably having either been already sumitted to or provided by
         * the server.
         */
        const validationClass = field.validationClass();
        const input = ( 
            <input
                name={field.fieldName}
                readonly={readonly}
                disabled={readonly}
                {...otherAttrs}
                value={field.getData()}
                oninput={e => {
                    field.setData(e.target.value);
                    oninput(e);
                }}
                class={classNames(classes, validationClass, "form-control")}
            >
                {children}
            </input>
        )
        const inputText = (appendInputText || prependInputText)
            ? (
                <div class={classNames({ "input-group-append": !!appendInputText, "input-group-prepend": !!prependInputText})}>
                    <div class="input-group-text">{appendInputText || prependInputText}</div>
                </div>
            )
            : <div />
        const feedback = <div class="invalid-feedback">{field.getError()}</div>
        return [input, inputText, feedback]
    }

    return { view };
}