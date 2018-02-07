import React, { Component } from 'react';

class FormToSubmit extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.state = { message: '' };
    }

    handleChange(e) {
        if (!e.target.value instanceof (String)) {
            return;
        }

        const reg = /^\d+$/;
        const ourData = e.target.value;

        if (reg.test(ourData[ourData.length - 1])) { this.setState({ message: ourData }); } else { e.target.value = ourData.substring(0, ourData.length - 1); }
    }

    handleSubmit() {
        this.props.call(this.state.message);
    }

    render() {
        return (
            <div className='col-md-12 form-to-submit__content'>
                <p className='form-to-submit__header lead'>Count of models to show:</p>
                <form onSubmit={this.handleSubmit}>
                    <input onChange={this.handleChange} defaultValue={this.state.message} className='form-to-submit__input-field' />
                    <br />
                    <input value='Submit' type='submit' className='form-to-submit__submit-button' />
                </form>
            </div>
        );
    }
}


export default FormToSubmit;
