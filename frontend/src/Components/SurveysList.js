import React, { Component } from 'react';
import PropTypes from 'prop-types'
import Survey from './Survey';

const SurveysList  = ({surveys, onSurveyClick}) =>(
     <ul>
     {surveys.map(survey =>
       <Survey
         key={survey.id}
         {...survey}
         onClick={() => onSurveyClick()}
         class = {'surveys-list__content'}
/>
     )}
   </ul>
)


SurveysList.propTypes = {
    surveys: PropTypes.arrayOf(PropTypes.shape({
      id: PropTypes.number.isRequired,
      text: PropTypes.string.isRequired
    }).isRequired).isRequired,
    onSurveyClick: PropTypes.func.isRequired
  }



export default SurveysList;
