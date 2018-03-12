import React from 'react';
import PropTypes from 'prop-types';

import { Survey as SurveyModel } from './../../../models/survey';
import Survey from '../Survey/Survey.jsx';

class SurveysList extends React.Component {
    componentWillMount() {
        this.props.getSurveys();
    }

    onSurveyClick = () => {
    };

    renderSurveys = survey => (<Survey
        key={survey.surveys.id}
        {...survey.surveys}
        onClick={() => this.onSurveyClick()}
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
    surveys: PropTypes.arrayOf(PropTypes.instanceOf(SurveyModel)).isRequired,
    getSurveys: PropTypes.func.isRequired,
};

export default SurveysList;
