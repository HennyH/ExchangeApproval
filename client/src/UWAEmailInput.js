import m from 'mithril'

export default function UWAEmailInput() {

    let inputTouched = false;

    function handleSubmit(vnode, event) {
        event.stopPropagation();
        const value = event.target.value + event.key;
        if (value.match(/^\d{8}$/)) {
            event.target.setCustomValidity('');
        } else {
            event.target.setCustomValidity('invalid UWA email.');
        }
        if (!inputTouched) {
            vnode.dom.classList.add('was-validated');
            inputTouched = true;
        }
    }

    function view(vnode) {
        return (
            <form novalidate>
                <div class="form-group row">
                    <label class="col col-form-label" for="email">Student Email: </label>
                    <div class="col">
                        <div class="input-group">
                            <input onkeydown={handleSubmit.bind(this, vnode)}
                                type="text"
                                class="form-control"
                                style="width: 6em;"
                            />
                            <div class="input-group-append">
                                <span class="input-group-text" id="basic-addon">@student.uwa.edu.au</span>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        )
    }

    return { view }
}