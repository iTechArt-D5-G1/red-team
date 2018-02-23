import React from 'react';

import GetSurveysList from '../../containers/GetSurveysList';
import FormToSubmit from '../../containers/FormToSubmit';

const MainPageContent = () => (
    <div className='container main_page'>
        <div className='row'>
            <FormToSubmit />
        </div>

        <GetSurveysList />
    </div>
);

export default MainPageContent;
