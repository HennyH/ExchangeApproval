import m from 'mithril'
import classNames from 'classnames'

const noop = () => {}

let NEXT_ID = 1;

export function FormRepeater() {

    const state = {
        scrollToBottom: false,
        ref: null,
        jumps: false,
        nextFormKey: 1
    };

    function removeForm(field, form) {
        field.removeForm(form);
    }

    function addForm(field, config) {
        const formKey = state.nextFormKey;
        state.nextFormKey += 1;
        field.pushForm({ ...config, __repeater_key: formKey });
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

    function oncreate({ dom: ref }) {
        state.ref = ref;
    }

    function onupdate({ dom: ref }) {
        state.ref = ref;
    }

    function view({
        attrs: {
            field,
            render,
            jumps = true,
            readonly = false,
            footer = noop
        }
    }) {
        const numberOfForms = field.forms.length;
        const validationClass = !readonly
            ? (field.isValid() ? (field.isDirty() ? 'is-valid' : '') : 'is-invalid')
            : '';
        const error = field.getError({ childForms: false });
        return (
            <div>
                {(jumps && numberOfForms > 1
                    ? (
                        <div class="row my-0">
                            <button type="button" class="btn btn-link my-0 ml-auto" onclick={scrollToLastForm}>
                                Jump To Bottom
                            </button>
                        </div>
                    )
                    : <div />
                )}
                {(field.forms.map((form, index) =>
                    <div key={form.__repeater_key} class='form-item'>
                        {render({
                            index,
                            form,
                            removeForm: () => removeForm(field, form)
                        })}
                    </div>
                ))}
                <input type="hidden" class={classNames("form-control", validationClass)} />
                <div class="invalid-feedback mt-2 mb-2" style="line-height: 1.5em;">
                    {error}
                </div>
                <div class="row mx-2">
                    {footer({
                        forms: field.forms,
                        addForm: (config) => addForm(field, config),
                        removeForm: (form) => removeForm(field, form)
                    })}
                    {jumps && numberOfForms > 1 && (
                        <button
                            type="button"
                            class={classNames(numberOfForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-link ml-auto")}
                            onclick={scrollToFirstItem}>
                                Jump To Top
                        </button>
                    )}
                </div>
            </div>
        )
    }

    return { oncreate, onupdate, view }
}