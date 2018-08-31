import m from 'mithril'

import ApplicationForm from './ApplicationForm'
import Styles from './ApplicationPage.css';

export default function ApplicationPage() {
    function view() {
        return (
            <div>
                <div class={Styles.header}>
                    <span class={Styles.headerTitle}>
                        Exchange Unit Approval Application
                    </span>
                </div>
                <br />
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <ApplicationForm
                                contextTypeOptions={[
                                    { value: '1', label: 'Elective '},
                                    { value: '2', label: 'Core' }
                                ]}
                                electiveContextTypeOption={{ value: '1' }}
                                changeCallback={console.log} />
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    return { view }
}