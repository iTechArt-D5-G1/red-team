import React from 'react';

import SurveysListContainer from '../../containers/SurveysListContainer/SurveysListContainer.js';
import FormToSubmit from '../../containers/FormToSubmit/FormToSubmit.jsx';
import GenericErrorHandler from './../../../shared/errorHandlers/GenericErrorHandler.jsx';

const Surveys = () => (
    <article>
        <GenericErrorHandler>
            <div className='row'>
                <FormToSubmit />
            </div>

            <SurveysListContainer />
        </GenericErrorHandler>
    </article>
);

export default Surveys;
