import m from 'mithril'
import classNames from 'classnames'

const noop = () => {}

export function FormRepeater() {
    const state = {
        scrollToBottom: false,
        ref: null,
        jumps: false
    };

    function oncreate({ attrs: { jumps = true }, dom: ref }) {
        state.ref = ref;
        state.jumps = jumps
    }

    function view({
        attrs: {
            field,
            form: Form,
            jumps = true,
            defaultConfig = {},
            ...formAttrs
        },
        dom: ref
    }) {
        const numberOfForms = field.forms.length;
        const feedback = field.getError();
        const validationClass = field.isDirty()
            ? (field.isValid() ? 'is-valid' : 'is-invalid')
            : '';
        return (
            <div>
                {(jumps && numberOfForms > 1
                    ? (
                        <button type="button" class="mb-1 btn btn-link" onclick={() => scrollToLastForm(ref)}>
                            Jump To Bottom
                        </button>
                    )
                    : <div />
                )}
                {(field.forms.map(f =>
                    <div class='form-item'>
                        <Form {...f} {...formAttrs} form={f} onDelete={() => removeForm(field, f)} />
                    </div>
                ))}
                <input type="hidden" class={classNames("form-control", validationClass)} />
                <div class="invalid-feedback mt-2 mb-2" style="line-height: 1.5em;">{feedback}</div>
                <button
                    type="button"
                    class={classNames(numberOfForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-primary")}
                    onclick={() => addForm(field, { ...defaultConfig })}
                >
                        Add Request
                </button>
                {(jumps && numberOfForms > 1
                    ? (
                        <button
                            type="button"
                            class={classNames(numberOfForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-link")}
                            onclick={() => scrollToFirstItem(ref)}>
                                Jump To Top
                        </button>
                    )
                    : <div />
                )}
            </div>
        )
    }

    function removeForm(field, form) {
        field.removeForm(form);
    }

    function onupdate({ attrs: { jumps = true }, dom: ref }) {
        state.ref = ref;
        state.jumps = jumps;
        if (state.jumps && state.scrollToBottom) {
            state.scrollToBottom = false;
            scrollToLastForm();
        }
    }

    function addForm(field, config) {
        field.pushForm(config);
        if (state.jumps) {
            state.scrollToBottom = true;
        }
    }

    function scrollToLastForm() {
        const $lastItemForm = $(state.ref).find('.form-item').last()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: topOffset,
            behavior: 'smooth'
        });
    }

    function scrollToFirstItem() {
        const $lastItemForm = $(state.ref).find('.form-item').first()
        const topOffset = $lastItemForm.offset().top;
        window.scroll({
            top: window.screenY - topOffset,
            behavior: 'smooth'
        });
    }

    return { oncreate, view, onupdate }
}