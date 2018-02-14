import React from 'react';
import FormToSubmit from '../containers/FormToSubmit';
import GetSurveysList from '../containers/GetSurveysList';


const MainPageContent = () => (
    <div className='container main_page'>
        <div className='row'>
            <FormToSubmit />
        </div>

        <GetSurveysList />
    </div>
);

export default MainPageContent;
