import m from 'mithril'

import Layout from 'Components/Layout'
import ApplicationForm from './ApplicationForm'

export default function ApplicationPage() {

    function view() {
        return (
            <Layout>
                <div class="container">
                    <ApplicationForm
                        contextTypeOptions={[
                            { value: '1', label: 'Elective '},
                            { value: '2', label: 'Core' }
                        ]}
                        electiveContextTypeOption={{ value: '1' }}
                        changeCallback={console.log}
                    />
                </div>
            </Layout>
        )
    }

    return { view }
}