import m from 'mithril'

import Layout from 'Components/Layout'
import StaffDecisionSearchSettingsPanelContainer from './StaffDecisionSearchSettingsPanelContainer.js'
import { COLUMN_NAMES, default as DecisionsTable } from '../DecisionSearch/DecisionsTable.js';

const MOCK_DECISIONS = [
    {
        "id": 7,
        "decisionDate": "1995-04-08T00:00:00",
        "exchangeUniversityName": "University of New York",
        "exchangeUnitName": "System Computer",
        "exchangeUnitCode": "SCI200-2",
        "exchangeUnitOutlineHref": "https://university.com",
        "uwaUnitName": "Army Meat Paper Investment",
        "uwaUnitCode": "CHEM3030",
        "uwaUnitLevel": ">4000",
        "uwaUnitContext": "Core",
        "approved": true
    },
    {
        "id": 18,
        "decisionDate": "2000-06-13T00:00:00",
        "exchangeUniversityName": "University of Los Angeles",
        "exchangeUnitName": "Management System Variety Map",
        "exchangeUnitCode": "ART1020",
        "exchangeUnitOutlineHref": "https://university.com",
        "uwaUnitName": "Definition Player Food Internet",
        "uwaUnitCode": "ANTH3.12",
        "uwaUnitLevel": ">4000",
        "uwaUnitContext": "Core",
        "approved": true
    },
    {
        "id": 23,
        "decisionDate": "2010-03-16T00:00:00",
        "exchangeUniversityName": "University of Fort Worth",
        "exchangeUnitName": "Fact Temperature",
        "exchangeUnitCode": "ALGS-1",
        "exchangeUnitOutlineHref": "https://university.com",
        "uwaUnitName": "Week System Language",
        "uwaUnitCode": "STAT2000",
        "uwaUnitLevel": ">4000",
        "uwaUnitContext": "Core",
        "approved": false
    }
]

export default function StaffPage() {
    function view() {
        return (
            <Layout>
                <div class="container">
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <StaffDecisionSearchSettingsPanelContainer onsubmit={console.log} />
                        </div>
                    </div>
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <DecisionsTable
                                decisions={MOCK_DECISIONS}
                                headers={[
                                    COLUMN_NAMES.Type,
                                    COLUMN_NAMES.ExchangeUniversity,
                                    COLUMN_NAMES.ExchangeUnit,
                                    COLUMN_NAMES.UWAUnit,
                                    COLUMN_NAMES.Approved
                                ]}
                            />
                        </div>
                    </div>
                    <div class="card bg-light mt-3 mb-3">
                        <div class="card-header">Search Settings</div>
                        <div class="card-body">
                            <DecisionsTable
                                decisions={MOCK_DECISIONS}
                                headers={[
                                    COLUMN_NAMES.Type,
                                    COLUMN_NAMES.ExchangeUniversity,
                                    COLUMN_NAMES.ExchangeUnit,
                                    COLUMN_NAMES.UWAUnit,
                                    COLUMN_NAMES.Approved
                                ]}
                            />
                        </div>
                    </div>
                </div>
            </Layout>
        );
    }

    return { view };
}