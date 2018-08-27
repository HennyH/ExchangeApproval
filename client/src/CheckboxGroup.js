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
                    <div class="form-check">
                        <input class="form-check-input"
                            type="checkbox"
                            value={value}
                            id={name + label}
                            onclick={handleCheckboxClicked.bind(this, handleUpdate)}
                        />
                        <label class="form-check-label" for={name + label}>
                            {label}
                        </label>
                    </div>
                ))}
            </div>
        );
    }

    return { oninit, view }
}