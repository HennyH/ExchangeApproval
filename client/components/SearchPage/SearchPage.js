import m from 'mithril';
import classNames from 'classnames';

import Layout from 'Components/Layout';

import { addItemToCart, default as Cart } from 'Components/Cart';
import DecisionSearchSettingsPanel from './DecisionSearchSettingsPanel.js';
import Spinner from 'Components/Spinners/RectangularSpinner.js';
import DecisionsTable from './DecisionsTable.js';

const Data = {
    filters: {
        loading: false,
        options: null,
        fetch: () => {
            Data.filters.loading = true;
            m.request({
                method: "GET",
                url: "/api/requests/filters"
            }).then(options => {
                Data.filters.options = options;
                Data.filters.loading = false;
            });
        }
    },
    decisions: {
        loading: false,
        list: [],
        fetch: ({ universityNames = [], uwaContextTypes = [], uwaUnitLevels = [] } = {}) => {
            Data.decisions.loading = true;
            const qs = m.buildQueryString({
                universityNames,
                uwaContextTypes,
                uwaUnitLevels
            });
            m.request({
                method: "GET",
                url: `/api/requests/decisions?${qs}`
            }).then(items => {
                Data.decisions.list = items;
                Data.decisions.loading = false;
            });
        }
	},
	hasSearched: false
}

function UnitSearch() {
	function view() {
		return(
			<div class="card mt-3">
				<div class="card-header">
					Unit Search
				</div>
				<div class="card bg-light m-3">
				<div class="card-header">Search Settings</div>
				<div class={classNames("card-body", Data.filters.loading ? "text-center" : "")}>
					{(Data.filters.loading
						? <Spinner />
						: <DecisionSearchSettingsPanel
							onSearchSettingsChanged={handleSearchSettingsChanged}
							exchangeUniversityOptions={Data.filters.options.exchangeUniversityNames}
							levelOptions={Data.filters.options.uwaUnitLevelOptions}
							contextOptions={Data.filters.options.uwaUnitContextOptions}
						/>
					)}
				</div>
				</div>
				<div class="card bg-light m-3">
					<div class="card-header">Search Results</div>
						<div class={classNames("card-body", Data.decisions.loading ? "text-center" : "")}>
							{Data.hasSearched ? 
								(Data.decisions.loading
									? <Spinner />
									: <DecisionsTable
										decisions={Data.decisions.list}
										onAddToCart={addItemToCart}
									/>
								)
							: <p class="my-0"><em>Search to see previously approved exchange units</em></p>}
						</div>
				</div>
			</div>
		)
	}

	function handleSearchSettingsChanged(settings) {
        const universityNames = settings.exchangeUniversities.map(({ value }) => value);
        const uwaContextTypes = settings.approvalTypes.map(({ value }) => value);
		const uwaUnitLevels = settings.unitLevels.map(({ value }) => value);
		Data.hasSearched = true;
        Data.decisions.fetch({ universityNames, uwaContextTypes, uwaUnitLevels });
        console.log(settings);
        m.redraw();
	}
	
	return{view};
}

export default function SearchPage() {

    function oninit() {
        if (Data.filters.options == null) {
            Data.filters.fetch();
        }
        if (Data.decisions.list.length === 0) {
            Data.decisions.fetch();
        }
    }

    function view() {

        return (
            <Layout>
				<div class="container-fluid">
					<UnitSearch/>
				</div>
                <div class="container-fluid">
					<Cart/>
                </div>
            </Layout>
        );
    }

    return { oninit, view };
}
