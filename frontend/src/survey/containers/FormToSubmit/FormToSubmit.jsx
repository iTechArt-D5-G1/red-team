import React from 'react';
import { connect } from 'react-redux';

const isLastElementNumber = (stringToCheck) => {
    const numbersOnlyPattern = /^\d+$/;
    return numbersOnlyPattern.test(stringToCheck[stringToCheck.length - 1]);
};

function NotImplementedException() {
    this.name = 'Not implemented exception';
    this.message = 'Part of app you trying reach is not yet implemented';
    this.toString = () => this.message;
}

class FormToSubmit extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            input: '',
        };
    }

    handleInputChange = (e) => {
        if ((e.target.value instanceof (String))) {
            return;
        }
        const targetValue = e.target.value;
        if (!isLastElementNumber(targetValue)) {
            e.target.value = targetValue.substring(0, targetValue.length - 1);
        }
        this.setState({ input: e.target.value });
    }

    handleSubmit = (e) => {
        const { input } = this.state;
        e.preventDefault();
        if (!input.trim()) {
            return;
        }
        this.setState({ input: '' });
        throw new NotImplementedException();
    }

    render() {
        const { input } = this.state;
        return (
            <div className='col-md-12 form-to-submit'>
                <p className='form-to-submit__header lead'>Count of models to show:</p>
                <form onSubmit={this.handleSubmit}>
                    <input
                        onChange={this.handleInputChange}
                        className='form-to-submit__input-field'
                        value={input}
                    />
                    <br />
                    <button type='submit' className='form-to-submit__submit-button'>
            Submit
                    </button>
                </form>
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { surveys } = state.surveys;
    return {
        surveys,
    };
}

const SumbitForm = connect(mapStateToProps)(FormToSubmit);

export default SumbitForm;
