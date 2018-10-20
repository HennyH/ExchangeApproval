import m from 'mithril'

export default function DeleteButton() {
    function view({ attrs: { onClick }}) {
        return (
            <button
                type="button"
                class="btn btn-outline-danger"
                onclick={onClick}
            >
                &times;
            </button>
        )
    }

    return { view }
}