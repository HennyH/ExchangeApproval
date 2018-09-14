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
            onchange = noop,
            defaultConfig = {},
            ...formAttrs
        },
        dom: ref
    }) {
        const numberOfForms = field.forms.length;
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
                        <Form {...f} {...formAttrs} form={f}/>
                    </div>
                ))}
                <button
                    type="button"
                    class={classNames(numberOfForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-primary")}
                    onclick={() => addForm(field, { ...defaultConfig, onChange: onchange })}
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