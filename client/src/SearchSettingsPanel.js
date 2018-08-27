import m from 'mithril';
import classNames from 'classnames';
import 'select2-theme-bootstrap4/dist/select2-bootstrap.min.css'

import CheckboxGroup from './CheckboxGroup';
import styles from './SearchSettingsPanel.css';

export default function SearchSettingsPanel() {

    let universitySelect = null;

    const levelOptions = [
        { label: '1000', value: '1' },
        { label: '2000', value: '2' },
        { label: '3000', value: '3' },
        { label: '>4000', value: '4' }
    ];

    const contextOptions = [
        { label: 'Electives', value: '1' },
        { label: 'Core', value: '2' },
        { label: 'Complementary', value: '3' }
    ];

    function handleSubmit(event) {
        event.preventDefault();
        event.stopPropagation();
    }

    function view() {
        return (
            <div class="container-span">
                <form>
                    <fieldset class={styles.fieldset}>
                        <legend class={styles.legend}>Search Settings</legend>
                        <div class="row">
                            <div class="col-6">
                                <label for="universities">Exchange Universitys</label>
                                <select class="form-control" id="universities-select" name="universities"></select>
                            </div>
                            <div class="col">
                                <label>Approval Type(s)</label>
                                <CheckboxGroup name="approval-types"
                                               options={contextOptions}
                                               handleUpdate={console.log}
                                />
                            </div>
                            <div class="col">
                                <label>Unit Level(s)</label>
                                <CheckboxGroup name="unit-level"
                                               options={levelOptions}
                                               handleUpdate={console.log}
                                />
                            </div>
                            <div class="col">
                                <button type="submit" class="btn btn-primary">
                                    Search
                                </button>
                            </div>
                        </div>
                    </fieldset>
                </form>

            </div>

        )
    }

    function oncreate(vnode) {
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

        const $submitButton = $(vnode.dom).find('button[type="submit"]');
        $submitButton.css('margin-top', $submitButton.parent().height() - $submitButton.height());
        $submitButton.css('margin-left', $submitButton.parent().width() - $submitButton.width());
    }

    return { view, oncreate };
}