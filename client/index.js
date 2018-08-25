import m from 'mithril';

import SearchSettingsPanel from './src/SearchSettingsPanel'

const Data = {
    decisions: {
        list: [],
        fetch: () => {
            m.request({
                method: "GET",
                url: "https://localhost:5001/api/values/decisions"
            }).then(items => {
                Data.decisions.list = items;
            });
        }
    }
}


let UnitDecisionTable = () => {

    let dataTable = null;

    return {
        oninit: Data.decisions.fetch,
        view: () =>(
            <div>
                <SearchSettingsPanel />
                <table id="example" class="display table" style="width:100%" />
            </div>
        ),
        oncreate: () => {
            dataTable = $('#example').DataTable({
                data: Data.decisions.list,
                columns: [
                    { title: 'Unit Name', data: 'exchange_unit_name' }
                ]
            });
        },
        onupdate: () => {
            dataTable.clear();
            dataTable.rows.add(Data.decisions.list);
            dataTable.draw();
        }
    }
}

(() => {


    let root = document.body;
    m.mount(
        root,
        UnitDecisionTable
    );

})()
