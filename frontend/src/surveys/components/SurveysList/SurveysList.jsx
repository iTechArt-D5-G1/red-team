import React from 'react';
import PropTypes from 'prop-types';

import Survey from '../Survey/Survey.jsx';

class SurveysList extends React.Component {
    renderSurveys = survey => (<Survey
        id={survey.id}
        {...survey}
        onClick={() => this.props.onSurveyClick()}
    />)

    render() {
        return (
            <div className='row surveys-list'>
                {this.props.surveys.map(this.renderSurveys)}
            </div>
        );
    }
}

SurveysList.propTypes = {
    surveys: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        text: PropTypes.string.isRequired,
    }).isRequired).isRequired,
    onSurveyClick: PropTypes.func.isRequired,
};

export default SurveysList;
