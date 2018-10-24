import m from 'mithril'
import classNames from 'classnames';

import Styles from './RectangularSpinner.css'

export default function RectangularSpinner() {

    function view({ attrs: { className: classes, ...otherAttrs }}) {
        return (
            <div class={classNames(Styles.ldsGrid, classes)} {...otherAttrs}>
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

    return { view }
}