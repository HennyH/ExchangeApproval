import m from 'mithril'
import classNames from 'classnames'
import {ApplicationData} from '../ViewData'

const noop = () => {}
let NEXT_ID = 1;

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
            render: Form,
            addItemText = 'Add Item',
            titleFactory = () => null,
            jumps = true,
            readonly,
            defaultConfig = {},
            staffView,
            secondButton = <div/>,
            instructionText,
            ...formAttrs
        },
        dom: ref
    }) {
        const numberOfForms = field.forms.length;
        const validationClass = (!readonly && ApplicationData.hasTriedToSubmit)
            ? (field.isValid() ? (field.isDirty() ? 'is-valid' : '') : 'is-invalid')
            : '';
        const error = field.getError({ childForms: false });
        return (
            <div>
                {(jumps && numberOfForms > 1 && !staffView
                    ? (
                        <div class="row my-0">
                            <button type="button" class="btn btn-link my-0 ml-auto" onclick={() => scrollToLastForm(ref)}>
                                Jump To Bottom
                            </button>
                        </div>
                    )
                    : <div />
                )}
                {(field.forms.map((f, i) =>
                    <div key={f.__repeater_key} class='form-item'>
                        <Form
                            {...formAttrs}
                            readonly={readonly}
                            form={f}
                            formIndex={i}
                            onDelete={() => removeForm(field, f)}
                            staffView = {staffView}
                        />
                    </div>
                ))}
                <input type="hidden" class={classNames("form-control", validationClass)} />
                <div class="invalid-feedback mt-2 mb-2" style="line-height: 1.5em;">
                    {error}
                </div>
                <div class="row mx-2">
                    {(readonly || staffView)
                        ? <div />
                        : (
                            <div class={classNames(numberOfForms > 0 ? "mt-3" : "")}>
                                <button
                                    type="button"
                                    class="mb-1 mr-3 btn btn-primary"
                                    onclick={() => addForm(field, { ...defaultConfig })}
                                >
                                        {addItemText}
                                </button>
                                {secondButton}
                                {numberOfForms == 0 ? <small class="text-muted mt-1">{instructionText}</small> : null }
                            </div>
                        )
                    }
                    {(jumps && numberOfForms > 1 && !staffView
                        ? (
                            <button
                                type="button"
                                class={classNames(numberOfForms > 0 ? "mt-3" : null, "mb-1 mr-3 btn btn-link ml-auto")}
                                onclick={() => scrollToFirstItem(ref)}>
                                    Jump To Top
                            </button>
                        )
                        : <div />
                    )}
                </div>
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
        field.pushForm({ ...config, __repeater_key: NEXT_ID++ });
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