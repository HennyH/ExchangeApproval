import m from 'mithril';
import classNames from 'classnames';
import 'select2-theme-bootstrap4/dist/select2-bootstrap.min.css'

export default function SearchSettingsPanel() {

    let universitySelect = null;

    function view() {
        return (
            <div class="container-span search-panel-container">
                <form>
                    <fieldset>
                        <legend>Search Settings</legend>
                        <div class="row">
                            <div class="col">
                                <label for="universities">Exchange Universitys</label>
                                <select class="form-control" id="universities-select" name="universities"></select>
                            </div>
                            <div class="col">
                                <label>Unit Level</label>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="1000" id="unitLevelOne" />
                                    <label class="form-check-label" for="unitLevelOne">
                                        1000
                                    </label>
                                </div>
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="2000" id="unitLevelTwo" />
                                    <label class="form-check-label" for="unitLevelTwo">
                                        2000
                                    </label>
                                </div>
                            </div>
                            <div class="col">
                            </div>
                        </div>
                    </fieldset>
                </form>

            </div>

        )
    }

    function oncreate() {
        universitySelect = $("#universities-select").select2({
            multiple: true,
            width: 'resolve',
            placeholder: {
                id: -1,
                text: 'All Universities'
            },
            ajax: {
                url: 'https://localhost:5001/api/values/universities',
                dataType: 'json',
                processResults: (data) => ({
                    results: data.map(({ id, name }) => ({ id, text: name }))
                })
            }
        });
    }

    return { view, oncreate };
}