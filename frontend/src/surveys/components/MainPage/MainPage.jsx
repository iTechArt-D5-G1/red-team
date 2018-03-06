import React from 'react';

import SurveysListContainer from '../../containers/SurveysListContainer/SurveysListContainer.js';
import SurveyListErrorHandler from '../../containers/SurveysListContainer/SurveyListErrorHandler.jsx';
import FormToSubmit from '../../containers/FormToSubmit/FormToSubmit.jsx';
import FromToSubmitErrorHandler from '../../containers/FormToSubmit/FormToSubmitErrorHandler.jsx';
import './MainPage.scss';

const MainPage = () => (
    <article className='container main_page'>
        <div className='row'>
            <FromToSubmitErrorHandler>
                <FormToSubmit />
            </FromToSubmitErrorHandler>
        </div>

        <SurveyListErrorHandler>
            <SurveysListContainer />
        </SurveyListErrorHandler>
    </article>
);

export default MainPage;
