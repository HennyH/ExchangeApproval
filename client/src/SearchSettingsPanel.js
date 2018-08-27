import m from 'mithril';
import classNames from 'classnames';
import 'select2-theme-bootstrap4/dist/select2-bootstrap.min.css'

import CheckboxGroup from './CheckboxGroup';

export default function SearchSettingsPanel() {

    let universitySelect = null;

    const levelOptions = [
        { label: '1000', value: '1' },
        { label: '2000', value: '2' },
        { label: '3000', value: '3' },
        { label: '>4000', value: '4' }
    ];

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
                                <CheckboxGroup name="unit-level"
                                               options={levelOptions}
                                               handleUpdate={console.log}
                                />
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