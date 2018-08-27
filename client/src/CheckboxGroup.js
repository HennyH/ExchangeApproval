import m from 'mithril'

const TOGGLE_CHECKBOX = "TOGGLE_CHECKBOX";

function reducer(state, action, data) {
    switch (action) {
        case TOGGLE_CHECKBOX:
            return [...state, data.value].filter(v => data.checked || v != data.value);
        default:
            console.log('Unkown action', action);
            return state;
    }
}

export default function CheckboxGroup() {

    let state = [];

    function oninit({ attrs: { handleUpdate: onUpdate } }) {
        onUpdate(state);
    }

    function handleCheckboxClicked(onUpdate, event) {
        const value = event.target.value;
        const checked = event.target.checked;
        state = reducer(state, TOGGLE_CHECKBOX, { value, checked });
        onUpdate(state);
    }

    function view({ attrs: { name, options = [], handleUpdate }}) {
        return (
            <div class="form-group">
                {options.map(({ label, value }) => (
                    <div class="custom-control custom-checkbox">
                        <input class="custom-control-input"
                            type="checkbox"
                            value={value}
                            id={name + label}
                            onclick={handleCheckboxClicked.bind(this, handleUpdate)}
                        />
                        <label class="custom-control-label" for={name + label}>
                            {label}
                        </label>
                    </div>
                ))}
            </div>
        );
    }

    return { oninit, view }
}