import React from 'react';

import GetSurveysList from '../../surveys/containers/GetSurveysList';
import FormToSubmit from '../../surveys/containers/FormToSubmit.jsx';

const MainPageContent = () => (
    <div className='container main_page'>
        <div className='row'>
            <FormToSubmit />
        </div>

        <GetSurveysList />
    </div>
);

export default MainPageContent;
