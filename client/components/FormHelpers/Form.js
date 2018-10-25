import { Form as PowerForm } from 'powerform'

export default class Form extends PowerForm {
    constructor({...config}) {
        super(config);
        this.configureFields(config);
        Form.new.call(() => this, config);
        this.config = config;
    }

    configureFields(config) {
        throw new Error("You must implement a configureFields method.")
    }

    setDirty(value) {
        this._fields.forEach(fieldName => this[fieldName].setDirty(value));
    }
}