import React from 'react';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { addSurvey } from '../../actions';

const isLastElementNumber = (stringToCheck) => {
    const numbersOnlyPattern = /^\d+$/;
    return numbersOnlyPattern.test(stringToCheck[stringToCheck.length - 1]);
};

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
        this.props.submitSurvey(input);
        this.setState({ input: '' });
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

FormToSubmit.propTypes = {
    submitSurvey: PropTypes.func.isRequired,
};

function mapStateToProps(state) {
    const { surveys } = state.surveys;
    return {
        surveys,
    };
}

const mapDispatchToProps = dispatch => ({
    submitSurvey: bindActionCreators(addSurvey, dispatch),
});

const SumbitForm = connect(mapStateToProps, mapDispatchToProps)(FormToSubmit);

export default SumbitForm;
