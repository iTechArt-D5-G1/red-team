import React from 'react';
import PropTypes from 'prop-types';

import Survey from '../Survey/Survey.jsx';

const SurveysList = ({ surveys, onSurveyClick }) => (
    <div className='row surveys-list'>
        {surveys.map(survey =>
            (<Survey
                key={survey.id}
                {...survey}
                onClick={() => onSurveyClick()}
            />))}
    </div>
);

SurveysList.propTypes = {
    surveys: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.number.isRequired,
        text: PropTypes.string.isRequired,
    }).isRequired).isRequired,
    onSurveyClick: PropTypes.func.isRequired,
};


export default SurveysList;
