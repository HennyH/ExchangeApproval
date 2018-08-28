import m from 'mithril'
import classNames from 'classnames'

const noop = () => {};

export default function Input() {
    function view({
        attrs: {
            field,
            oninput: handleInput = noop,
            class: classes = null,
            appendInputText: appendText = null,
            prependInputText: prependText = null,
            ...otherAttrs
        },
        children
    }) {
        const validationClass = field.isDirty()
            ? (field.isValid() ? 'is-valid' : 'is-invalid')
            : '';
        const input = (
            <input
                name={field.fieldName}
                {...otherAttrs}
                value={field.getData()}
                oninput={e => {
                    field.setData(e.target.value);
                    handleInput(e);
                }}
                class={classNames(classes, validationClass, "form-control")}
            >
                {children}
            </input>
        )
        const inputText = (appendText || prependText)
            ? (
                <div class={classNames({ "input-group-append": !!appendText, "input-group-prepend": !!prependText})}>
                    <div class="input-group-text">{appendText || prependText}</div>
                </div>
            )
            : <div />
        const feedback = <div class="invalid-feedback">{field.getError()}</div>
        return [input, inputText, feedback]
    }

    return { view };
}