import m from 'mithril'

export default function DeleteButton() {
    function view({ attrs: { onClick }}) {
        return (
            <button
                type="button"
                class="btn btn-outline-danger"
                style="font-weight: 800"
                onclick={onClick}
            >
                &times;
            </button>
        )
    }

    return { view }
}