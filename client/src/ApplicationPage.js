import m from 'mithril'

import StudentDetailsForm from './StudentDetailsForm'
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
                            <StudentDetailsForm />
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    return { view }
}