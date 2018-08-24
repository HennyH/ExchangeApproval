import m from 'mithril';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import classNames from 'classnames';
import myStyles from './special.css'

let root = document.body;
m.render(
    root,
    <main>
        <div class={myStyles.red}>
            Hello World!
        </div>
        <div class={classNames("alert", "alert-primary")}>
            Alert! Alert!
        </div>
    </main>
);
