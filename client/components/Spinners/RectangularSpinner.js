import m from 'mithril'

import Styles from './RectangularSpinner.css'

export default function RectangularSpinner() {

    function view() {
        return (
            <div class={Styles.ldsGrid}>
                <div/>
                <div/>
                <div/>
                <div/>
                <div/>
                <div/>
                <div/>
                <div/>
                <div/>
            </div>
        );
    }

    function oncreate({ dom: ref }) {
        const $div = $(ref);
        // $div.css({
        //     top: "50%",
        //     left: "50%",
        //     margin: `-${$div.height() / 2}px 0 0 -${$div.width() / 2}px`
        // });
    }

    return { view , oncreate }
}